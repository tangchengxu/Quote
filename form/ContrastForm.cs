using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuoteClassify.manager;
using MsgExpress;

namespace QuoteClassify.form
{
    partial class ContrastForm : Form
    {
        DataManager mDataMng;
        string mMsgText;

        public ContrastForm(long id, DataManager mng)
        {
            InitializeComponent();
            mDataMng = mng;
            Init(id);
        }

        void Init(long id)
        {
            DBItem autoItem = null;
            DBItem modItem = null;
            mDataMng.GetContrastData(id, ref autoItem, ref modItem);
            if (null == autoItem || null == modItem)
            {
                MessageBox.Show("无效的消息ID：" + id);
                return;
            }
            mCorrectAutoList = autoItem;

            mMsgText = autoItem.mMsgText;
            richTextBoxMsgText.Text = mMsgText;

            labelParser.Text = "解析类型为：" + autoItem.mType;
            FillData(dataGridViewParser, autoItem);

            labelMod.Text = "实际类型为：" + modItem.mType;
            FillData(dataGridViewMod, modItem);

            //不同数据红色标出
            if (autoItem.mType.Equals(Util.gBondQuote) && modItem.mType.Equals(Util.gBondQuote))
            {
                ShowBondDifferent();
            }
            if (autoItem.mType.Equals(Util.gOnlineQuote) && modItem.mType.Equals(Util.gOnlineQuote))
            {
               ShowOnlineQuoteDifferent();
            }

        }

        void FillData(DataGridView dgv, DBItem item)
        {
            Parsing.QuoteRsp rsp = null;
            try
            {
                rsp = Parsing.QuoteRsp.ParseFrom(item.mData);
            }
            catch (System.Exception ex)
            {
                Logger.Error("ParseFrom byte failed, id = " + item.mId);
                Logger.Error(ex.StackTrace);
            }
            if (null == rsp)
            {
                return;
            }

            if (item.mType.Equals(Util.gOnlineQuote))
            {
                FillQuoteData(dgv,rsp);
            }
            else if (item.mType.Equals(Util.gBondQuote))
            {
                FillBondData(dgv, rsp);
            }
            else if (item.mType.Equals(Util.gRangeQuote))
            {
            }
            else if (item.mType.Equals(Util.gOtherQuote))
            {
            }
            else if (item.mType.Equals(Util.gNoQuote))
            {
            }
        }
        //债券报价显示
        void FillBondData(DataGridView dgv, Parsing.QuoteRsp rsp)
        {
            dgv.Columns.Add(Name + "msgText", "原始文本");
            dgv.Columns.Add(Name + "direction", "方向");
            dgv.Columns.Add(Name + "code", "代码");
            dgv.Columns.Add(Name + "name", "名称");
            dgv.Columns.Add(Name + "volume", "数量");
            dgv.Columns.Add(Name + "price", "价格");
            dgv.Columns.Add(Name + "priceTag", "价格标签");
            dgv.Columns.Add(Name + "probobility", "可信度");

            foreach (Parsing.BondQuoteInfo info in rsp.BondQuoteListList)
            {
                dgv.Rows.Add(new object[] {info.Text, info.Direction, info.Code,
                info.Name, info.Volume, info.Price, info.PriceTag, info.Probobility});
            }
        }
        //线上资金显示
        void FillQuoteData(DataGridView dgv, Parsing.QuoteRsp rsp)
        {
            dgv.Columns.Add(Name + "direction", "方向");
            dgv.Columns.Add(Name + "amount", "数量");
            dgv.Columns.Add(Name + "tenor", "期限");
            dgv.Columns.Add(Name + "type", "类型");
            dgv.Columns.Add(Name + "tag", "标签");
            dgv.Columns.Add(Name + "price", "价格");
            dgv.Columns.Add(Name + "probobility", "可信度");

            foreach (Parsing.QuoteInfo info in rsp.MmQuoteListList)
            {
                string amTest, tenorTest, typeTest, tagTest;
                amTest = tenorTest = typeTest = tagTest = "";

                foreach (string str1 in info.AmountList)
                {
                        amTest += str1 + " ";
                }
                foreach (string str2 in info.TenorList)
                {
                        tenorTest += str2 + " ";
                }
                foreach (string str3 in info.TypeList)
                {
                        typeTest += str3 + " ";
                }
                foreach (string str4 in info.TagList)
                {
                        tagTest += str4 + " ";
                }

                dgv.Rows.Add(new object[] { info.Direction, amTest, tenorTest, typeTest, tagTest,
                        info.Price,info.Probobility});
            }

        }

        private void buttonCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(mMsgText);
        }

        public void ShowBondDifferent()
        {
            foreach (DataGridViewRow row1 in dataGridViewParser.Rows)
            {
                foreach (DataGridViewRow row2 in dataGridViewMod.Rows)
                {
                    if (
                        row1.Cells[1].Value.ToString()== row2.Cells[1].Value.ToString()&&
                        row1.Cells[2].Value.ToString() == row2.Cells[2].Value.ToString() &&
                        row1.Cells[3].Value.ToString() == row2.Cells[3].Value.ToString() &&
                        row1.Cells[4].Value.ToString()== row2.Cells[4].Value.ToString() &&
                        row1.Cells[5].Value.ToString()== row2.Cells[5].Value.ToString() &&
                        row1.Cells[6].Value.ToString() == row2.Cells[6].Value.ToString())
                    {
                        break;
                    }
                    if (row2.Index == (dataGridViewMod.Rows.Count - 1))
                        dataGridViewParser.Rows[row1.Index].DefaultCellStyle.BackColor = Color.Red;
                }
            }
            foreach (DataGridViewRow row1 in dataGridViewMod.Rows)
            {
                foreach (DataGridViewRow row2 in dataGridViewParser.Rows)
                {
                    if (
                        row1.Cells[1].Value.ToString() == row2.Cells[1].Value.ToString() &&
                        row1.Cells[2].Value.ToString() == row2.Cells[2].Value.ToString()&&
                        row1.Cells[3].Value.ToString()== row2.Cells[3].Value.ToString() &&
                        row1.Cells[4].Value.ToString() == row2.Cells[4].Value.ToString() &&
                        row1.Cells[5].Value.ToString() == row2.Cells[5].Value.ToString() &&
                        row1.Cells[6].Value.ToString() == row2.Cells[6].Value.ToString())
                    {
                        break;
                    }
                    if (row2.Index == (dataGridViewParser.Rows.Count - 1))
                        dataGridViewMod.Rows[row1.Index].DefaultCellStyle.BackColor = Color.Red;
                }
            }
        }

        public void ShowOnlineQuoteDifferent()
        {
            foreach (DataGridViewRow row1 in dataGridViewParser.Rows)
            {
                 foreach (DataGridViewRow row2 in dataGridViewMod.Rows)
                    {
                        if (
                            row1.Cells[0].Value.ToString() == row2.Cells[0].Value.ToString() &&
                            row1.Cells[1].Value.ToString() == row2.Cells[1].Value.ToString() &&
                            row1.Cells[2].Value.ToString() == row2.Cells[2].Value.ToString() &&
                            row1.Cells[3].Value.ToString() == row2.Cells[3].Value.ToString() &&
                            row1.Cells[4].Value.ToString() == row2.Cells[4].Value.ToString() &&
                            row1.Cells[5].Value.ToString() == row2.Cells[5].Value.ToString())
                        {
                            break;
                        }
                        if (row2.Index == (dataGridViewMod.Rows.Count - 1))
                            dataGridViewParser.Rows[row1.Index].DefaultCellStyle.BackColor = Color.Red;
                    }
            }
            foreach (DataGridViewRow row1 in dataGridViewMod.Rows)
            {
                foreach (DataGridViewRow row2 in dataGridViewParser.Rows)
                {
                    if (
                        row1.Cells[0].Value.ToString() == row2.Cells[0].Value.ToString() &&
                        row1.Cells[1].Value.ToString() == row2.Cells[1].Value.ToString() &&
                        row1.Cells[2].Value.ToString() == row2.Cells[2].Value.ToString() &&
                        row1.Cells[3].Value.ToString() == row2.Cells[3].Value.ToString() &&
                        row1.Cells[4].Value.ToString() == row2.Cells[4].Value.ToString() &&
                        row1.Cells[5].Value.ToString() == row2.Cells[5].Value.ToString())
                    {
                        break;
                    }
                    if (row2.Index == (dataGridViewParser.Rows.Count - 1))
                        dataGridViewMod.Rows[row1.Index].DefaultCellStyle.BackColor = Color.Red;
                }
            }
        }

        private void buttonCorrectParser_Click(object sender, EventArgs e)
        {

            dataGridViewMod.Rows.Clear();
            Parsing.QuoteRsp rsp=null;
            rsp = Parsing.QuoteRsp.ParseFrom(mCorrectAutoList.mData);
            if (rsp != null)
            {
                if (mCorrectAutoList.mType.Equals(Util.gBondQuote))
                {
                    foreach (Parsing.BondQuoteInfo info in rsp.BondQuoteListList)
                    {
                    
                        dataGridViewMod.Rows.Add(new object[] {info.Text, info.Direction, info.Code,
                        info.Name, info.Volume, info.Price, info.PriceTag, info.Probobility});
                    }
                  
                }
                if (mCorrectAutoList.mType.Equals(Util.gOnlineQuote))
                {
                    foreach (Parsing.QuoteInfo info in rsp.MmQuoteListList)
                    {
                        string amTest, tenorTest, typeTest, tagTest;
                        amTest = tenorTest = typeTest = tagTest = "";

                        foreach (string str1 in info.AmountList)
                        {
                                amTest += str1 + " ";
                        }
                        foreach (string str2 in info.TenorList)
                        {
                                tenorTest += str2 + " ";
                        }
                        foreach (string str3 in info.TypeList)
                        {
                                typeTest += str3 + " ";
                        }
                        foreach (string str4 in info.TagList)
                        {
                               tagTest += str4 + " ";
                        }

                        dataGridViewMod.Rows.Add(new object[] { info.Direction, amTest, tenorTest, typeTest, tagTest,
                        info.Price,info.Probobility});
                    }
                }
                DBItem modItem = mCorrectAutoList.DeepCopy();//深拷贝
                modItem.mStatu = Util.gCheckQuoteStatu;
                mDataMng.ModData(modItem);
            }
        }

        private void ContrastForm_Resize(object sender, EventArgs e)
        {
            int high = this.Height;
            richTextBoxMsgText.Height = high / 4 - 5;
            panelParser.Height = high / 25 - 5;
            dataGridViewParser.Height = high / 3 - 5;
            panelMod.Height = high / 25 - 5;
            dataGridViewMod.Height = high / 3 - 5;

            panelParser.Top = richTextBoxMsgText.Top + high / 4 - 5;
            dataGridViewParser.Top = panelParser.Top + high / 25 - 5;
            panelMod.Top = dataGridViewParser.Top + high / 3 - 5;
            dataGridViewMod.Top = panelMod.Top + high / 25 - 5;

        }

        DBItem mCorrectAutoList=new DBItem();//正确的解析结果
    }
}
