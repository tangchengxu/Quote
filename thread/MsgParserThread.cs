using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MsgExpress;
using QuoteClassify.manager;
using MsgExpress.databus;
using System.Threading;
using System.Collections.Concurrent;

namespace QuoteClassify.thread
{
    enum EDataChangeType
    {
        Type_Progress,
    }
    delegate void OnDataChange(EDataChangeType type, object param);

    class MsgParserThread : BaseThread
    {
        const string mTableName = "quoteclassify_auto";
        bool mParserType;

        public MsgParserThread(OnDataChange hnd,bool parserStyle)
        {
            mDataChangeHander = hnd;
            mParserType = parserStyle;
        }

        protected override void ThreadEntrance()
        {
            Logger.Info("Start Loading Data");
            if (this.IsNeedStop())
                return;

            mTotalMsgNum = this.GetTotalNum();
           //    mTotalMsgNum = 40000;//测试
            if (mTotalMsgNum <= 0)
            {
                Logger.Error("Get total qq message num failed!");
                return;
            }

            //删除数据库重复数据
            Logger.Info("删除操作开始的时间"+DateTime.Now.ToString());            // 2008-9-4 20:02:10
            
            MysqlManager delMng = new MysqlManager(Config.DefaultInstance.mSrcHost,
                Config.DefaultInstance.mSrcDbName, Config.DefaultInstance.mSrcUserName,
                Config.DefaultInstance.mSrcPassWord);

            delMng.DelDBParser();
            delMng.Close();
            Logger.Info("删除操作结束的时间" + DateTime.Now.ToString());

            int start = 0;
            int limitNum = 20000;
            Logger.Info("开始解析！");
            do 
            {
                Reset();
                // 加载数据
                Dictionary<long, byte[]> dataMap = this.LoadData(start, limitNum);
                if (this.IsNeedStop())
                    return;

                if (null == dataMap)
                {
                    if (null != mDataChangeHander)
                    {
                        mDataChangeHander(EDataChangeType.Type_Progress, -1);
                    }
                    return;
                }

                this.ParsingDBData(dataMap);
                if (this.IsNeedStop())
                    return;

                this.SaveDataToDB();
                if (this.IsNeedStop())
                    return;

                start += limitNum;
                if (start >= mTotalMsgNum)
                {
                    break;
                }
                mHandleNum += dataMap.Count;
   
            } while (true);

            if (null != mDataChangeHander)
            {
                mDataChangeHander(EDataChangeType.Type_Progress, 100);
            }
        }

        Dictionary<long, byte[]> LoadData(int start, int limit)
        {
            MysqlManager srcMng = new MysqlManager(Config.DefaultInstance.mSrcHost, 
                Config.DefaultInstance.mSrcDbName, Config.DefaultInstance.mSrcUserName, 
                Config.DefaultInstance.mSrcPassWord);
            Dictionary<long, byte[]> dataMap = srcMng.LoadQQMessage(start, limit, mParserType);
            srcMng.Close();
            return dataMap;
        }

        int GetTotalNum()
        {
            MysqlManager srcMng = new MysqlManager(Config.DefaultInstance.mSrcHost,
                Config.DefaultInstance.mSrcDbName, Config.DefaultInstance.mSrcUserName,
                Config.DefaultInstance.mSrcPassWord);
            int totalNum = srcMng.GetQQMsgNum(mParserType);
            srcMng.Close();
            return totalNum;
        }

        void ParsingDBData(Dictionary<long, byte[]> dataMap)
        {
            DataBus bus = new DataBus();

            mTotalNum = dataMap.Count;
            Logger.Info("Total msg num is : " + mTotalNum);
            int nCount = 0;
            foreach (long id in dataMap.Keys)
            {
                nCount++;
                while (nCount - mRspNum > 10)
                {
                    if (this.IsNeedStop())
                    {
                        bus.Release();
                        return;
                    }  
                    Thread.Sleep(50);
                }

                byte[] data = dataMap[id];
                QQServer.PubReciveMessage pubMsg = null;
                try
                {   
                    pubMsg = QQServer.PubReciveMessage.ParseFrom(data);
                }
                catch (System.Exception ex)
                {
                    pubMsg = null;
                    Logger.Error(ex.StackTrace);
                }

                if (null == pubMsg)
                {
                    Logger.Error("qq msg parse from data failed! id = " + id);
                    AddRspNum();
                    continue;
                }
                mIdToMsgMap[id] = pubMsg;

                string toQQ = (pubMsg.Type == 1 ? "" : pubMsg.ToUin);
                string msgText = Util.GetMsgText(pubMsg);
                string date = Util.FormatDate(pubMsg.Time);
                
                if (!bus.PostParserText(msgText, pubMsg.FromUin, toQQ, date, this.OnResponse, id))
                {
                    Logger.Error("Post Message Failed!");
                    AddRspNum();
                }
            }

            Logger.Info("Finish Post");
            nCount = 0;
            while (mRspNum < mTotalNum)
            {
                nCount++;
                if (nCount >= 200)
                {
                    Logger.Error("UnResponse For Too Long");
                    break;
                }
                if (this.IsNeedStop())
                    break;
                Thread.Sleep(100);
            }

            bus.Release();
        }

        void OnResponse(object sender, ResponseEventArgs e)
        {
            if (this.IsNeedStop())
                return;

            if (e.Result == 0)
            {
                Parsing.QuoteRsp rsp = e.ResponseData.mMsg as Parsing.QuoteRsp;
                long id = (long)e.Arg;
                mIdToRspMap[id] = rsp;

                int progress = (int)((double)(100 * (mRspNum + mHandleNum)) / mTotalMsgNum);
                if (100 != progress && mProgress != progress && null != mDataChangeHander)
                {
                    mProgress = progress;
                    mDataChangeHander(EDataChangeType.Type_Progress, progress);
                }
            }
            else
            {
                Logger.Error("Post Parser Message Failed!");
            }
            AddRspNum();
        }

        void SaveDataToDB()
        {
            List<DBItem> itemList = new List<DBItem>();
            foreach (long id in mIdToMsgMap.Keys)
            {
                if (!mIdToRspMap.ContainsKey(id))
                {
                    continue;
                }
                QQServer.PubReciveMessage pubMsg = mIdToMsgMap[id];
                Parsing.QuoteRsp rsp = mIdToRspMap[id];
                
                string type = Util.GetType(rsp);
                DBItem item = new DBItem();
                item.mId = id;
                item.mDateTime = Util.FormatTime(pubMsg.Time);
                item.mType = type;
                item.mData = rsp.ToByteArray();
                item.mMsgText = Util.GetMsgText(pubMsg);

                itemList.Add(item);
            }

            Config cfg = new Config("../config/");
            MysqlManager disMng = new MysqlManager(cfg.mDisHost, cfg.mDisDbName,
                cfg.mDisUserName, cfg.mDisPassWord);

            disMng.SaveParserResults(mTableName, itemList);
        }

        void AddRspNum()
        {
            lock (this)
            {
                mRspNum++;
            }
        }

        void Reset()
        {
            mRspNum = 0;
            mTotalNum = 0;
            mIdToMsgMap.Clear();
            mIdToRspMap.Clear();
        }

        int mRspNum = 0;
        int mTotalNum = 0;
        int mProgress = 0;
        int mTotalMsgNum = 0;
        int mHandleNum = 0;
        OnDataChange mDataChangeHander;
        ConcurrentDictionary<long, QQServer.PubReciveMessage> mIdToMsgMap
            = new ConcurrentDictionary<long, QQServer.PubReciveMessage>();
        ConcurrentDictionary<long, Parsing.QuoteRsp> mIdToRspMap
            = new ConcurrentDictionary<long, Parsing.QuoteRsp>();
    }
}
