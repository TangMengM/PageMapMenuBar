namespace PageMapMenuBar
{
    partial class InsertScaleBarForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InsertScaleBarForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.symbolPictureBox = new System.Windows.Forms.PictureBox();
            this.labelFillColorCaption = new System.Windows.Forms.Label();
            this.btnTextColor = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbxUnit = new System.Windows.Forms.ComboBox();
            this.cmbxTextFont = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbxTextSize = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSymbolColor = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbxSymbolSize = new System.Windows.Forms.ComboBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.axSymbologyControl1 = new ESRI.ArcGIS.Controls.AxSymbologyControl();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.symbolPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axSymbologyControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.symbolPictureBox);
            this.groupBox1.Location = new System.Drawing.Point(280, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(176, 154);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "预览";
            // 
            // symbolPictureBox
            // 
            this.symbolPictureBox.Location = new System.Drawing.Point(30, 20);
            this.symbolPictureBox.Name = "symbolPictureBox";
            this.symbolPictureBox.Size = new System.Drawing.Size(120, 120);
            this.symbolPictureBox.TabIndex = 1;
            this.symbolPictureBox.TabStop = false;
            // 
            // labelFillColorCaption
            // 
            this.labelFillColorCaption.AutoSize = true;
            this.labelFillColorCaption.Location = new System.Drawing.Point(278, 253);
            this.labelFillColorCaption.Name = "labelFillColorCaption";
            this.labelFillColorCaption.Size = new System.Drawing.Size(65, 12);
            this.labelFillColorCaption.TabIndex = 2;
            this.labelFillColorCaption.Text = "文本颜色：";
            // 
            // btnTextColor
            // 
            this.btnTextColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTextColor.BackColor = System.Drawing.Color.Black;
            this.btnTextColor.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnTextColor.Location = new System.Drawing.Point(342, 244);
            this.btnTextColor.Name = "btnTextColor";
            this.btnTextColor.Size = new System.Drawing.Size(107, 28);
            this.btnTextColor.TabIndex = 2;
            this.btnTextColor.UseVisualStyleBackColor = false;
            this.btnTextColor.Click += new System.EventHandler(this.btnTextColor_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Location = new System.Drawing.Point(339, 358);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(60, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOK.Location = new System.Drawing.Point(277, 358);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(60, 23);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(278, 168);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "单    位：";
            // 
            // cmbxUnit
            // 
            this.cmbxUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxUnit.FormattingEnabled = true;
            this.cmbxUnit.Location = new System.Drawing.Point(342, 165);
            this.cmbxUnit.Name = "cmbxUnit";
            this.cmbxUnit.Size = new System.Drawing.Size(107, 20);
            this.cmbxUnit.TabIndex = 8;
            // 
            // cmbxTextFont
            // 
            this.cmbxTextFont.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxTextFont.FormattingEnabled = true;
            this.cmbxTextFont.Items.AddRange(new object[] {
            "Arial",
            "Times New Roman"});
            this.cmbxTextFont.Location = new System.Drawing.Point(342, 191);
            this.cmbxTextFont.Margin = new System.Windows.Forms.Padding(2);
            this.cmbxTextFont.Name = "cmbxTextFont";
            this.cmbxTextFont.Size = new System.Drawing.Size(107, 20);
            this.cmbxTextFont.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(278, 195);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 11;
            this.label2.Text = "文本字体：";
            // 
            // cmbxTextSize
            // 
            this.cmbxTextSize.FormattingEnabled = true;
            this.cmbxTextSize.Items.AddRange(new object[] {
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
            this.cmbxTextSize.Location = new System.Drawing.Point(342, 218);
            this.cmbxTextSize.Margin = new System.Windows.Forms.Padding(2);
            this.cmbxTextSize.Name = "cmbxTextSize";
            this.cmbxTextSize.Size = new System.Drawing.Size(107, 20);
            this.cmbxTextSize.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(278, 222);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 13;
            this.label3.Text = "文本大小：";
            // 
            // btnSymbolColor
            // 
            this.btnSymbolColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSymbolColor.BackColor = System.Drawing.Color.Black;
            this.btnSymbolColor.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSymbolColor.Location = new System.Drawing.Point(342, 303);
            this.btnSymbolColor.Name = "btnSymbolColor";
            this.btnSymbolColor.Size = new System.Drawing.Size(107, 28);
            this.btnSymbolColor.TabIndex = 2;
            this.btnSymbolColor.UseVisualStyleBackColor = false;
            this.btnSymbolColor.Click += new System.EventHandler(this.btnSymbolColor_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(278, 312);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "条块颜色：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(278, 283);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 13;
            this.label5.Text = "条块大小：";
            // 
            // cmbxSymbolSize
            // 
            this.cmbxSymbolSize.FormattingEnabled = true;
            this.cmbxSymbolSize.Items.AddRange(new object[] {
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
            this.cmbxSymbolSize.Location = new System.Drawing.Point(342, 278);
            this.cmbxSymbolSize.Margin = new System.Windows.Forms.Padding(2);
            this.cmbxSymbolSize.Name = "cmbxSymbolSize";
            this.cmbxSymbolSize.Size = new System.Drawing.Size(107, 20);
            this.cmbxSymbolSize.TabIndex = 14;
            // 
            // btnApply
            // 
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApply.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnApply.Location = new System.Drawing.Point(401, 358);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(60, 23);
            this.btnApply.TabIndex = 5;
            this.btnApply.Text = "应用";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // axSymbologyControl1
            // 
            this.axSymbologyControl1.Location = new System.Drawing.Point(12, 15);
            this.axSymbologyControl1.Name = "axSymbologyControl1";
            this.axSymbologyControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axSymbologyControl1.OcxState")));
            this.axSymbologyControl1.Size = new System.Drawing.Size(265, 265);
            this.axSymbologyControl1.TabIndex = 15;
            // 
            // InsertScaleBarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 386);
            this.Controls.Add(this.axSymbologyControl1);
            this.Controls.Add(this.cmbxSymbolSize);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbxTextSize);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbxTextFont);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbxUnit);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelFillColorCaption);
            this.Controls.Add(this.btnSymbolColor);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnTextColor);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox1);
            this.Name = "InsertScaleBarForm";
            this.Text = "比例尺选择器";
            this.Load += new System.EventHandler(this.InsertNorthArrowForm_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.symbolPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axSymbologyControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelFillColorCaption;
        private System.Windows.Forms.Button btnTextColor;
        private System.Windows.Forms.PictureBox symbolPictureBox;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbxUnit;
        private System.Windows.Forms.ComboBox cmbxTextFont;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbxTextSize;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSymbolColor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbxSymbolSize;
        private System.Windows.Forms.Button btnApply;
        private ESRI.ArcGIS.Controls.AxSymbologyControl axSymbologyControl1;
    }
}