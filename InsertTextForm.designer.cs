namespace PageMapMenuBar
{
    partial class InsertTextForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InsertTextForm));
            this.btnOK = new System.Windows.Forms.Button();
            this.cmbxSize = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbxFont = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txbxInsertText = new System.Windows.Forms.TextBox();
            this.lblTextContent = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnColor = new System.Windows.Forms.Button();
            this.btnItalic = new System.Windows.Forms.Button();
            this.btnBold = new System.Windows.Forms.Button();
            this.btnUnderLine = new System.Windows.Forms.Button();
            this.btnStrikethrough = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.nmrcUpDownAngle = new System.Windows.Forms.NumericUpDown();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nmrcUpDownAngle)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(175, 286);
            this.btnOK.Margin = new System.Windows.Forms.Padding(2);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 27);
            this.btnOK.TabIndex = 14;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // cmbxSize
            // 
            this.cmbxSize.FormattingEnabled = true;
            this.cmbxSize.Items.AddRange(new object[] {
            "5",
            "10",
            "15",
            "20",
            "25",
            "30",
            "35",
            "40",
            "45",
            "50"});
            this.cmbxSize.Location = new System.Drawing.Point(257, 175);
            this.cmbxSize.Margin = new System.Windows.Forms.Padding(2);
            this.cmbxSize.Name = "cmbxSize";
            this.cmbxSize.Size = new System.Drawing.Size(72, 20);
            this.cmbxSize.TabIndex = 12;
            this.cmbxSize.SelectedIndexChanged += new System.EventHandler(this.cmbxSize_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(211, 179);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "大小：";
            // 
            // cmbxFont
            // 
            this.cmbxFont.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxFont.FormattingEnabled = true;
            this.cmbxFont.Location = new System.Drawing.Point(57, 176);
            this.cmbxFont.Margin = new System.Windows.Forms.Padding(2);
            this.cmbxFont.Name = "cmbxFont";
            this.cmbxFont.Size = new System.Drawing.Size(126, 20);
            this.cmbxFont.TabIndex = 10;
            this.cmbxFont.SelectedIndexChanged += new System.EventHandler(this.cmbxFont_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 178);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "字体：";
            // 
            // txbxInsertText
            // 
            this.txbxInsertText.Location = new System.Drawing.Point(14, 35);
            this.txbxInsertText.Margin = new System.Windows.Forms.Padding(2);
            this.txbxInsertText.Multiline = true;
            this.txbxInsertText.Name = "txbxInsertText";
            this.txbxInsertText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txbxInsertText.Size = new System.Drawing.Size(317, 118);
            this.txbxInsertText.TabIndex = 8;
            // 
            // lblTextContent
            // 
            this.lblTextContent.AutoSize = true;
            this.lblTextContent.Location = new System.Drawing.Point(16, 15);
            this.lblTextContent.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTextContent.Name = "lblTextContent";
            this.lblTextContent.Size = new System.Drawing.Size(65, 12);
            this.lblTextContent.TabIndex = 7;
            this.lblTextContent.Text = "文本内容：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 208);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "样式：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(211, 209);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "颜色：";
            // 
            // btnColor
            // 
            this.btnColor.BackColor = System.Drawing.Color.Black;
            this.btnColor.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnColor.Location = new System.Drawing.Point(257, 200);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(72, 28);
            this.btnColor.TabIndex = 15;
            this.btnColor.UseVisualStyleBackColor = false;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // btnItalic
            // 
            this.btnItalic.BackColor = System.Drawing.Color.Transparent;
            this.btnItalic.FlatAppearance.BorderSize = 0;
            this.btnItalic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnItalic.ForeColor = System.Drawing.Color.Transparent;
            this.btnItalic.Image = ((System.Drawing.Image)(resources.GetObject("btnItalic.Image")));
            this.btnItalic.Location = new System.Drawing.Point(95, 205);
            this.btnItalic.Name = "btnItalic";
            this.btnItalic.Size = new System.Drawing.Size(16, 16);
            this.btnItalic.TabIndex = 18;
            this.btnItalic.UseVisualStyleBackColor = false;
            this.btnItalic.Click += new System.EventHandler(this.btnItalic_Click);
            // 
            // btnBold
            // 
            this.btnBold.BackColor = System.Drawing.Color.Transparent;
            this.btnBold.FlatAppearance.BorderSize = 0;
            this.btnBold.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBold.ForeColor = System.Drawing.Color.Transparent;
            this.btnBold.Image = ((System.Drawing.Image)(resources.GetObject("btnBold.Image")));
            this.btnBold.Location = new System.Drawing.Point(65, 205);
            this.btnBold.Name = "btnBold";
            this.btnBold.Size = new System.Drawing.Size(16, 16);
            this.btnBold.TabIndex = 18;
            this.btnBold.UseVisualStyleBackColor = false;
            this.btnBold.Click += new System.EventHandler(this.btnBold_Click);
            // 
            // btnUnderLine
            // 
            this.btnUnderLine.BackColor = System.Drawing.Color.Transparent;
            this.btnUnderLine.FlatAppearance.BorderSize = 0;
            this.btnUnderLine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUnderLine.ForeColor = System.Drawing.Color.Transparent;
            this.btnUnderLine.Image = ((System.Drawing.Image)(resources.GetObject("btnUnderLine.Image")));
            this.btnUnderLine.Location = new System.Drawing.Point(125, 205);
            this.btnUnderLine.Name = "btnUnderLine";
            this.btnUnderLine.Size = new System.Drawing.Size(16, 16);
            this.btnUnderLine.TabIndex = 18;
            this.btnUnderLine.UseVisualStyleBackColor = false;
            this.btnUnderLine.Click += new System.EventHandler(this.btnUnderLine_Click);
            // 
            // btnStrikethrough
            // 
            this.btnStrikethrough.BackColor = System.Drawing.Color.Transparent;
            this.btnStrikethrough.FlatAppearance.BorderSize = 0;
            this.btnStrikethrough.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStrikethrough.ForeColor = System.Drawing.Color.Transparent;
            this.btnStrikethrough.Image = ((System.Drawing.Image)(resources.GetObject("btnStrikethrough.Image")));
            this.btnStrikethrough.Location = new System.Drawing.Point(155, 205);
            this.btnStrikethrough.Name = "btnStrikethrough";
            this.btnStrikethrough.Size = new System.Drawing.Size(16, 16);
            this.btnStrikethrough.TabIndex = 18;
            this.btnStrikethrough.UseVisualStyleBackColor = false;
            this.btnStrikethrough.Click += new System.EventHandler(this.btnStrikethrough_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(211, 240);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 11;
            this.label6.Text = "角度：";
            // 
            // nmrcUpDownAngle
            // 
            this.nmrcUpDownAngle.DecimalPlaces = 2;
            this.nmrcUpDownAngle.Location = new System.Drawing.Point(257, 236);
            this.nmrcUpDownAngle.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.nmrcUpDownAngle.Name = "nmrcUpDownAngle";
            this.nmrcUpDownAngle.Size = new System.Drawing.Size(72, 21);
            this.nmrcUpDownAngle.TabIndex = 19;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(254, 286);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 27);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // InsertTextForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 324);
            this.Controls.Add(this.nmrcUpDownAngle);
            this.Controls.Add(this.btnBold);
            this.Controls.Add(this.btnStrikethrough);
            this.Controls.Add(this.btnUnderLine);
            this.Controls.Add(this.btnItalic);
            this.Controls.Add(this.btnColor);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.cmbxSize);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbxFont);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txbxInsertText);
            this.Controls.Add(this.lblTextContent);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InsertTextForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "插入文本";
            ((System.ComponentModel.ISupportInitialize)(this.nmrcUpDownAngle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.ComboBox cmbxSize;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbxFont;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbxInsertText;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.Button btnItalic;
        private System.Windows.Forms.Button btnBold;
        private System.Windows.Forms.Button btnUnderLine;
        private System.Windows.Forms.Button btnStrikethrough;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nmrcUpDownAngle;
        private System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.Label lblTextContent;
    }
}