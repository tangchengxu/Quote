using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using MsgExpress;
using System.Data;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace QuoteClassify.manager
{
    [Serializable]
    class DBItem
    {
        // 构造一个新对象 深拷贝
        public DBItem DeepCopy()
        {
            object newObj;
            using (MemoryStream ms = new MemoryStream())
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(ms, this);
                ms.Seek(0, SeekOrigin.Begin);
                newObj = bf.Deserialize(ms);
                ms.Close();
            }
            return newObj as DBItem;
        }

        public long mId = 0;                      // 消息ID
        public string mDateTime;                  // 消息发送时间
        public string mType;                      // 报价类型
        public byte[] mData;                      // 报价解析结果
        public string mStatu = "自动解析";        // 修改状态
        public string mMsgText = null;            // 原始文本
    }

    class MysqlManager
    {
        public MysqlManager(string host, string dbName, string userName, string passWord)
        {
            string connectionString = "Database='" + dbName + "';Data Source='" + host
                + "';User Id='" + userName + "';Password='" + passWord
                + "';charset='utf8';pooling=true";

            mDbName = dbName;
            mMysqlCon = new MySqlConnection(connectionString);
        }

        // 获取QQ消息总条数
        public int GetQQMsgNum(bool bAll=true)
        {
            string sql;
            if (bAll)
            {
                sql = "select count(*) from localmessageinfo";
            }
            else
            {
                sql = "select count(*) from quoteclassify_mod";
            }
            MySqlDataReader mysqlread = QueryData(sql);
           // MySqlDataReader mysqlread = QueryData("select count(*) from localmessageinfo");
            while (mysqlread.Read())
            {
                int totalNum = mysqlread.GetInt32(0);
                mysqlread.Close();
                return totalNum;
            }
            return 0;
        }

        // 从数据加载QQ消息
        public Dictionary<long, byte[]> LoadQQMessage(int start, int limit, bool bAll=true)
        {
            string sql;
            if (bAll)
            {
                sql = "select id,msg from localmessageinfo limit " + start + "," + limit;
            }
            else
            {
                sql = "select id,msg from localmessageinfo where id in ( select id from quoteclassify_mod ) limit " + start + "," + limit;
            }
            MySqlDataReader mysqlread = QueryData(sql);

      //    MySqlDataReader mysqlread = QueryData("select id,msg from localmessageinfo");
            if (null == mysqlread)
            {
                return null;
            }
            Dictionary<long, byte[]> dataMap = new Dictionary<long, byte[]>();
            while (mysqlread.Read())
            {
                long id = mysqlread.GetInt64(0);
                byte[] msgData = mysqlread.GetValue(1) as byte[];
                dataMap[id] = msgData;
            }
            mysqlread.Close();

            return dataMap;
        }

        //删除数据库重复数据
        //public void DelDBParser(long id)
        //{
        //    string sql = "delete from localmessageinfo where id= " + id + " and id not in ( select id from quoteclassify_mod )";
        //    MySqlDataReader mysqlread = QueryData(sql);
        //    mysqlread.Close();
        //}
        public bool DelDBParser()
        {
            string sql = "delete from localmessageinfo where id=@ID ";
            if (mMysqlCon.State != ConnectionState.Open)
            {
                try
                {
                    mMysqlCon.Open();
                }
                catch (System.Exception ex)
                {
                    Logger.Error("DelSameParser Failed : " + ex.StackTrace);
                    return false;
                }
            }

            MySqlTransaction tx = mMysqlCon.BeginTransaction();
            MySqlCommand mysqlcom = new MySqlCommand(sql, mMysqlCon);
            mysqlcom.Transaction = tx;

            DataManager mDataMng = new DataManager();
            Dictionary<long, string> idToMsgMap = mDataMng.LoadQQMsgText();
            List<long> idModMap = mDataMng.getModMap();
            HashSet<string> DelRepeat = new HashSet<string>();
            int count = 0,totalNum=0;
           
            try
            {
                foreach (long key in idToMsgMap.Keys)
                {
                    string str = idToMsgMap[key].ToString().Trim();
                    totalNum++;
                    if ((DelRepeat.Add(str.Trim()) == false) && (idModMap.Contains(key) == false))
                    {
                        mysqlcom.Parameters.Clear();
                        mysqlcom.Parameters.AddWithValue("@ID", key);
                        mysqlcom.ExecuteNonQuery();
                        count++;
                        if (count > 0 && count % 600 == 0 )
                        {
                            tx.Commit();
                            tx = mMysqlCon.BeginTransaction();
                            mysqlcom.Transaction = tx;
                        }  
                    }
                    if (totalNum == idToMsgMap.Count)
                    {
                        tx.Commit();
                        tx = mMysqlCon.BeginTransaction();
                        mysqlcom.Transaction = tx;
                    }
                }
                mysqlcom.Dispose();
            }
            catch (System.Exception ex)
            {
                Logger.Error(ex.StackTrace);
                return false;
            }
            return true;
        }

        // 存储单条报价
        public bool SaveParserResult(string tableName, DBItem item)
        {
            lock (this)
            {
                if (mMysqlCon.State != ConnectionState.Open)
                {
                    try
                    {
                    	mMysqlCon.Open();
                    }
                    catch (System.Exception ex)
                    {
                        Logger.Error("SaveParserResult Failed : " + ex.StackTrace);
                        return false;
                    }
                }

                string sql = "REPLACE INTO " + tableName + "(id,time,quotetype,parser,statu)" 
                    + " VALUES(@ID,@Time,@QuoteType,@Parser,@Statu)";
                MySqlCommand mysqlcom = new MySqlCommand(sql, mMysqlCon);

                try
                {
                    mysqlcom.Parameters.AddWithValue("@ID", item.mId);
                    mysqlcom.Parameters.AddWithValue("@Time", item.mDateTime);
                    mysqlcom.Parameters.AddWithValue("@QuoteType", item.mType);
                    mysqlcom.Parameters.AddWithValue("@Parser", item.mData);
                    mysqlcom.Parameters.AddWithValue("@Statu", item.mStatu);
                    mysqlcom.ExecuteNonQuery();
                }
                catch (System.Exception ex)
                {
                    Logger.Error(ex.StackTrace);
                    mysqlcom.Dispose();
                    return false;
                }
                mysqlcom.Dispose();
                return true;
            }
        }

        // 存储报价解析结果
        public bool SaveParserResults(string tableName, List<DBItem> itemList)
        {
            string sql = "REPLACE INTO " + tableName + "(id,time,quotetype,parser,statu)"
                    + " VALUES(@ID,@Time,@QuoteType,@Parser,@Statu)";
            if (mMysqlCon.State != ConnectionState.Open)
            {
                try
                {
                    mMysqlCon.Open();
                }
                catch (System.Exception ex)
                {
                    Logger.Error("SaveParserResults Failed : " + ex.StackTrace);
                    return false;
                }
            }

            MySqlTransaction tx = mMysqlCon.BeginTransaction();
            MySqlCommand mysqlcom = new MySqlCommand(sql, mMysqlCon);
            mysqlcom.Transaction = tx;
            try
            {
                for (int i = 0; i < itemList.Count; i++)
                {
                    mysqlcom.Parameters.Clear();
                    mysqlcom.Parameters.AddWithValue("@ID", itemList[i].mId);
                    mysqlcom.Parameters.AddWithValue("@Time", itemList[i].mDateTime);
                    mysqlcom.Parameters.AddWithValue("@QuoteType", itemList[i].mType);
                    mysqlcom.Parameters.AddWithValue("@Parser", itemList[i].mData);
                    mysqlcom.Parameters.AddWithValue("@Statu", itemList[i].mStatu);

                    mysqlcom.ExecuteNonQuery();
                    if ((i > 0 && i % 200 == 0) || i == itemList.Count - 1)
                    {
                        tx.Commit();
                        if (i < itemList.Count - 1)
                        {
                            tx = mMysqlCon.BeginTransaction();
                            mysqlcom.Transaction = tx;
                        }
                    }
                }
                mysqlcom.Dispose();
            }
            catch (System.Exception ex)
            {
                Logger.Error(ex.StackTrace);
                return false;
            }
            return true ;
        }

        // 获取报价解析结果
        public List<DBItem> GetParserResults(string tableName)
        {
            MySqlDataReader mysqlread = QueryData("select id,time,quotetype,parser,statu from " + tableName);
            if (null == mysqlread)
            {
                return null;
            }
            List<DBItem> itemList = new List<DBItem>();
            while (mysqlread.Read())
            {
                DBItem item = new DBItem();
                item.mId = mysqlread.GetInt64("id");
                item.mDateTime = mysqlread.GetString("time");
                item.mType = mysqlread.GetString("quotetype");
                item.mData = mysqlread.GetValue(3) as byte[];
                item.mStatu = mysqlread.GetString("statu");

                /********************* 兼容老数据 *********************/
                if (item.mStatu.Equals(Util.gOKStatu) 
                    || item.mStatu.Equals(Util.gModStatu))
                {
                    item.mStatu = Util.gCheckQuoteStatu;
                }
                if (!item.mType.Equals(Util.gNoQuote) && 
                    (item.mData == null || item.mData.Length == 0))
                {
                    item.mStatu = Util.gCheckTypeStatu;
                }
                /********************* 兼容老数据 *********************/

                itemList.Add(item);
            }
            mysqlread.Close();
            return itemList;
        }

        // 获取数据库表列表
        public List<string> GetTableList()
        {
            string sql = "select table_name from information_schema.tables where table_schema='"
                + mDbName + "' and table_type='base table'";
            MySqlDataReader msdr = this.QueryData(sql);
            if (null == msdr)
            {
                Logger.Error("GetTableList Failed!");
                return null;
            }
            List<string> tableList = new List<string>();
            while (msdr.Read())
            {
                tableList.Add(msdr.GetString(0));
            }
            msdr.Close();
            return tableList;
        }

        // 创建报价解析存储表
        public bool CreateSaveTable(string tableName)
        {
            if (mMysqlCon.State != ConnectionState.Open)
            {
                try
                {
                    mMysqlCon.Open();
                }
                catch (System.Exception ex)
                {
                    Logger.Error("Open failed, " + ex.StackTrace);
                    return false;
                }
            }

            string sql = @"CREATE TABLE `" + tableName + @"` (
                `id` bigint(20) NOT NULL COMMENT '唯一消息ID',
            `time` datetime DEFAULT NULL COMMENT '消息发送时间',
            `quotetype` varchar(64) DEFAULT NULL COMMENT '报价类型',
            `parser` blob COMMENT '解析结果',
            `statu` varchar(64) DEFAULT NULL,
                PRIMARY KEY (`id`)
            ) ENGINE=InnoDB DEFAULT CHARSET=utf8;";
 
            try
            {
                MySqlCommand mysqlcom = new MySqlCommand(sql, mMysqlCon);
                if (mysqlcom.ExecuteNonQuery() > 0)
                {
                    mysqlcom.Dispose();
                    return true;
                }
                else
                {
                    mysqlcom.Dispose();
                    return false;
                }
            }
            catch (System.Exception ex)
            {
                Logger.Error(ex.StackTrace);
                return false;
            }
        }

        // 关闭数据库连接
        public void Close()
        {
            mMysqlCon.Close();
            mMysqlCon.Dispose();
        }

        // 查询数据库
        MySqlDataReader QueryData(string sql)
        {
            lock (this)
            {
                try
                {
                    if (mMysqlCon.State != ConnectionState.Open)
                    {
                        mMysqlCon.Open();
                    }

                    MySqlCommand mysqlcom = new MySqlCommand(sql, mMysqlCon);
                    MySqlDataReader mysqlread = mysqlcom.ExecuteReader();

                    return mysqlread;
                }
                catch (System.Exception ex)
                {
                    Logger.Error("Load Db error : " + ex.ToString());
                    return null;
                }
            }
        }

        // 执行SQL语句
        public bool ExecuteSql(string sql)
        {
            try
            {
                if (mMysqlCon.State != ConnectionState.Open)
                {
                    mMysqlCon.Open();
                }

                MySqlCommand mysqlcom = new MySqlCommand(sql, mMysqlCon);
                if (mysqlcom.ExecuteNonQuery() > 0)
                {
                    mysqlcom.Dispose();
                    return true;
                }
                else
                {
                    mysqlcom.Dispose();
                    Logger.Error("ExecuteSql failed, sql = " + sql);
                    return false;
                }
            }
            catch (System.Exception ex)
            {
                Logger.Error("Write Db error : " + ex.ToString() + " \r\nsql = " + sql);
                return false;
            }
        }

        string mDbName;
        MySqlConnection mMysqlCon;
    }
}
