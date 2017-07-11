using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MsgExpress;
using QuoteClassify.manager;

namespace QuoteClassify.form
{
    public partial class QuoteModForm : Form
    {
        bool bOk = false;
        byte[] mData = null;
        string mMsgText;

        public QuoteModForm(string msgText, byte[] data)
        {
            InitializeComponent();

            InitInfo(msgText, data);
        }

        // 是否确认
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
                    foreach (Parsing.BondQuoteInfo info in rsp.BondQuoteListList)
                    {
                        DataGridViewRow dgv = new DataGridViewRow();
                        dgv.CreateCells(dataGridViewQuoteInfo, new object[] { info.Text,
                        info.Direction, info.Code, info.Name, info.Volume, info.Price, info.PriceTag,
                        info.Probobility});

                        dataGridViewQuoteInfo.Rows.Add(dgv);
                        dgv.Tag = info;
                    }
                }
            }
            catch (System.Exception ex)
            {
                Logger.Info("债券解析错误！");
                Logger.Error(ex.StackTrace);
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            bOk = true;
            Parsing.QuoteRsp.Builder build = new Parsing.QuoteRsp.Builder();
            foreach (DataGridViewRow row in dataGridViewQuoteInfo.Rows)
            {
                string direction = row.Cells[1].Value as string;
                if (null == direction || direction.Length == 0)
                {
                    continue;
                }
                Parsing.BondQuoteInfo.Builder itemBuild = new Parsing.BondQuoteInfo.Builder();
                if (row.Cells[0].Value != null)
                {
                    itemBuild.Text = row.Cells[0].Value as string;
                }
                itemBuild.Direction = row.Cells[1].Value as string;
                itemBuild.Bondkey = "";
                if (null == row.Cells[2].Value)
                {
                    itemBuild.Code = "";
                }
                else
                {
                    itemBuild.Code = row.Cells[2].Value as string;
                }

                if (null != row.Cells[3].Value)
                {
                    itemBuild.Name = row.Cells[3].Value as string;
                }

                if (null != row.Cells[4].Value)
                {
                    itemBuild.Volume = row.Cells[4].Value as string;
                }

                if (null != row.Cells[5].Value)
                {
                    itemBuild.Price = row.Cells[5].Value as string;
                }
                if (null != row.Cells[6].Value)
                {
                    itemBuild.PriceTag = row.Cells[6].Value as string;
                }
                if (null != row.Cells[7].Value)
                {
                    try 
                    {
                        itemBuild.Probobility = int.Parse(row.Cells[7].Value as string);
                    }
                    catch(SystemException ex)
                    {
                        Logger.Error(ex.Message);
                        itemBuild.Probobility = 100;
                    }
                }
                
                if (null != row.Tag)
                {
                    Parsing.BondQuoteInfo info = row.Tag as Parsing.BondQuoteInfo;
                    if (null != info)
                    {
                        itemBuild.Bondkey = info.Bondkey;
                        itemBuild.LineNo = info.LineNo;
                        itemBuild.AddRangeWords(info.WordsList);
                    }
                }

                build.AddBondQuoteList(itemBuild);
            }
            mData = build.Build().ToByteArray();

            this.Close();
        }
        //复制文本
        private void button1_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(mMsgText);
        }

        private void dataGridViewBondQuoteInfo_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right
                && e.ColumnIndex >= 0
                && e.RowIndex >= 0)
            {
                dataGridViewQuoteInfo.CurrentCell = dataGridViewQuoteInfo[e.ColumnIndex, e.RowIndex];
                contextMenuStripDel.Show(MousePosition.X, MousePosition.Y);
            }
        }
       
        private void ToolStripMenuItemDel_Click(object sender, EventArgs e)
        {
            int index = dataGridViewQuoteInfo.CurrentCell.RowIndex;
            if (0 <= index && index < dataGridViewQuoteInfo.RowCount)
            {
                dataGridViewQuoteInfo.Rows.RemoveAt(index);
            }
        }
    }
}
