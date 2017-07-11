using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using MsgExpress;

namespace QuoteClassify.manager
{
    static class Util
    {
        public const string gOnlineQuote = "线上资金报价";
        public const string gBondQuote = "债券报价";
        public const string gRangeQuote = "范围报价";
        public const string gOtherQuote = "其它报价";
        public const string gNoQuote = "不是报价";

        public const string gIdleStatu = "自动解析";
        public const string gCheckTypeStatu = "已确认分类";
        public const string gCheckQuoteStatu = "已确认报价";

        /*********************** 已过期的状态 **************************/
        public const string gOKStatu = "已确认";
        public const string gModStatu = "已修改";
        /*********************** 已过期的状态 **************************/

        const long gTimeOff = 8 * 60 * 60 * 1000;

        // 获取消息文本
        public static string GetMsgText(QQServer.PubReciveMessage msg)
        {
            string text = "";
            foreach (QQServer.QQMessage qqMsg in msg.MsgList)
            {
                if (qqMsg.MsgType == 0)
                {
                    text += qqMsg.Content.ToStringUtf8();
                }
                else
                {
                    text += "  ";
                }
            }
            return text;
        }

        public static string FormatTime(long time)
        {
            return DateTime.Parse("1970-1-1").AddMilliseconds(time + gTimeOff).ToString();
        }

        public static string FormatDate(long time)
        {
            return DateTime.Parse("1970-1-1").AddMilliseconds(time + gTimeOff).ToString("yyyy-MM-dd hh:mm:ss");
        }

        public static string FromatTime1(long time)
        {
            //var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            //return epoch.AddMilliseconds(time).ToString();
            return DateTime.Parse("1970-1-1").AddMilliseconds(time).ToString();
        }

        public static string GetType(Parsing.QuoteRsp rsp)
        {
            if (null == rsp)
            {
                return gNoQuote;
            }

            if (rsp.MmQuoteListCount > 0)
            {
                return gOnlineQuote;
            }
            else if (rsp.BondQuoteListCount > 0)
            {
                return gBondQuote;
            }
            else if (rsp.RangeQuoteListCount > 0)
            {
                return gRangeQuote;
            }
            else if (rsp.HasOtherQuote)
            {
                return gOtherQuote;
            }
            else
            {
                return gNoQuote;
            }
        }

        public static void GetQuoteWordAndType(Parsing.QuoteRsp rsp, out string words, out string type)
        {
            words = "";
            type = "";
            if (null == rsp)
                return;
            
            if (rsp.MmQuoteListCount > 0)
            {
                type = gOnlineQuote;
                foreach (Parsing.QuoteInfo info in rsp.MmQuoteListList)
                {
                    if (words.Length > 0)
                    {
                        words += "|";
                    }
                    words += string.Join(",", info.WordsList);
                }
            }
            else if (rsp.BondQuoteListCount > 0)
            {
                type = gBondQuote;
                foreach (Parsing.BondQuoteInfo info in rsp.BondQuoteListList)
                {
                    if (words.Length > 0)
                    {
                        words += "|";
                    }
                    words += string.Join(",", info.WordsList);
                }
            }
            else if (rsp.RangeQuoteListCount > 0)
            {
                type = gRangeQuote;
                foreach (Parsing.RangeBondQuote info in rsp.RangeQuoteListList)
                {
                    if (words.Length > 0)
                    {
                        words += "|";
                    }
                    words += string.Join(",", info.WordsList);
                }
            }
            else if (rsp.HasOtherQuote)
            {
                type = gOtherQuote;
                words = string.Join(",", rsp.OtherQuote.WordsList);
            }
            else
            {
                type = gNoQuote;
            }
        }

        public static string CreateSaveTableName()
        {
            return "quoteclassify" + DateTime.Now.ToString("yyyyMMddHHmmss");
        }

        public static Color GetLineColor(DBItem item)
        {
            if (item.mStatu.Equals(gIdleStatu))
            {
                return Color.White;
            }
            else if (item.mStatu.Equals(gCheckTypeStatu))
            {
                return Color.Yellow;
            }
            else if (item.mStatu.Equals(gCheckQuoteStatu))
            {
                return Color.Green;
            }
            else
            {
                return Color.AliceBlue;
            }
        }

        // 比较两个报价解析是否相等
        public static bool IsQuoteEqual(byte[] bt1, byte[] bt2)
        {
            if (null == bt1 || null == bt2)
            {
                return false;
            }
            if (IsEqual(bt1, bt2))
            {
                return true;
            }
            try
            {
                Parsing.QuoteRsp result1 = Parsing.QuoteRsp.ParseFrom(bt1);
                Parsing.QuoteRsp result2 = Parsing.QuoteRsp.ParseFrom(bt2);

                return IsEqual(result1, result2);
            }
            catch (System.Exception ex)
            {
                Logger.Error(ex.StackTrace);
                return false;
            }
        }

        // 比较两个字节数组是否相等
        public static bool IsEqual(byte[] bt1, byte[] bt2)
        {
            if (null == bt1 && null == bt2)
            {
                return true;
            }
            else if (null == bt1 || null == bt2)
            {
                return false;
            }

            if (bt1.Length != bt2.Length)
            {
                return false;
            }
            for (int i = 0; i < bt1.Length; i++)
            {
                if (bt1[i] != bt2[i])
                {
                    return false;
                }
            }
            return true;
        }

        // 比较报价结果是否一致
        public static bool IsEqual(Parsing.QuoteRsp result1, Parsing.QuoteRsp result2)
        {
            if (result1.MmQuoteListCount != result2.MmQuoteListCount 
                || result1.BondQuoteListCount != result2.BondQuoteListCount
                || result1.RangeQuoteListCount != result2.RangeQuoteListCount
                || result1.HasOtherQuote != result2.HasOtherQuote)
            {
                return false;
            }

            for (int i = 0; i < result1.MmQuoteListCount; i++)
            {
                if (!IsEqual(result1.MmQuoteListList[i], result2.MmQuoteListList[i]))
                {
                    return false;
                }
            }

            for (int i = 0; i < result1.BondQuoteListCount; i++)
            {
                if (!IsEqual(result1.BondQuoteListList[i], result2.BondQuoteListList[i]))
                {
                    return false;
                }
            }

            for (int i = 0; i < result1.RangeQuoteListCount; i++)
            {
                if (!IsEqual(result1.RangeQuoteListList[i], result2.RangeQuoteListList[i]))
                {
                    return false;
                }
            }

            return true;
        }

        // 比较线上资金报价是否一致
        public static bool IsEqual(Parsing.QuoteInfo info1, Parsing.QuoteInfo info2)
        {
            if (!info1.Direction.Equals(info2.Direction))
            {
                return false;
            }
            if (!IsEqual(info1.AmountList, info2.AmountList))
            {
                return false;
            }
            if (!IsEqual(info1.TenorList, info2.TenorList))
            {
                return false;
            }
            if (!IsEqual(info1.TypeList, info2.TypeList))
            {
                return false;
            }
            if (!IsEqual(info1.TagList, info2.TagList))
            {
                return false;
            }
            if (!info1.Price.Equals(info2.Price))
            {
                return false;
            }

            return true;
        }
    
        // 比较债券单条报价是否一致
        public static bool IsEqual(Parsing.BondQuoteInfo info1, Parsing.BondQuoteInfo info2)
        {
            if (!info1.Direction.Equals(info2.Direction))
            {
                return false;
            }
            if (!info1.Code.Equals(info2.Code))
            {
                return false;
            }
            if (!info1.Name.Equals(info2.Name))
            {
                return false;
            }
            if (!info1.Volume.Equals(info2.Volume))
            {
                return false;
            }
            if (!info1.Price.Equals(info2.Price))
            {
                return false;
            }
            if (!info1.PriceTag.Equals(info2.PriceTag))
            {
                return false;
            }
            return true;
        }

        // 比较范围报价是否一致
        public static bool IsEqual(Parsing.RangeBondQuote info1, Parsing.RangeBondQuote info2)
        {
            if (!info1.Direction.Equals(info2.Direction))
            {
                return false;
            }
            if (!info1.TermStart.Equals(info2.TermStart))
            {
                return false;
            }
            if (!info1.TermEnd.Equals(info2.TermEnd))
            {
                return false;
            }
            if (!info1.RatingStart.Equals(info2.RatingStart))
            {
                return false;
            }
            if (!info1.RatingEnd.Equals(info2.RatingEnd))
            {
                return false;
            }
            if (!info1.VolumeStart.Equals(info2.VolumeStart))
            {
                return false;
            }
            if (!info1.VolumeEnd.Equals(info2.VolumeEnd))
            {
                return false;
            }
            if (!IsEqual(info1.BondTypeList, info2.BondTypeList))
            {
                return false;
            }
            return true;
        }

        // 比较字符串列表是否相等
        //public static bool IsEqual(IList<string> strList1, IList<string> strList2)
        //{
        //    if (strList1 == strList2)
        //    {
        //        return true;
        //    }
        //    if (null == strList1 || null == strList2)
        //    {
        //        return false;
        //    }
        //    if (strList1.Count != strList2.Count)
        //    {
        //        return false;
        //    }
        //    for (int i = 0; i < strList1.Count; i++)
        //    {
        //        if (!strList1[i].Equals(strList2[i]))
        //        {
        //            return false;
        //        }
        //    }
        //    return true;
        //}

        public static bool IsEqual(IList<string> strList1, IList<string> strList2)
        {
            string str1, str2;
            str1 = str2 = null;
            for (int i = 0; i < strList1.Count; i++)
            {
                str1 += strList1[i];
                str1 = str1.Replace(" ", "");
            }
            for (int i = 0; i < strList2.Count; i++)
            {
                str2 += strList2[i];
                str2 = str2.Replace(" ", "");
            }
            if ((str1 == str2) || (str1 == "" && str2 == null) || (str2 == "" && str1 == null))
                return true;
            else
                return false;
        }
    }
}

