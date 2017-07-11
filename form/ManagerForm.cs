using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuoteClassify.manager;
using QuoteClassify.thread;
using MsgExpress;
using QuoteClassify.form;

namespace QuoteClassify
{
   
    public partial class ManagerForm : Form
    {
        const string mStartParserText = "开始解析";
        const string mEndParserText = "停止解析";

        MsgParserThread mThread = null;
        DataManager mDataMng;

        public ManagerForm()
        {
            InitializeComponent();         
            Init();
        }

        void Init()
        {
            mDataMng = new DataManager();
            //mDataMng.ScreenBondQuoteInfo();
            //mDataMng.ScreenOnlineQuoteInfo();

            Config cfg = new Config("../config");
            textBoxSrcHost.Text = cfg.mSrcHost;
            textBoxSrcTableName.Text = cfg.mSrcDbName;
            textBoxDisHost.Text = cfg.mDisHost;
            textBoxDisDbName.Text = cfg.mDisDbName;

            comboBoxShowQuote.SelectedIndex = 0;
            comboBoxType.SelectedIndex = 0;
            comboBoxParser.SelectedIndex = 0;
            SetPageNum(1);

            dataGridViewResult.Columns[0].Width = 100;
            dataGridViewResult.Columns[1].Width = 552;
            dataGridViewResult.Columns[2].Width = 100;
            dataGridViewResult.Columns[3].Width = 100;
            
        }

        // 外部回调函数
        void OnDataNotifyOut(EDataChangeType type, object param)
        {
        //  OnDataChange fun = new OnDataChange(OnDataNotifyIn);
        //  fun.Invoke(type,param);
            OnDataChange fun = OnDataNotifyIn;
            Invoke(fun, new object[] { type, param });
        }

        // 内部界面操作函数
        void OnDataNotifyIn(EDataChangeType type, object param)
        {
            try
            {
                switch (type)
                {
                    case EDataChangeType.Type_Progress:
                        {
                            this.UpdateProgress((int)param);
                        }
                        break;
                    default:
                        {

                        }
                        break;
                }
            }
            catch (System.Exception ex)
            {
                Logger.Error(ex.ToString());
            }
        }

        // 更新进度
        void UpdateProgress(int progress)
        {
            if (progress >= 0)
            {
                progressBarParser.Value = progress;
                if (100 <= progress )
                {
                    buttonParser.Text = mStartParserText;
                    mDataMng.LoadData();
                    SetPageNum(1);
                }
                labelParser.Text = (progress * 100 / (progressBarParser.Maximum )).ToString() + "%";//显示百分比 
            }
            else
            {
                MessageBox.Show("解析失败！");
            }
        }

        // 设置当前页
        void SetPageNum(int page)
        {
            dataGridViewManager.Rows.Clear();
            List<DBItem> itemList = mDataMng.GetPageData(page);
            if (null != itemList)
            {
                foreach (DBItem item in itemList)
                {
                    dataGridViewManager.Rows.Add(new object[] { item.mId, item.mDateTime, item.mMsgText, item.mType, item.mStatu, "确认分类", "修改分类" });
                    dataGridViewManager.Rows[dataGridViewManager.Rows.Count - 1].Tag = item;
                    dataGridViewManager.Rows[dataGridViewManager.Rows.Count - 1].DefaultCellStyle.BackColor = Util.GetLineColor(item);
                }
            }
        }
        
        // 设置债券当前页
        void SetPageBondQuoteData(int page)
        {
            dataGridViewManager.Rows.Clear();
            List<DBItem> itemList = new List<DBItem>();
            if (comboBoxShowQuote.Text == "债券报价")
                itemList = mDataMng.GetPageBondQuoteData(page);
            if (comboBoxShowQuote.Text == "线上资金报价")
                itemList = mDataMng.GetPageOnlineQuoteData(page);

            if (null != itemList)
            {
                foreach (DBItem item in itemList)
                {
                    dataGridViewManager.Rows.Add(new object[] { item.mId, item.mDateTime, item.mMsgText, item.mType, item.mStatu, "确认分类", "修改分类" });
                    dataGridViewManager.Rows[dataGridViewManager.Rows.Count - 1].Tag = item;
                    dataGridViewManager.Rows[dataGridViewManager.Rows.Count - 1].DefaultCellStyle.BackColor = Util.GetLineColor(item);
                }
            }
        }

        //设置今日成交
        void SetPageDealData(int page)
        {
            dataGridViewManager.Rows.Clear();
            List<DBItem> itemList = mDataMng.GetPageDealData(page);

            if (null != itemList)
            {
                foreach (DBItem item in itemList)
                {
                    dataGridViewManager.Rows.Add(new object[] { item.mId, item.mDateTime, item.mMsgText, item.mType, item.mStatu, "确认分类", "修改分类" });
                    dataGridViewManager.Rows[dataGridViewManager.Rows.Count - 1].Tag = item;
                    dataGridViewManager.Rows[dataGridViewManager.Rows.Count - 1].DefaultCellStyle.BackColor = Util.GetLineColor(item);
                }
            }
        }

        // 修改报价分类
        void ModQuoteType(string type)
        {
            if (dataGridViewManager.SelectedRows.Count > 0)
            {
                DBItem tag = dataGridViewManager.SelectedRows[0].Tag as DBItem;
                DBItem item = tag.DeepCopy();
                
                item.mType = type;
                if (type.Equals(Util.gNoQuote))
                {
                    item.mStatu = Util.gCheckQuoteStatu;
                }
                else
                {
                    item.mStatu = Util.gCheckTypeStatu;
                }
                dataGridViewManager.SelectedRows[0].Cells[3].Value = item.mType;
                dataGridViewManager.SelectedRows[0].Cells[4].Value = item.mStatu;
                dataGridViewManager.SelectedRows[0].DefaultCellStyle.BackColor = Util.GetLineColor(item);
                dataGridViewManager.SelectedRows[0].Tag = item;
                mDataMng.ModData(item);
            }
        }

        private void buttonParser_Click(object sender, EventArgs e)
        {
            string msgText = buttonParser.Text;

            if (mStartParserText.Equals(msgText))
            {
                buttonParser.Text = mEndParserText;
                if(comboBoxParser.SelectedIndex==0)
                    mThread = new MsgParserThread(this.OnDataNotifyOut,false);
                if (comboBoxParser.SelectedIndex == 1)
                    mThread = new MsgParserThread(this.OnDataNotifyOut,true);
                mThread.Start();
            }
            else
            {
                buttonParser.Text = mStartParserText;
                if (null != mThread)
                {
                    mThread.Stop();
                    mThread = null;
                }
            }
        }

        private void ManagerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (null != mThread)
            {
                mThread.Stop();
                mThread = null;
            }
            System.Environment.Exit(0);
        }

        private void textBoxPageNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
                if (e.KeyChar == (char)13)
                {
                    int page;
                    if (int.TryParse(textBoxPageNum.Text, out page))
                    {
                        if (comboBoxShowQuote.Text == "全部")
                            SetPageNum(page);
                        else 
                            SetPageBondQuoteData(page);  
                    }
                }
            }
        }

        private void buttonFirstPage_Click(object sender, EventArgs e)
        {
            if (comboBoxShowQuote.Text == "全部")
                SetPageNum(1);
            else if (comboBoxShowQuote.Text == "今日成交")
                SetPageDealData(1);
            else
                SetPageBondQuoteData(1);

            textBoxPageNum.Text = "1";
        }

        private void buttonPrePage_Click(object sender, EventArgs e)
        {
            int page;
            if (int.TryParse(textBoxPageNum.Text, out page))
            {
                if (page > 1)
                {
                    page--;
                    if (comboBoxShowQuote.Text == "全部")
                        SetPageNum(page);
                    else if (comboBoxShowQuote.Text == "今日成交")
                        SetPageDealData(page);
                    else 
                        SetPageBondQuoteData(page);
                    
                    textBoxPageNum.Text = page.ToString();
                }
            }
            else
            {
                page = 1;
                if (comboBoxShowQuote.Text == "全部")
                    SetPageNum(page);
                else 
                    SetPageBondQuoteData(page);
                textBoxPageNum.Text = page.ToString();
            }
        }

        private void buttonNextPage_Click(object sender, EventArgs e)
        {
            int page;
            if (int.TryParse(textBoxPageNum.Text, out page))
            {
                page++;
            }
            else
            {
                page = 1;
            }
            if (comboBoxShowQuote.Text == "全部")
                SetPageNum(page);
            else if(comboBoxShowQuote.Text == "今日成交")
                SetPageDealData(page);
            else 
                SetPageBondQuoteData(page);
          
            textBoxPageNum.Text = page.ToString();
        }

        private void buttonLastPage_Click(object sender, EventArgs e)
        {
            int page = 1;
            if (comboBoxShowQuote.Text == "全部")
            {
                page = mDataMng.GetTotalPageNum();
                SetPageNum(page);
            }
            else if (comboBoxShowQuote.Text == "今日成交")
            {
                page = mDataMng.GetTotalDealPage();
                SetPageDealData(page);
            }
            else if (comboBoxShowQuote.Text == "债券报价")
            {
                page = mDataMng.GetTotalBondQuotePage();
                SetPageBondQuoteData(page);
            }
            else if (comboBoxShowQuote.Text == "线上资金报价")
            {
                page = mDataMng.GetTotalOnlineQuotePage();
                SetPageBondQuoteData(page);
            }
            textBoxPageNum.Text = page.ToString();    
        }

        private void dataGridViewManager_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                DBItem tag = dataGridViewManager.Rows[e.RowIndex].Tag as DBItem;
                if (tag.mStatu.Equals(Util.gIdleStatu))
                {
                    DBItem item = tag.DeepCopy();
                    if (item.mType.Equals(Util.gNoQuote))
                    {
                        item.mStatu = Util.gCheckQuoteStatu;
                    }
                    else
                    {
                        item.mStatu = Util.gCheckTypeStatu;
                    }
                    
                    dataGridViewManager[4, e.RowIndex].Value = item.mStatu;
                    dataGridViewManager.Rows[e.RowIndex].DefaultCellStyle.BackColor = Util.GetLineColor(item);
                    dataGridViewManager.Rows[e.RowIndex].Tag = item;
                    mDataMng.ModData(item);
                }
            }
            else if (e.ColumnIndex == 6)
            {
                contextMenuStripMod.Show(MousePosition.X, MousePosition.Y);
            }
        }

        private void onlineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModQuoteType(Util.gOnlineQuote);
        }

        private void bondToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModQuoteType(Util.gBondQuote);
        }

        private void rangeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModQuoteType(Util.gRangeQuote);
        }

        private void otherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModQuoteType(Util.gOtherQuote);
        }

        private void noToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModQuoteType(Util.gNoQuote);
        }

        private void buttonTest_Click(object sender, EventArgs e)
        {
            ETestType type;
            if (comboBoxType.SelectedIndex == 0)
            {
                type = ETestType.TestType_Classify;
            }
            else if (comboBoxType.SelectedIndex == 1)
            {
                type = ETestType.TestType_BondQuote;
            }
            else
            {
                type = ETestType.TestType_OnlineQuote;
            }

            List<DBItem> autoItemList, modItemList;
            int total, matchNum;
            mDataMng.LoopTest(type, out autoItemList, out modItemList, out total, out matchNum);
            string msg = "回测对比" + total + "条消息，匹配" + matchNum + "条。";
            if (total > 0)
            {
                msg += "正确率：" + (double)matchNum / total;
            }
            labelResult.Text = msg;

            dataGridViewResult.Rows.Clear();
            for (int i = 0; i < autoItemList.Count; i++)
            {
                dataGridViewResult.Rows.Add(new object[] { autoItemList[i].mId, autoItemList[i].mMsgText, autoItemList[i].mType, modItemList[i].mType });
                dataGridViewResult.Rows[dataGridViewResult.RowCount - 1].Tag = autoItemList[i].mId;
            }
        }

        private void dataGridViewManager_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }
            DBItem tag = dataGridViewManager.Rows[e.RowIndex].Tag as DBItem;
            DBItem item = tag.DeepCopy();
            if (null != item && item.mType.Equals(Util.gBondQuote))
            {
                QuoteModForm form = new QuoteModForm(item.mMsgText, item.mData);
                form.ShowDialog();
                if (form.IsOK())
                {
                    byte[] newData = form.GetNewData();
                    item.mData = newData;
                    item.mStatu = Util.gCheckQuoteStatu;

                    dataGridViewManager.Rows[e.RowIndex].Cells[4].Value = item.mStatu;
                    dataGridViewManager.Rows[e.RowIndex].DefaultCellStyle.BackColor = Util.GetLineColor(item);
                    dataGridViewManager.Rows[e.RowIndex].Tag = item;
                    mDataMng.ModData(item);
                }
            }
            if (null != item && item.mType.Equals(Util.gOnlineQuote))
            {
                OnlineQuoteModForm form = new OnlineQuoteModForm(item.mMsgText, item.mData);
                form.ShowDialog();
                if (form.IsOK())
                {
                    byte[] newData = form.GetNewData();
                    item.mData = newData;
                    item.mStatu = Util.gCheckQuoteStatu;

                    dataGridViewManager.Rows[e.RowIndex].Cells[4].Value = item.mStatu;
                    dataGridViewManager.Rows[e.RowIndex].DefaultCellStyle.BackColor = Util.GetLineColor(item);
                    dataGridViewManager.Rows[e.RowIndex].Tag = item;
                    mDataMng.ModData(item);
                }
            }
        }

        private void dataGridViewResult_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }
            long id = (long)(dataGridViewResult.Rows[e.RowIndex].Tag);
            if (comboBoxType.SelectedIndex == 1)
            {
                ContrastForm form = new ContrastForm(id, mDataMng);
                form.ShowDialog();
            }
            if (comboBoxType.SelectedIndex == 2)
            {
                ContrastForm form = new ContrastForm(id, mDataMng);
                form.ShowDialog();
            }
        }
       
        //全部当中查询顺序id(没有使用)
        public void allQueryContinueId()
        {
            int queryNumber = 0, numberPage = 0, pageLeft = 0;
            if (int.TryParse(textBoxQuery.Text, out queryNumber))
            {
                numberPage = queryNumber / 50;
                pageLeft = queryNumber % 50;

                if (queryNumber == 0)
                {
                    this.dataGridViewManager.Rows[0].Selected = true;
                    this.dataGridViewManager.CurrentCell = this.dataGridViewManager.Rows[0].Cells[0];
                }
                else if (pageLeft == 0)
                {
                    SetPageNum(numberPage + 1);
                    textBoxPageNum.Text = (numberPage + 1).ToString();
                    this.dataGridViewManager.Rows[49].Selected = true;
                    this.dataGridViewManager.CurrentCell = this.dataGridViewManager.Rows[49].Cells[0];
                }
                else
                {
                    SetPageNum(numberPage + 1);
                    textBoxPageNum.Text = (numberPage + 1).ToString();
                    this.dataGridViewManager.Rows[pageLeft - 1].Selected = true;
                    this.dataGridViewManager.CurrentCell = this.dataGridViewManager.Rows[pageLeft - 1].Cells[0];
                }
            }
        }
        
        //全部显示查询id
        public void allQueryDelSameId()
        {
            List<DBItem> itemQueryList = new List<DBItem>();
            itemQueryList = mDataMng.Get();
            int id = int.Parse(textBoxQuery.Text);
            int total = mDataMng.GetTotalPageNum(), queryPage = 0;

            for (int i = 0; i < total; i++)
            {
                if (itemQueryList[i * 50].mId > id)
                {
                    queryPage = i;
                    break;
                }
                else if (i == total - 1)
                {
                    if (id <=itemQueryList[itemQueryList.Count-1].mId)
                    {
                        queryPage = total; 
                    }
                    else
                    {
                        MessageBox.Show("id超出界限！");
                    }
                }
            }
            List<DBItem> itemList = mDataMng.GetPageData(queryPage);
            if (null != itemList)
            {
                for (int i = 0; i < itemList.Count; i++)
                {
                    if (id == itemList[i].mId)
                    {
                        textBoxPageNum.Text = queryPage.ToString();
                        SetPageNum(queryPage);
                        this.dataGridViewManager.Rows[i].Selected = true;
                        this.dataGridViewManager.CurrentCell = this.dataGridViewManager.Rows[i].Cells[0];
                        break;
                    }
                    else if (i == itemList.Count - 1)
                    {
                        MessageBox.Show("不存在此id的报价！");
                        SetPageNum(1);
                    }
                }
            }
        }
        
        //分类报价显示当中查询id
        public void bondQueryId()
        {
            List<DBItem> itemQueryList = new List<DBItem>();
            if (comboBoxShowQuote.SelectedIndex == 1)
                itemQueryList = mDataMng.ScreenBondQuoteInfo();
            else if ((comboBoxShowQuote.SelectedIndex == 2))
                itemQueryList = mDataMng.ScreenOnlineQuoteInfo();
            else if ((comboBoxShowQuote.SelectedIndex == 3))
                itemQueryList = mDataMng.ScreenDealToday();

            int id = int.Parse(textBoxQuery.Text);
            int total=0, queryPage = 0;

            if (comboBoxShowQuote.SelectedIndex == 1)
                total = mDataMng.GetTotalBondQuotePage();
            else if ((comboBoxShowQuote.SelectedIndex == 2))
                total = mDataMng.GetTotalOnlineQuotePage();
            else if ((comboBoxShowQuote.SelectedIndex == 3))
                total = mDataMng.GetTotalDealPage();

            for (int i = 0; i < total; i++)
            {
                if (itemQueryList[i * 50].mId > id)
                {
                    queryPage = i;
                    break;
                }
                else if (i == total-1 )
                {
                    if (id <= itemQueryList[itemQueryList.Count - 1].mId)
                    {
                        queryPage = total;
                    }
                    else
                    {
                        MessageBox.Show("id超出界限！");
                    }
                }
            }
            if (queryPage == 0)
            {
                MessageBox.Show("不存在此id的分类报价！");
                allQueryDelSameId();
                comboBoxShowQuote.SelectedIndex = 0;
                return ;
            }

            List<DBItem> itemList=new List<DBItem>();
            if (comboBoxShowQuote.SelectedIndex == 1)
                itemList = mDataMng.GetPageBondQuoteData(queryPage);
            else if ((comboBoxShowQuote.SelectedIndex == 2))
                itemList = mDataMng.GetPageOnlineQuoteData(queryPage);
            else if ((comboBoxShowQuote.SelectedIndex == 3))
                itemList = mDataMng.GetPageDealData(queryPage);

            if (null != itemList)
            {
                for (int i = 0; i < itemList.Count; i++)
                {
                    if (id == itemList[i].mId)
                    {
                        textBoxPageNum.Text = queryPage.ToString();
                        if (comboBoxShowQuote.SelectedIndex == 1||comboBoxShowQuote.SelectedIndex == 2)
                            SetPageBondQuoteData(queryPage);
                        else if(comboBoxShowQuote.SelectedIndex == 3)
                            SetPageDealData(queryPage);

                        this.dataGridViewManager.Rows[i].Selected = true;
                        this.dataGridViewManager.CurrentCell = this.dataGridViewManager.Rows[i].Cells[0];
                        break;
                    }
                    else if (i == itemList.Count - 1)
                    {
                        MessageBox.Show("不存在此id的分类报价！");
                        allQueryDelSameId();
                        comboBoxShowQuote.SelectedIndex = 0;
                    }
                }
            }
        }

        private void buttonQuery_Click(object sender, EventArgs e)
        {
            if (comboBoxShowQuote.Text == "全部")
            {
                allQueryDelSameId();
            }
            else 
            {
                bondQueryId();
            }
   
        }

        private void textBoxQuery_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
                if (e.KeyChar == (char)13)
                {
                    if (comboBoxShowQuote.Text == "全部")
                    {
                        allQueryDelSameId();
                    }
                    else 
                    {
                        bondQueryId();
                    }
                }
            }
        }

        private void buttonShowQuote_Click(object sender, EventArgs e)
        {
            if (comboBoxShowQuote.Text == "全部")
            {
              //  mDataMng.ScreenBondQuoteInfo();
              //  mDataMng.ScreenOnlineQuoteInfo();
                SetPageNum(1);
                textBoxPageNum.Text = "1";
            }
            else if (comboBoxShowQuote.Text == "今日成交")
            {
                mDataMng.ScreenDealToday();
                SetPageDealData(1);
                textBoxPageNum.Text = "1";
            }
            else 
            {
                mDataMng.ScreenBondQuoteInfo();
                mDataMng.ScreenOnlineQuoteInfo();
                SetPageBondQuoteData(1);
                textBoxPageNum.Text = "1";
            }
        }

        private void buttonInsertMsg_Click(object sender, EventArgs e)
        {
            MsgInsertForm form = new MsgInsertForm();
            form.ShowDialog();
            if (form.IsOK())
            {
                Init();
                int page = mDataMng.GetTotalPageNum();
                SetPageNum(page);
                textBoxPageNum.Text = page.ToString();
                comboBoxShowQuote.SelectedIndex = 0;
                //光标显示至插入的数据
                int i = dataGridViewManager.Rows.Count - 1;
                dataGridViewManager.CurrentCell = dataGridViewManager[0, i]; 
                dataGridViewManager.Rows[i].Selected = true;   
            }
        }
    }
}
