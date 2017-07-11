using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using QuoteClassify.manager;
using MsgExpress;


namespace QuoteClassify
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Logger.Init(null);
            //Config cfg = new Config("../config/");
            //MysqlManager disMng = new MysqlManager(cfg.mDisHost, cfg.mDisDbName,
            //    cfg.mDisUserName, cfg.mDisPassWord);

            //List<string> itemList = new List<string>();
            //itemList.Add("test1");
            //itemList.Add("test4");
            //itemList.Add("test2");
            //itemList.Add("test3");
            //string str=itemList[3];

            //DBItem item = new DBItem();
            //item.mId = 100;
            //item.mDateTime = "2017-04-07";
            //item.mMsgText = "测试文本！";
            //item.mWords = "测试单纯";
            //item.mType = "显示";
            //item.mData = new byte[2];
            //item.mData[0] = 10;
            //item.mData[1] = 20;
            //HashSet<string> item = new HashSet<string>();
            //item.Add("f");
            //item.Add("u");
            //item.Add("n");
            //item.Add("f");

           
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ManagerForm());         
        }
    }
}
