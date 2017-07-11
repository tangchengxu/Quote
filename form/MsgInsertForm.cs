using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MsgExpress.databus;
using MsgExpress;
using QuoteClassify.manager;
using Google.ProtocolBuffers;


namespace QuoteClassify.form
{
    public partial class MsgInsertForm : Form
    {
        bool bOk = false;

        public MsgInsertForm()
        {
            InitializeComponent();
        }

        // 是否确认
        public bool IsOK()
        {
            return bOk;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (textBoxMsg.Text.Replace(" ", "")== "" || textBoxMsg.Text == null)
            {
                this.Close();
                mDataBus.Release();
                return;
            }
            else
            {
                InsertQuote();         //插入一条报价到数据库
                ParsingInsertData();   //解析插入的单条数据
                saveInsertData();
                bOk = true;
                this.Close();
                mDataBus.Release(); 
            }           
        }

        public void InsertQuote()
        {

            string connectionString = "Database='" + dbName + "';Data Source='" + host
                + "';User Id='" + userName + "';Password='" + passWord
                + "';charset='utf8';pooling=true";

            MySqlConnection mMysqlCon = new MySqlConnection(connectionString);
            if (mMysqlCon.State != ConnectionState.Open)
            {
                try
                {
                    mMysqlCon.Open();
                }
                catch (System.Exception ex)
                {
                    Logger.Error("Insert database open failed : " + ex.StackTrace);
                    return ;
                }
            }
            string sql = "REPLACE INTO localmessageinfo"  + "(id,fromUin,time,msg)"
                   + " VALUES(@ID,@FromUin,@Time,@Msg)";
            MySqlCommand mysqlcom = new MySqlCommand(sql, mMysqlCon);

            string str = textBoxMsg.Text;
            byte[] msgData;
            QQServer.PubReciveMessage.Builder pubMsg = new QQServer.PubReciveMessage.Builder();
            TimeSpan ts = DateTime.Now - DateTime.Parse("1970-1-1 00:00:00");
            spanTime = ts.Ticks / 10000; //10000 即为当前时间的总毫秒值;
            pubMsg.FromUin = "1111";
            pubMsg.Time = spanTime;

            QQServer.QQMessage.Builder msgBuild = new QQServer.QQMessage.Builder();
            msgBuild.MsgType = 0;
            msgBuild.Content = ByteString.CopyFromUtf8(str);
            pubMsg.AddMsg(msgBuild);
            msgData = pubMsg.Build().ToByteArray();

            try
            {
                mysqlcom.Parameters.AddWithValue("@ID",null);
                mysqlcom.Parameters.AddWithValue("@FromUin", "11111111");
                mysqlcom.Parameters.AddWithValue("@Time", spanTime);
                mysqlcom.Parameters.AddWithValue("@Msg", msgData);
                mysqlcom.ExecuteNonQuery();
            }
            catch (System.Exception ex)
            {
                Logger.Error("单条消息插入失败"+ex.StackTrace);
                mysqlcom.Dispose();
                return ;
            }
            mysqlcom.Dispose();
            mMysqlCon.Close();
            mMysqlCon.Dispose();
        }

        public void ParsingInsertData()
        {
            string msgText = textBoxMsg.Text.ToString();
            rsp = mDataBus.TestParser(msgText);
        }

        //保存到解析数据库
        public void saveInsertData()
        {
            DBItem item = new DBItem();
            string type = Util.GetType(rsp);
            item.mDateTime = Util.FromatTime1(spanTime);
            item.mType = type;
            item.mData = rsp.ToByteArray();
            item.mMsgText = textBoxMsg.Text.ToString();

            //插入解析数据库
            string connectionString = "Database='" + dbName + "';Data Source='" + host
                + "';User Id='" + userName + "';Password='" + passWord
                + "';charset='utf8';pooling=true";

            MySqlConnection mMysqlCon = new MySqlConnection(connectionString);
            if (mMysqlCon.State != ConnectionState.Open)
            {
                try
                {
                    mMysqlCon.Open();
                }
                catch (System.Exception ex)
                {
                    Logger.Error("database open failed : " + ex.StackTrace);
                    return;
                }
            }
            //查出最后一个记录的id值
            long idSelect=0;
            string sqlSelect = "select * from localmessageinfo order by id desc limit 1";
            MySqlCommand mysqlcomSelect = new MySqlCommand(sqlSelect, mMysqlCon);
            MySqlDataReader reader = mysqlcomSelect.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        idSelect = reader.GetInt32(0);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error("reader failed : " + ex.StackTrace);
                reader.Close();
                mysqlcomSelect.Dispose();
            }
            reader.Close();
            mysqlcomSelect.Dispose();

            string sql = "REPLACE INTO  quoteclassify_auto" + "(id,time,quotetype,parser,statu)"
                    + " VALUES(@ID,@Time,@QuoteType,@Parser,@Statu)";
            MySqlCommand mysqlcom = new MySqlCommand(sql, mMysqlCon);
            try
            {
                mysqlcom.Parameters.AddWithValue("@ID", idSelect);
                mysqlcom.Parameters.AddWithValue("@Time", item.mDateTime);
                mysqlcom.Parameters.AddWithValue("@QuoteType", item.mType);
                mysqlcom.Parameters.AddWithValue("@Parser", item.mData);
                mysqlcom.Parameters.AddWithValue("@Statu", item.mStatu);
                mysqlcom.ExecuteNonQuery();
            }
            catch (System.Exception ex)
            {
                Logger.Error("单条消息插入失败" + ex.StackTrace);
                mysqlcom.Dispose();
                return;
            }
            mysqlcom.Dispose();
            mMysqlCon.Close();
            mMysqlCon.Dispose();
        }

        DataBus mDataBus = new DataBus();
        Parsing.QuoteRsp rsp = null;
        long spanTime = 0;
        string host = Config.DefaultInstance.mSrcHost;
        string dbName = Config.DefaultInstance.mSrcDbName;
        string userName = Config.DefaultInstance.mSrcUserName;
        string passWord = Config.DefaultInstance.mSrcPassWord;
    }
}
