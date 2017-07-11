namespace QuoteClassify.form
{
    partial class QuoteModForm
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
            this.dataGridViewQuoteInfo = new System.Windows.Forms.DataGridView();
            this.text = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.direction = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.volume = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceTag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.probobility = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonOK = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.richTextBoxMsgText = new System.Windows.Forms.RichTextBox();
            this.contextMenuStripDel = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItemDel = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewQuoteInfo)).BeginInit();
            this.panel1.SuspendLayout();
            this.contextMenuStripDel.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewQuoteInfo
            // 
            this.dataGridViewQuoteInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewQuoteInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewQuoteInfo.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridViewQuoteInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewQuoteInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.text,
            this.direction,
            this.code,
            this.name,
            this.volume,
            this.price,
            this.priceTag,
            this.probobility});
            this.dataGridViewQuoteInfo.Location = new System.Drawing.Point(12, 188);
            this.dataGridViewQuoteInfo.Name = "dataGridViewQuoteInfo";
            this.dataGridViewQuoteInfo.RowHeadersVisible = false;
            this.dataGridViewQuoteInfo.RowTemplate.Height = 23;
            this.dataGridViewQuoteInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridViewQuoteInfo.Size = new System.Drawing.Size(1134, 420);
            this.dataGridViewQuoteInfo.TabIndex = 0;
            this.dataGridViewQuoteInfo.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewBondQuoteInfo_CellMouseClick);
            // 
            // text
            // 
            this.text.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.text.FillWeight = 40F;
            this.text.HeaderText = "文本";
            this.text.Name = "text";
            // 
            // direction
            // 
            this.direction.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.direction.FillWeight = 5F;
            this.direction.HeaderText = "方向";
            this.direction.Name = "direction";
            // 
            // code
            // 
            this.code.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.code.FillWeight = 10F;
            this.code.HeaderText = "代码";
            this.code.Name = "code";
            // 
            // name
            // 
            this.name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.name.FillWeight = 15F;
            this.name.HeaderText = "名称";
            this.name.Name = "name";
            // 
            // volume
            // 
            this.volume.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.volume.FillWeight = 8F;
            this.volume.HeaderText = "数量";
            this.volume.Name = "volume";
            // 
            // price
            // 
            this.price.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.price.FillWeight = 8F;
            this.price.HeaderText = "价格";
            this.price.Name = "price";
            // 
            // priceTag
            // 
            this.priceTag.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.priceTag.FillWeight = 8F;
            this.priceTag.HeaderText = "价格标签";
            this.priceTag.Name = "priceTag";
            // 
            // probobility
            // 
            this.probobility.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.probobility.FillWeight = 6F;
            this.probobility.HeaderText = "可信度";
            this.probobility.Name = "probobility";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.buttonOK);
            this.panel1.Location = new System.Drawing.Point(12, 614);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1134, 42);
            this.panel1.TabIndex = 1;
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOK.Location = new System.Drawing.Point(1041, 3);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(90, 36);
            this.buttonOK.TabIndex = 0;
            this.buttonOK.Text = "确定";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(1068, 159);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "复制原文";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // richTextBoxMsgText
            // 
            this.richTextBoxMsgText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxMsgText.Location = new System.Drawing.Point(13, 13);
            this.richTextBoxMsgText.Name = "richTextBoxMsgText";
            this.richTextBoxMsgText.ReadOnly = true;
            this.richTextBoxMsgText.Size = new System.Drawing.Size(1133, 140);
            this.richTextBoxMsgText.TabIndex = 4;
            this.richTextBoxMsgText.Text = "";
            // 
            // contextMenuStripDel
            // 
            this.contextMenuStripDel.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemDel});
            this.contextMenuStripDel.Name = "contextMenuStripDel";
            this.contextMenuStripDel.Size = new System.Drawing.Size(153, 48);
            // 
            // ToolStripMenuItemDel
            // 
            this.ToolStripMenuItemDel.Name = "ToolStripMenuItemDel";
            this.ToolStripMenuItemDel.Size = new System.Drawing.Size(152, 22);
            this.ToolStripMenuItemDel.Text = "删除该行";
            this.ToolStripMenuItemDel.Click += new System.EventHandler(this.ToolStripMenuItemDel_Click);
            // 
            // QuoteModForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1158, 668);
            this.Controls.Add(this.richTextBoxMsgText);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridViewQuoteInfo);
            this.Name = "QuoteModForm";
            this.Text = "债券报价信息";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewQuoteInfo)).EndInit();
            this.panel1.ResumeLayout(false);
            this.contextMenuStripDel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewQuoteInfo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.DataGridViewTextBoxColumn text;
        private System.Windows.Forms.DataGridViewTextBoxColumn direction;
        private System.Windows.Forms.DataGridViewTextBoxColumn code;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn volume;
        private System.Windows.Forms.DataGridViewTextBoxColumn price;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceTag;
        private System.Windows.Forms.DataGridViewTextBoxColumn probobility;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox richTextBoxMsgText;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripDel;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemDel;
    }
}