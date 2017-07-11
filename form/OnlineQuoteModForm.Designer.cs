namespace QuoteClassify.form
{
    partial class OnlineQuoteModForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.richTextBoxMsgText = new System.Windows.Forms.RichTextBox();
            this.dataGridViewOnlineQuoteInfo = new System.Windows.Forms.DataGridView();
            this.direction = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.probility = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonOK = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuStripOnlineDel = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOnlineQuoteInfo)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBoxMsgText
            // 
            this.richTextBoxMsgText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxMsgText.Location = new System.Drawing.Point(12, 12);
            this.richTextBoxMsgText.Name = "richTextBoxMsgText";
            this.richTextBoxMsgText.Size = new System.Drawing.Size(785, 112);
            this.richTextBoxMsgText.TabIndex = 0;
            this.richTextBoxMsgText.Text = "";
            // 
            // dataGridViewOnlineQuoteInfo
            // 
            this.dataGridViewOnlineQuoteInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewOnlineQuoteInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewOnlineQuoteInfo.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridViewOnlineQuoteInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOnlineQuoteInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.direction,
            this.amount,
            this.tenor,
            this.type,
            this.tag,
            this.price,
            this.probility});
            this.dataGridViewOnlineQuoteInfo.Location = new System.Drawing.Point(12, 164);
            this.dataGridViewOnlineQuoteInfo.Name = "dataGridViewOnlineQuoteInfo";
            this.dataGridViewOnlineQuoteInfo.RowHeadersVisible = false;
            this.dataGridViewOnlineQuoteInfo.RowTemplate.Height = 23;
            this.dataGridViewOnlineQuoteInfo.Size = new System.Drawing.Size(785, 168);
            this.dataGridViewOnlineQuoteInfo.TabIndex = 1;
            this.dataGridViewOnlineQuoteInfo.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewOnlineQuoteInfo_CellMouseClick);
            // 
            // direction
            // 
            this.direction.HeaderText = "方向";
            this.direction.Name = "direction";
            // 
            // amount
            // 
            this.amount.HeaderText = "数量";
            this.amount.Name = "amount";
            // 
            // tenor
            // 
            this.tenor.HeaderText = "期限";
            this.tenor.Name = "tenor";
            // 
            // type
            // 
            this.type.HeaderText = "类型";
            this.type.Name = "type";
            // 
            // tag
            // 
            this.tag.HeaderText = "标签";
            this.tag.Name = "tag";
            // 
            // price
            // 
            this.price.HeaderText = "价格";
            this.price.Name = "price";
            // 
            // probility
            // 
            this.probility.HeaderText = "可信度";
            this.probility.Name = "probility";
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOK.Location = new System.Drawing.Point(722, 338);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 29);
            this.buttonOK.TabIndex = 2;
            this.buttonOK.Text = "确认";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(722, 130);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 28);
            this.button1.TabIndex = 3;
            this.button1.Text = "复制原文";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextMenuStripOnlineDel});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 26);
            // 
            // contextMenuStripOnlineDel
            // 
            this.contextMenuStripOnlineDel.Name = "contextMenuStripOnlineDel";
            this.contextMenuStripOnlineDel.Size = new System.Drawing.Size(124, 22);
            this.contextMenuStripOnlineDel.Text = "删除改行";
            this.contextMenuStripOnlineDel.Click += new System.EventHandler(this.contextMenuStripOnlineDel_Click);
            // 
            // OnlineQuoteModForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 452);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.dataGridViewOnlineQuoteInfo);
            this.Controls.Add(this.richTextBoxMsgText);
            this.Name = "OnlineQuoteModForm";
            this.Text = "线上资金报价信息";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOnlineQuoteInfo)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBoxMsgText;
        private System.Windows.Forms.DataGridView dataGridViewOnlineQuoteInfo;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.DataGridViewTextBoxColumn direction;
        private System.Windows.Forms.DataGridViewTextBoxColumn amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenor;
        private System.Windows.Forms.DataGridViewTextBoxColumn type;
        private System.Windows.Forms.DataGridViewTextBoxColumn tag;
        private System.Windows.Forms.DataGridViewTextBoxColumn price;
        private System.Windows.Forms.DataGridViewTextBoxColumn probility;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem contextMenuStripOnlineDel;

    }
}