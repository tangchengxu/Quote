namespace QuoteClassify.form
{
    partial class ContrastForm
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
            this.richTextBoxMsgText = new System.Windows.Forms.RichTextBox();
            this.dataGridViewParser = new System.Windows.Forms.DataGridView();
            this.labelMod = new System.Windows.Forms.Label();
            this.dataGridViewMod = new System.Windows.Forms.DataGridView();
            this.labelParser = new System.Windows.Forms.Label();
            this.buttonCopy = new System.Windows.Forms.Button();
            this.buttonCorrectParser = new System.Windows.Forms.Button();
            this.panelParser = new System.Windows.Forms.Panel();
            this.panelMod = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewParser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMod)).BeginInit();
            this.panelParser.SuspendLayout();
            this.panelMod.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBoxMsgText
            // 
            this.richTextBoxMsgText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxMsgText.Location = new System.Drawing.Point(10, -2);
            this.richTextBoxMsgText.Name = "richTextBoxMsgText";
            this.richTextBoxMsgText.ReadOnly = true;
            this.richTextBoxMsgText.Size = new System.Drawing.Size(1070, 200);
            this.richTextBoxMsgText.TabIndex = 0;
            this.richTextBoxMsgText.Text = "";
            // 
            // dataGridViewParser
            // 
            this.dataGridViewParser.AllowUserToAddRows = false;
            this.dataGridViewParser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewParser.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewParser.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridViewParser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewParser.Location = new System.Drawing.Point(10, 246);
            this.dataGridViewParser.Name = "dataGridViewParser";
            this.dataGridViewParser.RowHeadersVisible = false;
            this.dataGridViewParser.RowTemplate.Height = 23;
            this.dataGridViewParser.Size = new System.Drawing.Size(1074, 190);
            this.dataGridViewParser.TabIndex = 3;
            // 
            // labelMod
            // 
            this.labelMod.AutoSize = true;
            this.labelMod.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelMod.Location = new System.Drawing.Point(3, 9);
            this.labelMod.Name = "labelMod";
            this.labelMod.Size = new System.Drawing.Size(53, 12);
            this.labelMod.TabIndex = 4;
            this.labelMod.Text = "labelMod";
            // 
            // dataGridViewMod
            // 
            this.dataGridViewMod.AllowUserToAddRows = false;
            this.dataGridViewMod.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewMod.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewMod.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridViewMod.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMod.Location = new System.Drawing.Point(10, 484);
            this.dataGridViewMod.Name = "dataGridViewMod";
            this.dataGridViewMod.RowHeadersVisible = false;
            this.dataGridViewMod.RowTemplate.Height = 23;
            this.dataGridViewMod.Size = new System.Drawing.Size(1072, 190);
            this.dataGridViewMod.TabIndex = 5;
            // 
            // labelParser
            // 
            this.labelParser.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelParser.AutoSize = true;
            this.labelParser.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelParser.Location = new System.Drawing.Point(3, 9);
            this.labelParser.Name = "labelParser";
            this.labelParser.Size = new System.Drawing.Size(71, 12);
            this.labelParser.TabIndex = 2;
            this.labelParser.Text = "labelParser";
            // 
            // buttonCopy
            // 
            this.buttonCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCopy.Location = new System.Drawing.Point(992, 5);
            this.buttonCopy.Name = "buttonCopy";
            this.buttonCopy.Size = new System.Drawing.Size(75, 20);
            this.buttonCopy.TabIndex = 1;
            this.buttonCopy.Text = "复制原文";
            this.buttonCopy.UseVisualStyleBackColor = true;
            this.buttonCopy.Click += new System.EventHandler(this.buttonCopy_Click);
            // 
            // buttonCorrectParser
            // 
            this.buttonCorrectParser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCorrectParser.Location = new System.Drawing.Point(911, 5);
            this.buttonCorrectParser.Name = "buttonCorrectParser";
            this.buttonCorrectParser.Size = new System.Drawing.Size(75, 20);
            this.buttonCorrectParser.TabIndex = 3;
            this.buttonCorrectParser.Text = "解析正确";
            this.buttonCorrectParser.UseVisualStyleBackColor = true;
            this.buttonCorrectParser.Click += new System.EventHandler(this.buttonCorrectParser_Click);
            // 
            // panelParser
            // 
            this.panelParser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelParser.Controls.Add(this.buttonCorrectParser);
            this.panelParser.Controls.Add(this.labelParser);
            this.panelParser.Controls.Add(this.buttonCopy);
            this.panelParser.Location = new System.Drawing.Point(10, 215);
            this.panelParser.Name = "panelParser";
            this.panelParser.Size = new System.Drawing.Size(1070, 30);
            this.panelParser.TabIndex = 6;
            // 
            // panelMod
            // 
            this.panelMod.Controls.Add(this.labelMod);
            this.panelMod.Location = new System.Drawing.Point(10, 448);
            this.panelMod.Name = "panelMod";
            this.panelMod.Size = new System.Drawing.Size(1074, 30);
            this.panelMod.TabIndex = 7;
            // 
            // ContrastForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1096, 686);
            this.Controls.Add(this.panelMod);
            this.Controls.Add(this.panelParser);
            this.Controls.Add(this.dataGridViewMod);
            this.Controls.Add(this.dataGridViewParser);
            this.Controls.Add(this.richTextBoxMsgText);
            this.Name = "ContrastForm";
            this.Text = "ContrastForm";
            this.Resize += new System.EventHandler(this.ContrastForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewParser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMod)).EndInit();
            this.panelParser.ResumeLayout(false);
            this.panelParser.PerformLayout();
            this.panelMod.ResumeLayout(false);
            this.panelMod.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBoxMsgText;
        private System.Windows.Forms.DataGridView dataGridViewParser;
        private System.Windows.Forms.Label labelMod;
        private System.Windows.Forms.DataGridView dataGridViewMod;
        private System.Windows.Forms.Label labelParser;
        private System.Windows.Forms.Button buttonCopy;
        private System.Windows.Forms.Button buttonCorrectParser;
        private System.Windows.Forms.Panel panelParser;
        private System.Windows.Forms.Panel panelMod;
    }
}