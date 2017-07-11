using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MsgExpress.databus;
using MsgExpress;
using System.Threading;

namespace QuoteClassify.manager
{

    class DataBus
    {
        public DataBus()
        {
            mDataBus = new DataBusManager();
            mDataBus.Initialize(null);
            Thread.Sleep(2000);
        }

        public void Release()
        {
            mDataBus.Release();
        }

        public Parsing.QuoteRsp ParserText(string text, string fromQQ, string toQQ, string date)
        {
            Parsing.QuoteReq.Builder build = new Parsing.QuoteReq.Builder();
            build.Quote = text;
            build.FromQQ = fromQQ;
            build.ToQQ = toQQ;
            build.Date = date;

            object obj = mDataBus.SendMessage(build.Build(), mTimeOut, null);
            if (null == obj)
            {
                Logger.Error("Send QuoteReq Failed!");
                return null;
            }
            Parsing.QuoteRsp rsp = obj as Parsing.QuoteRsp;
            return rsp;
        }

        public bool PostParserText(string text, string fromQQ, string toQQ, string date, 
            ResponseEventHandle handle, object arg)
        {
            Parsing.QuoteReq.Builder build = new Parsing.QuoteReq.Builder();
            build.Quote = text;
            build.FromQQ = fromQQ;
            build.ToQQ = toQQ;
            build.Date = date;

            return mDataBus.PostMessage(build.Build(), handle, arg, mTimeOut, null);
        }

        public Parsing.QuoteRsp TestParser(string msgText)
        {
            Parsing.QuoteReq.Builder build = new Parsing.QuoteReq.Builder();
            build.Quote = msgText;

            object obj = mDataBus.SendMessage(build.Build(), 5000, null);
            if (null == obj)
            {
                Logger.Error("Parsing message failed!");
                return null;
            }
            Parsing.QuoteRsp rsp = obj as Parsing.QuoteRsp;
            string strRsp = rsp.ToString();

            return rsp;
        }

        DataBusManager mDataBus;
        const int mTimeOut = 10000;
    }
}
