using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MsgExpress;


namespace QuoteClassify.form
{
    public partial class OnlineQuoteModForm : Form
    {
        bool bOk = false;
        byte[] mData = null;
        string mMsgText;

        public OnlineQuoteModForm(string msgText, byte[] data)
        {
            InitializeComponent();

            InitInfo(msgText, data);
        }

        public bool IsOK()
        {
            return bOk;
        }

        // 获取确认后的结果
        public byte[] GetNewData()
        {
            return mData;
        }

        void InitInfo(string msgText, byte[] data)
        {
            mMsgText = msgText;
            richTextBoxMsgText.Text = msgText;
            try
            {
                Parsing.QuoteRsp rsp = Parsing.QuoteRsp.ParseFrom(data);
                if (null != rsp)
                {
                    foreach (Parsing.QuoteInfo info in rsp.MmQuoteListList)
                    {
                        string  amTest, tenorTest, typeTest, tagTest;
                        amTest = tenorTest = typeTest = tagTest = "";

                        foreach(string str1 in info.AmountList)
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
                        foreach(string str4 in info.TagList)
                        {
                                tagTest += str4 + " ";
                        }
                     
                        DataGridViewRow dgv = new DataGridViewRow();
                        dgv.CreateCells(dataGridViewOnlineQuoteInfo, new object[] {
                        info.Direction, amTest, tenorTest, typeTest, tagTest,
                        info.Price,info.Probobility});

                        dataGridViewOnlineQuoteInfo.Rows.Add(dgv);
                        dgv.Tag = info;
                    }
                }
            }
            catch (System.Exception ex)
            {
                Logger.Info("线上资金解析错误！");
                Logger.Error(ex.StackTrace);
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            bOk = true;
            Parsing.QuoteRsp.Builder build = new Parsing.QuoteRsp.Builder();
            
            foreach (DataGridViewRow row in dataGridViewOnlineQuoteInfo.Rows)
            {
                string direction = row.Cells[0].Value as string;
                if (null == direction || direction.Length == 0)
                {
                    continue;
                }
                Parsing.QuoteInfo.Builder itemBuild = new Parsing.QuoteInfo.Builder();
                itemBuild.Direction = row.Cells[0].Value as string;
                if (null != row.Cells[5].Value)
                {
                    itemBuild.Price = row.Cells[5].Value as string;
                }

                if (null != row.Cells[6].Value)
                {
                    try
                    {
                        itemBuild.Probobility = int.Parse(row.Cells[6].Value as string);
                    }
                    catch (SystemException ex)
                    {
                        Logger.Error(ex.StackTrace);
                        itemBuild.Probobility = 100;//默认可信度100
                    }
                }

                if (null != row.Cells[1].Value)
                {
                    itemBuild.AddAmount(row.Cells[1].Value as string);
                }
                if (null != row.Cells[2].Value)
                {
                    itemBuild.AddTenor(row.Cells[2].Value as string);
                }
                if (null != row.Cells[3].Value)
                {
                    itemBuild.AddType(row.Cells[3].Value as string);
                }
                if (null != row.Cells[4].Value)
                {
                    itemBuild.AddTag(row.Cells[4].Value as string);
                }

                if (null != row.Tag)
                {
                    Parsing.QuoteInfo info = row.Tag as Parsing.QuoteInfo;
                    if (null != info)
                    {
                        itemBuild.AddRangeWords(info.WordsList);
                    }
                }

                build.AddMmQuoteList(itemBuild);
            }
            mData = build.Build().ToByteArray();

            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(mMsgText);
        }
        
        private void dataGridViewOnlineQuoteInfo_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right
              && e.ColumnIndex >= 0
              && e.RowIndex >= 0)
            {
                dataGridViewOnlineQuoteInfo.CurrentCell = dataGridViewOnlineQuoteInfo[e.ColumnIndex, e.RowIndex];
                contextMenuStrip1.Show(MousePosition.X, MousePosition.Y);
            }
        }
           
        private void contextMenuStripOnlineDel_Click(object sender, EventArgs e)
        {
            int index = dataGridViewOnlineQuoteInfo.CurrentCell.RowIndex;
            if (0 <= index && index < dataGridViewOnlineQuoteInfo.RowCount)
            {
                dataGridViewOnlineQuoteInfo.Rows.RemoveAt(index);
            }
        }

       


    }
}
