namespace QuoteClassify
{
    partial class ManagerForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBoxSrc = new System.Windows.Forms.GroupBox();
            this.textBoxSrcTableName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxSrcHost = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxDis = new System.Windows.Forms.GroupBox();
            this.textBoxDisDbName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxDisHost = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.progressBarParser = new System.Windows.Forms.ProgressBar();
            this.buttonParser = new System.Windows.Forms.Button();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageParser = new System.Windows.Forms.TabPage();
            this.comboBoxParser = new System.Windows.Forms.ComboBox();
            this.labelParser = new System.Windows.Forms.Label();
            this.tabPageManger = new System.Windows.Forms.TabPage();
            this.dataGridViewManager = new System.Windows.Forms.DataGridView();
            this.msgId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.msgText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quotetype = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pass = new System.Windows.Forms.DataGridViewButtonColumn();
            this.modify = new System.Windows.Forms.DataGridViewLinkColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonInsertMsg = new System.Windows.Forms.Button();
            this.buttonShowQuote = new System.Windows.Forms.Button();
            this.comboBoxShowQuote = new System.Windows.Forms.ComboBox();
            this.textBoxQuery = new System.Windows.Forms.TextBox();
            this.buttonQuery = new System.Windows.Forms.Button();
            this.textBoxPageNum = new System.Windows.Forms.TextBox();
            this.buttonNextPage = new System.Windows.Forms.Button();
            this.buttonLastPage = new System.Windows.Forms.Button();
            this.buttonPrePage = new System.Windows.Forms.Button();
            this.buttonFirstPage = new System.Windows.Forms.Button();
            this.tabPageTest = new System.Windows.Forms.TabPage();
            this.dataGridViewResult = new System.Windows.Forms.DataGridView();
            this.TestId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TestMsgText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TestParserType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TestType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.comboBoxType = new System.Windows.Forms.ComboBox();
            this.labelResult = new System.Windows.Forms.Label();
            this.buttonTest = new System.Windows.Forms.Button();
            this.contextMenuStripMod = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.onlineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bondToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rangeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.otherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.noToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBoxSrc.SuspendLayout();
            this.groupBoxDis.SuspendLayout();
            this.tabControlMain.SuspendLayout();
            this.tabPageParser.SuspendLayout();
            this.tabPageManger.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewManager)).BeginInit();
            this.panel1.SuspendLayout();
            this.tabPageTest.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResult)).BeginInit();
            this.panel2.SuspendLayout();
            this.contextMenuStripMod.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxSrc
            // 
            this.groupBoxSrc.Controls.Add(this.textBoxSrcTableName);
            this.groupBoxSrc.Controls.Add(this.label2);
            this.groupBoxSrc.Controls.Add(this.textBoxSrcHost);
            this.groupBoxSrc.Controls.Add(this.label1);
            this.groupBoxSrc.Location = new System.Drawing.Point(5, 8);
            this.groupBoxSrc.Name = "groupBoxSrc";
            this.groupBoxSrc.Size = new System.Drawing.Size(402, 52);
            this.groupBoxSrc.TabIndex = 1;
            this.groupBoxSrc.TabStop = false;
            this.groupBoxSrc.Text = "数据源";
            // 
            // textBoxSrcTableName
            // 
            this.textBoxSrcTableName.Location = new System.Drawing.Point(282, 18);
            this.textBoxSrcTableName.Name = "textBoxSrcTableName";
            this.textBoxSrcTableName.ReadOnly = true;
            this.textBoxSrcTableName.Size = new System.Drawing.Size(100, 21);
            this.textBoxSrcTableName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(211, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "数据库名：";
            // 
            // textBoxSrcHost
            // 
            this.textBoxSrcHost.Location = new System.Drawing.Point(90, 18);
            this.textBoxSrcHost.Name = "textBoxSrcHost";
            this.textBoxSrcHost.ReadOnly = true;
            this.textBoxSrcHost.Size = new System.Drawing.Size(100, 21);
            this.textBoxSrcHost.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "主机名：";
            // 
            // groupBoxDis
            // 
            this.groupBoxDis.Controls.Add(this.textBoxDisDbName);
            this.groupBoxDis.Controls.Add(this.label4);
            this.groupBoxDis.Controls.Add(this.textBoxDisHost);
            this.groupBoxDis.Controls.Add(this.label3);
            this.groupBoxDis.Location = new System.Drawing.Point(6, 67);
            this.groupBoxDis.Name = "groupBoxDis";
            this.groupBoxDis.Size = new System.Drawing.Size(401, 53);
            this.groupBoxDis.TabIndex = 2;
            this.groupBoxDis.TabStop = false;
            this.groupBoxDis.Text = "结果存储地址";
            // 
            // textBoxDisDbName
            // 
            this.textBoxDisDbName.Location = new System.Drawing.Point(281, 18);
            this.textBoxDisDbName.Name = "textBoxDisDbName";
            this.textBoxDisDbName.ReadOnly = true;
            this.textBoxDisDbName.Size = new System.Drawing.Size(100, 21);
            this.textBoxDisDbName.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(210, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "数据库名：";
            // 
            // textBoxDisHost
            // 
            this.textBoxDisHost.Location = new System.Drawing.Point(91, 18);
            this.textBoxDisHost.Name = "textBoxDisHost";
            this.textBoxDisHost.ReadOnly = true;
            this.textBoxDisHost.Size = new System.Drawing.Size(100, 21);
            this.textBoxDisHost.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "主机名：";
            // 
            // progressBarParser
            // 
            this.progressBarParser.Location = new System.Drawing.Point(5, 139);
            this.progressBarParser.Name = "progressBarParser";
            this.progressBarParser.Size = new System.Drawing.Size(300, 23);
            this.progressBarParser.TabIndex = 3;
            // 
            // buttonParser
            // 
            this.buttonParser.Location = new System.Drawing.Point(492, 139);
            this.buttonParser.Name = "buttonParser";
            this.buttonParser.Size = new System.Drawing.Size(75, 23);
            this.buttonParser.TabIndex = 4;
            this.buttonParser.Text = "开始解析";
            this.buttonParser.UseVisualStyleBackColor = true;
            this.buttonParser.Click += new System.EventHandler(this.buttonParser_Click);
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPageParser);
            this.tabControlMain.Controls.Add(this.tabPageManger);
            this.tabControlMain.Controls.Add(this.tabPageTest);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Location = new System.Drawing.Point(0, 0);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(863, 523);
            this.tabControlMain.TabIndex = 5;
            // 
            // tabPageParser
            // 
            this.tabPageParser.Controls.Add(this.comboBoxParser);
            this.tabPageParser.Controls.Add(this.labelParser);
            this.tabPageParser.Controls.Add(this.groupBoxDis);
            this.tabPageParser.Controls.Add(this.buttonParser);
            this.tabPageParser.Controls.Add(this.groupBoxSrc);
            this.tabPageParser.Controls.Add(this.progressBarParser);
            this.tabPageParser.Location = new System.Drawing.Point(4, 22);
            this.tabPageParser.Name = "tabPageParser";
            this.tabPageParser.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageParser.Size = new System.Drawing.Size(855, 497);
            this.tabPageParser.TabIndex = 0;
            this.tabPageParser.Text = "QQ消息解析存储";
            this.tabPageParser.UseVisualStyleBackColor = true;
            // 
            // comboBoxParser
            // 
            this.comboBoxParser.FormattingEnabled = true;
            this.comboBoxParser.Items.AddRange(new object[] {
            "部分解析",
            "完全解析"});
            this.comboBoxParser.Location = new System.Drawing.Point(365, 141);
            this.comboBoxParser.Name = "comboBoxParser";
            this.comboBoxParser.Size = new System.Drawing.Size(121, 20);
            this.comboBoxParser.TabIndex = 7;
            // 
            // labelParser
            // 
            this.labelParser.AutoSize = true;
            this.labelParser.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelParser.Location = new System.Drawing.Point(311, 144);
            this.labelParser.Name = "labelParser";
            this.labelParser.Size = new System.Drawing.Size(21, 14);
            this.labelParser.TabIndex = 6;
            this.labelParser.Text = "0%";
            // 
            // tabPageManger
            // 
            this.tabPageManger.Controls.Add(this.dataGridViewManager);
            this.tabPageManger.Controls.Add(this.panel1);
            this.tabPageManger.Location = new System.Drawing.Point(4, 22);
            this.tabPageManger.Name = "tabPageManger";
            this.tabPageManger.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageManger.Size = new System.Drawing.Size(855, 497);
            this.tabPageManger.TabIndex = 1;
            this.tabPageManger.Text = "解析结果校验";
            this.tabPageManger.UseVisualStyleBackColor = true;
            // 
            // dataGridViewManager
            // 
            this.dataGridViewManager.AllowUserToAddRows = false;
            this.dataGridViewManager.AllowUserToResizeRows = false;
            this.dataGridViewManager.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewManager.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewManager.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewManager.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.msgId,
            this.time,
            this.msgText,
            this.quotetype,
            this.statu,
            this.pass,
            this.modify});
            this.dataGridViewManager.Location = new System.Drawing.Point(7, 7);
            this.dataGridViewManager.MultiSelect = false;
            this.dataGridViewManager.Name = "dataGridViewManager";
            this.dataGridViewManager.ReadOnly = true;
            this.dataGridViewManager.RowHeadersVisible = false;
            this.dataGridViewManager.RowTemplate.Height = 23;
            this.dataGridViewManager.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewManager.Size = new System.Drawing.Size(840, 446);
            this.dataGridViewManager.TabIndex = 1;
            this.dataGridViewManager.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewManager_CellContentClick);
            this.dataGridViewManager.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewManager_CellDoubleClick);
            // 
            // msgId
            // 
            this.msgId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.msgId.FillWeight = 10F;
            this.msgId.HeaderText = "消息ID";
            this.msgId.Name = "msgId";
            this.msgId.ReadOnly = true;
            // 
            // time
            // 
            this.time.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.time.FillWeight = 10F;
            this.time.HeaderText = "日期";
            this.time.Name = "time";
            this.time.ReadOnly = true;
            // 
            // msgText
            // 
            this.msgText.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.msgText.FillWeight = 40F;
            this.msgText.HeaderText = "原始文本";
            this.msgText.Name = "msgText";
            this.msgText.ReadOnly = true;
            // 
            // quotetype
            // 
            this.quotetype.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.quotetype.FillWeight = 10F;
            this.quotetype.HeaderText = "报价类型";
            this.quotetype.Name = "quotetype";
            this.quotetype.ReadOnly = true;
            // 
            // statu
            // 
            this.statu.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.statu.FillWeight = 10F;
            this.statu.HeaderText = "状态";
            this.statu.Name = "statu";
            this.statu.ReadOnly = true;
            // 
            // pass
            // 
            this.pass.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.pass.FillWeight = 10F;
            this.pass.HeaderText = "确认";
            this.pass.Name = "pass";
            this.pass.ReadOnly = true;
            this.pass.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // modify
            // 
            this.modify.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.modify.FillWeight = 10F;
            this.modify.HeaderText = "修改";
            this.modify.Name = "modify";
            this.modify.ReadOnly = true;
            this.modify.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.buttonInsertMsg);
            this.panel1.Controls.Add(this.buttonShowQuote);
            this.panel1.Controls.Add(this.comboBoxShowQuote);
            this.panel1.Controls.Add(this.textBoxQuery);
            this.panel1.Controls.Add(this.buttonQuery);
            this.panel1.Controls.Add(this.textBoxPageNum);
            this.panel1.Controls.Add(this.buttonNextPage);
            this.panel1.Controls.Add(this.buttonLastPage);
            this.panel1.Controls.Add(this.buttonPrePage);
            this.panel1.Controls.Add(this.buttonFirstPage);
            this.panel1.Location = new System.Drawing.Point(8, 459);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(839, 30);
            this.panel1.TabIndex = 0;
            // 
            // buttonInsertMsg
            // 
            this.buttonInsertMsg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonInsertMsg.Location = new System.Drawing.Point(312, 3);
            this.buttonInsertMsg.Name = "buttonInsertMsg";
            this.buttonInsertMsg.Size = new System.Drawing.Size(75, 24);
            this.buttonInsertMsg.TabIndex = 9;
            this.buttonInsertMsg.Text = "插入报价";
            this.buttonInsertMsg.UseVisualStyleBackColor = true;
            this.buttonInsertMsg.Click += new System.EventHandler(this.buttonInsertMsg_Click);
            // 
            // buttonShowQuote
            // 
            this.buttonShowQuote.Location = new System.Drawing.Point(231, 4);
            this.buttonShowQuote.Name = "buttonShowQuote";
            this.buttonShowQuote.Size = new System.Drawing.Size(75, 23);
            this.buttonShowQuote.TabIndex = 8;
            this.buttonShowQuote.Text = "当前显示";
            this.buttonShowQuote.UseVisualStyleBackColor = true;
            this.buttonShowQuote.Click += new System.EventHandler(this.buttonShowQuote_Click);
            // 
            // comboBoxShowQuote
            // 
            this.comboBoxShowQuote.FormattingEnabled = true;
            this.comboBoxShowQuote.Items.AddRange(new object[] {
            "全部",
            "债券报价",
            "线上资金报价",
            "今日成交"});
            this.comboBoxShowQuote.Location = new System.Drawing.Point(120, 6);
            this.comboBoxShowQuote.Name = "comboBoxShowQuote";
            this.comboBoxShowQuote.Size = new System.Drawing.Size(105, 20);
            this.comboBoxShowQuote.TabIndex = 7;
            // 
            // textBoxQuery
            // 
            this.textBoxQuery.Location = new System.Drawing.Point(3, 6);
            this.textBoxQuery.Name = "textBoxQuery";
            this.textBoxQuery.Size = new System.Drawing.Size(61, 21);
            this.textBoxQuery.TabIndex = 6;
            this.textBoxQuery.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxQuery_KeyPress);
            // 
            // buttonQuery
            // 
            this.buttonQuery.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonQuery.Location = new System.Drawing.Point(70, 4);
            this.buttonQuery.Name = "buttonQuery";
            this.buttonQuery.Size = new System.Drawing.Size(44, 23);
            this.buttonQuery.TabIndex = 5;
            this.buttonQuery.Text = "查询";
            this.buttonQuery.UseVisualStyleBackColor = true;
            this.buttonQuery.Click += new System.EventHandler(this.buttonQuery_Click);
            // 
            // textBoxPageNum
            // 
            this.textBoxPageNum.AcceptsReturn = true;
            this.textBoxPageNum.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPageNum.Location = new System.Drawing.Point(713, 6);
            this.textBoxPageNum.Name = "textBoxPageNum";
            this.textBoxPageNum.Size = new System.Drawing.Size(44, 21);
            this.textBoxPageNum.TabIndex = 4;
            this.textBoxPageNum.Text = "1";
            this.textBoxPageNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxPageNum.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxPageNum_KeyPress);
            // 
            // buttonNextPage
            // 
            this.buttonNextPage.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonNextPage.Location = new System.Drawing.Point(763, 0);
            this.buttonNextPage.Name = "buttonNextPage";
            this.buttonNextPage.Size = new System.Drawing.Size(38, 30);
            this.buttonNextPage.TabIndex = 3;
            this.buttonNextPage.Text = "向后";
            this.buttonNextPage.UseVisualStyleBackColor = true;
            this.buttonNextPage.Click += new System.EventHandler(this.buttonNextPage_Click);
            // 
            // buttonLastPage
            // 
            this.buttonLastPage.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonLastPage.Location = new System.Drawing.Point(801, 0);
            this.buttonLastPage.Name = "buttonLastPage";
            this.buttonLastPage.Size = new System.Drawing.Size(38, 30);
            this.buttonLastPage.TabIndex = 2;
            this.buttonLastPage.Text = "尾页";
            this.buttonLastPage.UseVisualStyleBackColor = true;
            this.buttonLastPage.Click += new System.EventHandler(this.buttonLastPage_Click);
            // 
            // buttonPrePage
            // 
            this.buttonPrePage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPrePage.Location = new System.Drawing.Point(669, 4);
            this.buttonPrePage.Name = "buttonPrePage";
            this.buttonPrePage.Size = new System.Drawing.Size(38, 23);
            this.buttonPrePage.TabIndex = 1;
            this.buttonPrePage.Text = "向前";
            this.buttonPrePage.UseVisualStyleBackColor = true;
            this.buttonPrePage.Click += new System.EventHandler(this.buttonPrePage_Click);
            // 
            // buttonFirstPage
            // 
            this.buttonFirstPage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonFirstPage.Location = new System.Drawing.Point(625, 4);
            this.buttonFirstPage.Name = "buttonFirstPage";
            this.buttonFirstPage.Size = new System.Drawing.Size(38, 23);
            this.buttonFirstPage.TabIndex = 0;
            this.buttonFirstPage.Text = "首页";
            this.buttonFirstPage.UseVisualStyleBackColor = true;
            this.buttonFirstPage.Click += new System.EventHandler(this.buttonFirstPage_Click);
            // 
            // tabPageTest
            // 
            this.tabPageTest.Controls.Add(this.dataGridViewResult);
            this.tabPageTest.Controls.Add(this.panel2);
            this.tabPageTest.Location = new System.Drawing.Point(4, 22);
            this.tabPageTest.Name = "tabPageTest";
            this.tabPageTest.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTest.Size = new System.Drawing.Size(855, 497);
            this.tabPageTest.TabIndex = 2;
            this.tabPageTest.Text = "报价回测";
            this.tabPageTest.UseVisualStyleBackColor = true;
            // 
            // dataGridViewResult
            // 
            this.dataGridViewResult.AllowUserToAddRows = false;
            this.dataGridViewResult.AllowUserToResizeRows = false;
            this.dataGridViewResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewResult.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewResult.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridViewResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TestId,
            this.TestMsgText,
            this.TestParserType,
            this.TestType});
            this.dataGridViewResult.Location = new System.Drawing.Point(3, 45);
            this.dataGridViewResult.Name = "dataGridViewResult";
            this.dataGridViewResult.ReadOnly = true;
            this.dataGridViewResult.RowHeadersVisible = false;
            this.dataGridViewResult.RowTemplate.Height = 23;
            this.dataGridViewResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewResult.Size = new System.Drawing.Size(852, 449);
            this.dataGridViewResult.TabIndex = 1;
            this.dataGridViewResult.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewResult_CellDoubleClick);
            // 
            // TestId
            // 
            this.TestId.HeaderText = "ID";
            this.TestId.Name = "TestId";
            this.TestId.ReadOnly = true;
            // 
            // TestMsgText
            // 
            this.TestMsgText.HeaderText = "原始文本";
            this.TestMsgText.Name = "TestMsgText";
            this.TestMsgText.ReadOnly = true;
            // 
            // TestParserType
            // 
            this.TestParserType.HeaderText = "解析类型";
            this.TestParserType.Name = "TestParserType";
            this.TestParserType.ReadOnly = true;
            // 
            // TestType
            // 
            this.TestType.HeaderText = "实际类型";
            this.TestType.Name = "TestType";
            this.TestType.ReadOnly = true;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.comboBoxType);
            this.panel2.Controls.Add(this.labelResult);
            this.panel2.Controls.Add(this.buttonTest);
            this.panel2.Location = new System.Drawing.Point(9, 7);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(838, 32);
            this.panel2.TabIndex = 0;
            // 
            // comboBoxType
            // 
            this.comboBoxType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxType.FormattingEnabled = true;
            this.comboBoxType.Items.AddRange(new object[] {
            "报价分类",
            "债券报价",
            "线上资金报价"});
            this.comboBoxType.Location = new System.Drawing.Point(660, 7);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(94, 20);
            this.comboBoxType.TabIndex = 2;
            // 
            // labelResult
            // 
            this.labelResult.AutoSize = true;
            this.labelResult.Location = new System.Drawing.Point(3, 10);
            this.labelResult.Name = "labelResult";
            this.labelResult.Size = new System.Drawing.Size(0, 12);
            this.labelResult.TabIndex = 1;
            // 
            // buttonTest
            // 
            this.buttonTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonTest.Location = new System.Drawing.Point(760, 3);
            this.buttonTest.Name = "buttonTest";
            this.buttonTest.Size = new System.Drawing.Size(75, 26);
            this.buttonTest.TabIndex = 0;
            this.buttonTest.Text = "开始回测";
            this.buttonTest.UseVisualStyleBackColor = true;
            this.buttonTest.Click += new System.EventHandler(this.buttonTest_Click);
            // 
            // contextMenuStripMod
            // 
            this.contextMenuStripMod.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.onlineToolStripMenuItem,
            this.bondToolStripMenuItem,
            this.rangeToolStripMenuItem,
            this.otherToolStripMenuItem,
            this.noToolStripMenuItem});
            this.contextMenuStripMod.Name = "contextMenuStripMod";
            this.contextMenuStripMod.Size = new System.Drawing.Size(149, 114);
            // 
            // onlineToolStripMenuItem
            // 
            this.onlineToolStripMenuItem.Name = "onlineToolStripMenuItem";
            this.onlineToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.onlineToolStripMenuItem.Text = "线上资金报价";
            this.onlineToolStripMenuItem.Click += new System.EventHandler(this.onlineToolStripMenuItem_Click);
            // 
            // bondToolStripMenuItem
            // 
            this.bondToolStripMenuItem.Name = "bondToolStripMenuItem";
            this.bondToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.bondToolStripMenuItem.Text = "债券报价";
            this.bondToolStripMenuItem.Click += new System.EventHandler(this.bondToolStripMenuItem_Click);
            // 
            // rangeToolStripMenuItem
            // 
            this.rangeToolStripMenuItem.Name = "rangeToolStripMenuItem";
            this.rangeToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.rangeToolStripMenuItem.Text = "范围报价";
            this.rangeToolStripMenuItem.Click += new System.EventHandler(this.rangeToolStripMenuItem_Click);
            // 
            // otherToolStripMenuItem
            // 
            this.otherToolStripMenuItem.Name = "otherToolStripMenuItem";
            this.otherToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.otherToolStripMenuItem.Text = "其它报价";
            this.otherToolStripMenuItem.Click += new System.EventHandler(this.otherToolStripMenuItem_Click);
            // 
            // noToolStripMenuItem
            // 
            this.noToolStripMenuItem.Name = "noToolStripMenuItem";
            this.noToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.noToolStripMenuItem.Text = "不是报价";
            this.noToolStripMenuItem.Click += new System.EventHandler(this.noToolStripMenuItem_Click);
            // 
            // ManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 523);
            this.Controls.Add(this.tabControlMain);
            this.Name = "ManagerForm";
            this.Text = "报价分类管理器";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ManagerForm_FormClosing);
            this.groupBoxSrc.ResumeLayout(false);
            this.groupBoxSrc.PerformLayout();
            this.groupBoxDis.ResumeLayout(false);
            this.groupBoxDis.PerformLayout();
            this.tabControlMain.ResumeLayout(false);
            this.tabPageParser.ResumeLayout(false);
            this.tabPageParser.PerformLayout();
            this.tabPageManger.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewManager)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPageTest.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResult)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.contextMenuStripMod.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxSrc;
        private System.Windows.Forms.TextBox textBoxSrcHost;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxSrcTableName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBoxDis;
        private System.Windows.Forms.TextBox textBoxDisDbName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxDisHost;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ProgressBar progressBarParser;
        private System.Windows.Forms.Button buttonParser;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageParser;
        private System.Windows.Forms.TabPage tabPageManger;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBoxPageNum;
        private System.Windows.Forms.Button buttonNextPage;
        private System.Windows.Forms.Button buttonLastPage;
        private System.Windows.Forms.Button buttonPrePage;
        private System.Windows.Forms.Button buttonFirstPage;
        private System.Windows.Forms.DataGridView dataGridViewManager;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripMod;
        private System.Windows.Forms.ToolStripMenuItem onlineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bondToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rangeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem otherToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem noToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPageTest;
        private System.Windows.Forms.DataGridView dataGridViewResult;
        private System.Windows.Forms.DataGridViewTextBoxColumn TestId;
        private System.Windows.Forms.DataGridViewTextBoxColumn TestMsgText;
        private System.Windows.Forms.DataGridViewTextBoxColumn TestParserType;
        private System.Windows.Forms.DataGridViewTextBoxColumn TestType;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labelResult;
        private System.Windows.Forms.Button buttonTest;
        private System.Windows.Forms.ComboBox comboBoxType;
        private System.Windows.Forms.DataGridViewTextBoxColumn msgId;
        private System.Windows.Forms.DataGridViewTextBoxColumn time;
        private System.Windows.Forms.DataGridViewTextBoxColumn msgText;
        private System.Windows.Forms.DataGridViewTextBoxColumn quotetype;
        private System.Windows.Forms.DataGridViewTextBoxColumn statu;
        private System.Windows.Forms.DataGridViewButtonColumn pass;
        private System.Windows.Forms.DataGridViewLinkColumn modify;
        private System.Windows.Forms.Button buttonQuery;
        private System.Windows.Forms.TextBox textBoxQuery;
        private System.Windows.Forms.ComboBox comboBoxShowQuote;
        private System.Windows.Forms.Button buttonShowQuote;
        private System.Windows.Forms.Label labelParser;
        private System.Windows.Forms.ComboBox comboBoxParser;
        private System.Windows.Forms.Button buttonInsertMsg;
    }
}

