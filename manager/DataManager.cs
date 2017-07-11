using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MsgExpress;
using QuoteClassify.manager;

namespace QuoteClassify.manager
{
    enum ETestType
    {
        TestType_Classify,     // 分类回测
        TestType_BondQuote,    // 债券报价回测
        TestType_OnlineQuote   // 线上资金报价回测
    }

    class DataManager
    {
        const string mAutoTable = "quoteclassify_auto";
        const string mModTable = "quoteclassify_mod";
        const int mPageSize = 50;

        public DataManager()
        {
            mDBMng = new MysqlManager(Config.DefaultInstance.mDisHost,
                Config.DefaultInstance.mDisDbName, Config.DefaultInstance.mDisUserName,
                Config.DefaultInstance.mDisPassWord);

            LoadData();
        }

        public void LoadData()
        {
            // 加载自动解析结果
            List<DBItem> autoItemList = mDBMng.GetParserResults(mAutoTable);
            // 加载人工校验结果
            List<DBItem> modItemList = mDBMng.GetParserResults(mModTable);
            if (null == autoItemList || null == modItemList)
            {
                Logger.Error("Load Data Failed!");
                return;
            }
            mAutoItemList = autoItemList;

            //今日成交
            foreach (DBItem item in mAutoItemList)
            {
                Parsing.QuoteRsp rsp = null;
                rsp = Parsing.QuoteRsp.ParseFrom(item.mData);
                if (rsp.IsDeal == true)
                {
                    mIdDeal.Add(item.mId);
                }
            }
            // 加载消息文本
            Dictionary<long, string> idToMsgMap = this.LoadQQMsgText();
            foreach (DBItem item in mAutoItemList)
            {
                if (idToMsgMap.ContainsKey(item.mId))
                {
                    item.mMsgText = idToMsgMap[item.mId];
                }
            }

            foreach (DBItem item in modItemList)
            {
                if (idToMsgMap.ContainsKey(item.mId))
                {
                    item.mMsgText = idToMsgMap[item.mId];
                }
            }

            Dictionary<long, DBItem> modIdToItemMap = new Dictionary<long, DBItem>();
            foreach (DBItem item in modItemList)
            {
                modIdToItemMap[item.mId] = item;
            }
            mModIdToItemMap = modIdToItemMap;

            // 合并一个最终集合
            List<DBItem> itemList = new List<DBItem>();
            foreach (DBItem item in mAutoItemList)
            {
                if (modIdToItemMap.ContainsKey(item.mId))
                {
                    itemList.Add(modIdToItemMap[item.mId]);
                }
                else
                {
                    itemList.Add(item);
                }
            }
            mItemList = itemList;
        }

        public List<DBItem> GetPageData(int page)
        {
            if (page <= 0 || mItemList.Count <= (page - 1) * mPageSize)
            {
                return null;
            }
            List<DBItem> itemList = new List<DBItem>();
            for (int i = (page - 1) * mPageSize; i < page * mPageSize && i < mItemList.Count; i++)
            {
                itemList.Add(mItemList[i]);
            }
            return itemList;
        }

        public bool ModData(DBItem item)
        {
            if (mDBMng.SaveParserResult(mModTable, item))
            {
                for (int i = 0; i < mItemList.Count; i++)
                {
                    if (mItemList[i].mId == item.mId)
                    {
                        mItemList[i] = item;
                    }
                }
                mModIdToItemMap[item.mId] = item;
                if (item.mType == "债券报价")
                {
                    if (mIdDeal.Contains(item.mId))
                        ScreenDealToday();
                    else
                        ScreenBondQuoteInfo();
                }
                if (item.mType == "线上资金报价")
                {
                    ScreenOnlineQuoteInfo();
                }      
                return true;
            }
            else
            {
                return false;
            }
        }

        public int GetTotalPageNum()
        {
            if (mItemList.Count % mPageSize == 0)
            {
                return mItemList.Count / mPageSize;
            }
            else
            {
                return (mItemList.Count / mPageSize) + 1;
            }
        }
        
        //债券总页数
        public int GetTotalBondQuotePage()
        {
            if (itemBondQuoteList.Count % mPageSize == 0)
            {
                return itemBondQuoteList.Count / mPageSize;
            }
            else 
            { 
                return (itemBondQuoteList.Count / mPageSize) + 1;
            }
            
        }

        //线上资金总页数
        public int GetTotalOnlineQuotePage()
        {
            if (itemOnlineQuoteList.Count % mPageSize == 0)
            {
                return itemOnlineQuoteList.Count / mPageSize;
            }
            else
            {
                return (itemOnlineQuoteList.Count / mPageSize) + 1;
            }

        }

        //今日成交总页数
        public int GetTotalDealPage()
        {
            if (itemDealQuoteList.Count % mPageSize == 0)
            {
                return itemDealQuoteList.Count / mPageSize;
            }
            else
            {
                return (itemDealQuoteList.Count / mPageSize) + 1;
            }

        }

        public void LoopTest(ETestType type, out List<DBItem> autoItemList, out List<DBItem> modItemList, out int total, out int matchNum)
        {
            autoItemList = new List<DBItem>();
            modItemList = new List<DBItem>();
            total = 0;
            matchNum = 0;

            foreach (DBItem item in mAutoItemList)
            {
                if (mModIdToItemMap.ContainsKey(item.mId))
                {
                    DBItem markItem = mModIdToItemMap[item.mId];
                    if (type == ETestType.TestType_Classify)
                    {
                        total++;
                        if (markItem.mType.Equals(item.mType))
                        {
                            matchNum++;
                        }
                        else
                        {
                            autoItemList.Add(item);
                            modItemList.Add(markItem);
                        }
                    }
                    else if (type == ETestType.TestType_BondQuote)
                    {
                        if (markItem.mType.Equals(Util.gBondQuote)
                            && markItem.mStatu.Equals(Util.gCheckQuoteStatu))
                        {
                            Parsing.QuoteRsp rspMod = null,rspAuto=null;
                            rspMod = Parsing.QuoteRsp.ParseFrom(markItem.mData);
                            rspAuto = Parsing.QuoteRsp.ParseFrom(item.mData);
                            total += rspMod.BondQuoteListList.Count;
                            
                             //  total++;//原始直接比较一条大消息
                            //if (markItem.mType.Equals(item.mType)
                            //    && Util.IsQuoteEqual(markItem.mData, item.mData))
                            //{
                            //    matchNum++;//原始匹配
                            //}

                            #region 两者的报价类型一致
                            if (markItem.mType.Equals(item.mType))
                            {
                                if (Util.IsQuoteEqual(markItem.mData, item.mData))
                                {
                                    matchNum += rspMod.BondQuoteListList.Count;
                                }
                                else
                                {
                                    autoItemList.Add(item);
                                    modItemList.Add(markItem);

                                    //单条消息，多条报价比较
                                    for (int i = 0; i < rspMod.BondQuoteListList.Count; i++)
                                    {
                                        for (int j = 0; j < rspAuto.BondQuoteListList.Count; j++)
                                        {
                                            if (Util.IsEqual(rspMod.BondQuoteListList[i], rspAuto.BondQuoteListList[j]))
                                            {
                                                matchNum++;
                                                break;
                                            }
                                        }
                                    }
                                    //自动解析多出的
                                    if (rspMod.BondQuoteListList.Count < rspAuto.BondQuoteListList.Count)
                                    {
                                        matchNum = matchNum - (rspAuto.BondQuoteListList.Count - rspMod.BondQuoteListList.Count);
                                    }
                                }
                            }
                            #endregion
                            else
                            {
                                autoItemList.Add(item);
                                modItemList.Add(markItem);
                            }
                        }
                    }
                    else if (type == ETestType.TestType_OnlineQuote)
                    {
                        if (markItem.mType.Equals(Util.gOnlineQuote)
                            && markItem.mStatu.Equals(Util.gCheckQuoteStatu))
                        {
                            Parsing.QuoteRsp rspMod = null, rspAuto = null;
                            rspMod = Parsing.QuoteRsp.ParseFrom(markItem.mData);
                            rspAuto = Parsing.QuoteRsp.ParseFrom(item.mData);
                            total += rspMod.MmQuoteListList.Count;
                          
                            if (markItem.mType.Equals(item.mType))
                            {
                                if (Util.IsQuoteEqual(markItem.mData, item.mData))
                                {
                                    matchNum += rspMod.MmQuoteListList.Count;
                                }
                                else 
                                {
                                    autoItemList.Add(item);
                                    modItemList.Add(markItem);

                                    //单条消息，多条报价比较
                                    for (int i = 0; i < rspMod.MmQuoteListList.Count; i++)
                                    {
                                        for (int j = 0; j < rspAuto.MmQuoteListList.Count; j++)
                                        {
                                            if (Util.IsEqual(rspMod.MmQuoteListList[i], rspAuto.MmQuoteListList[j]))
                                            {
                                                matchNum++;
                                                break;
                                            }
                                        }
                                    }
                                    //自动解析多出的
                                    if (rspMod.MmQuoteListList.Count < rspAuto.MmQuoteListList.Count)
                                    {
                                        matchNum = matchNum - (rspAuto.MmQuoteListList.Count - rspMod.MmQuoteListList.Count);
                                    }
                                }
                            }
                            else
                            {
                                autoItemList.Add(item);
                                modItemList.Add(markItem);
                            }
                        }
                    }
                }
            }
        }

        public void GetContrastData(long id, ref DBItem autoItem, ref DBItem modItem)
        {
            foreach (DBItem item in mAutoItemList)
            {
                if (item.mId == id)
                {
                    autoItem = item;
                }
            }
            if (mModIdToItemMap.ContainsKey(id))
            {
                modItem = mModIdToItemMap[id];
            }
        }

        public Dictionary<long, string> LoadQQMsgText()
        {
            MysqlManager srcMng = new MysqlManager(Config.DefaultInstance.mSrcHost,
                Config.DefaultInstance.mSrcDbName, Config.DefaultInstance.mSrcUserName,
                Config.DefaultInstance.mSrcPassWord);
            Dictionary<long, byte[]> dataMap = srcMng.LoadQQMessage(0, 10000000, true);
            srcMng.Close();

            Dictionary<long, string> idToMsgMap = new Dictionary<long, string>();
            if (null != dataMap)
            {
                foreach (long id in dataMap.Keys)
                {
                    try
                    {
                        QQServer.PubReciveMessage pubMsg = QQServer.PubReciveMessage.ParseFrom(dataMap[id]);
                        idToMsgMap[id] = Util.GetMsgText(pubMsg);
                    }
                    catch (System.Exception)
                    { }
                }
            }
            return idToMsgMap;
        }
       
        //筛选债券报价
        public List<DBItem> ScreenBondQuoteInfo()
        {
            itemBondQuoteList.Clear();
            foreach (DBItem item in mItemList)
            {
                if (item.mType == "债券报价")
                {
                    itemBondQuoteList.Add(item);
                }
            }
            return itemBondQuoteList;
        }

        //筛选线上资金报价
        public List<DBItem> ScreenOnlineQuoteInfo()
        {
            itemOnlineQuoteList.Clear();
            foreach (DBItem item in mItemList)
            {
                if (item.mType == "线上资金报价")
                {
                    itemOnlineQuoteList.Add(item);
                }
            }
            return itemOnlineQuoteList;
        }

        //筛选今日成交
        public List<DBItem> ScreenDealToday()
        {
            itemDealQuoteList.Clear();
            foreach (DBItem item in mItemList)
            {
                if (mIdDeal.Contains(item.mId))
                {
                    itemDealQuoteList.Add(item);
                }
            }
            return itemDealQuoteList;
        }

        //设置债券页数
        public List<DBItem> GetPageBondQuoteData(int page)
        {

            if (page <= 0 || itemBondQuoteList.Count <= (page - 1) * mPageSize)
            {
                return null;
            }
            List<DBItem> itemList = new List<DBItem>();
            for (int i = (page - 1) * mPageSize; (i < page * mPageSize) && (i < itemBondQuoteList.Count); i++)
            {
                itemList.Add(itemBondQuoteList[i]);
            }
            return itemList;
        }

        //设置线上资金页数
        public List<DBItem> GetPageOnlineQuoteData(int page)
        {

            if (page <= 0 || itemOnlineQuoteList.Count <= (page - 1) * mPageSize)
            {
                return null;
            }
            List<DBItem> itemList = new List<DBItem>();
            for (int i = (page - 1) * mPageSize; (i < page * mPageSize) && (i < itemOnlineQuoteList.Count); i++)
            {
                itemList.Add(itemOnlineQuoteList[i]);
            }
            return itemList;
        }

        //设置今日成交页数
        public List<DBItem> GetPageDealData(int page)
        {

            if (page <= 0 || itemDealQuoteList.Count <= (page - 1) * mPageSize)
            {
                return null;
            }
            List<DBItem> itemList = new List<DBItem>();
            for (int i = (page - 1) * mPageSize; (i < page * mPageSize) && (i < itemDealQuoteList.Count); i++)
            {
                itemList.Add(itemDealQuoteList[i]);
            }
            return itemList;
        }

        public List<DBItem> Get()
        {
            return mAutoItemList;
        }

        public List<long> getModMap()
        {
            List<long> mModList = new List<long>();

            foreach (long id in mModIdToItemMap.Keys)
            {
                mModList.Add(id); 
            }
            return mModList;
        }

        MysqlManager mDBMng;
        List<long> mIdDeal=new List<long>();                         //今日成交
        List<DBItem> mItemList = new List<DBItem>();                 //合集
    //    List<DBItem> mAutoItemList = new List<DBItem>();           //删除重复的auto
        List<DBItem> mAutoItemList = new List<DBItem>();             //自动解析的报价列表
        List<DBItem> itemBondQuoteList = new List<DBItem>();         //债券报价集合
        List<DBItem> itemOnlineQuoteList = new List<DBItem>();       //线上资金报价集合
        List<DBItem> itemDealQuoteList = new List<DBItem>();         //今日成交报价集合
        Dictionary<long, DBItem> mModIdToItemMap = new Dictionary<long, DBItem>();//修改过的报价列表
    }
}
