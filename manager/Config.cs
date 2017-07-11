using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MsgExpress;
using System.Xml;

namespace QuoteClassify.manager
{
    class Config
    {
        public static Config DefaultInstance = new Config("../config");

        const string mFileName = "dbcfg.xml";
        public string mSrcHost = "";               // QQ消息存储的目标主机
        public string mSrcDbName = "";             // 目标数据库名
        public string mSrcUserName = "";           // 目标用户名
        public string mSrcPassWord = "";           // 目标密码
        public string mDisHost = "";               // 解析结果存储主机
        public string mDisDbName = "";             // 存储数据库
        public string mDisUserName = "";           // 存储用户名
        public string mDisPassWord = "";           // 存储密码


        public Config(string cfgPath)
        {
            LoadConfig(cfgPath);
        }

        bool LoadConfig(string cfgPath)
        {
            if (!cfgPath.EndsWith("/") && !cfgPath.EndsWith("\\"))
            {
                cfgPath += "/";
            }
            Logger.Info("Load Config file, cfgPath = " + cfgPath);

            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.Load(cfgPath + mFileName);
            }
            catch (System.Exception ex)
            {
                Logger.Error("Load config failed, config = " + cfgPath + mFileName);
                Logger.Error(ex.ToString());
                return false;
            }

            XmlNode root = xmlDoc.SelectSingleNode("configuration");
            if (null == root)
            {
                Logger.Error("Get configuration node failed, filePath = " + cfgPath + mFileName);
                return false;
            }

            XmlNode srcNode = root.SelectSingleNode("Src");
            if (null == srcNode)
            {
                Logger.Error("Get src node failed, filePath = " + cfgPath + mFileName);
                return false;
            }
            mSrcHost = srcNode.Attributes["host"].Value;
            mSrcDbName = srcNode.Attributes["dbName"].Value;
            mSrcUserName = srcNode.Attributes["userName"].Value;
            mSrcPassWord = srcNode.Attributes["passWord"].Value;

            XmlNode disNode = root.SelectSingleNode("Dis");
            if (null == disNode)
            {
                Logger.Error("Get Dis node failed, filePath = " + cfgPath + mFileName);
                return false;
            }
            mDisHost = disNode.Attributes["host"].Value;
            mDisDbName = disNode.Attributes["dbName"].Value;
            mDisUserName = disNode.Attributes["userName"].Value;
            mDisPassWord = disNode.Attributes["passWord"].Value;

            return true;
        }

    }
}
