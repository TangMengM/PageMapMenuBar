using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Display;
using stdole;

namespace PageMapMenuBar
{
    public partial class InsertTextForm : Form
    {
        private double _textAngle = 0;
        private IColor _textColor = ElementPropetyImp.GetRGBColor(Color.Red.R, Color.Red.G, Color.Red.B) as IColor;        
        private stdole.IFontDisp _textFont = new stdole.StdFontClass() as stdole.IFontDisp;
        private double _textSize = 0;
        private string _insertText = "未知文本";

        private double[] _sizeArr = {1,2,3,4,5,6,7,8,9,10,11,12,14,16,18,20,22,24,26,28,36,48,72 };

        /// <summary>
        /// 文本角度
        /// </summary>
        public double TextAngle
        {
            get { return _textAngle; }
        }

        /// <summary>
        /// 文本颜色
        /// </summary>
        public IColor TextColor
        {
            get { return _textColor; }
        }

        /// <summary>
        /// 文本字体
        /// </summary>
        public IFontDisp TextFont
        {
            get { return _textFont; }
        }

        /// <summary>
        /// 文字大小
        /// </summary>
        public double TextSize
        {
            get { return _textSize; }
        }

        /// <summary>
        /// 待插入文本
        /// </summary>
        public string InsertText
        {
            get { return _insertText; }
        }

        public InsertTextForm()
        {
            InitializeComponent();
            ////变量初始化
            //_textAngle = 0;
            //_textColor = ColorImp.GetRGBColor(Color.Red.R, Color.Red.G, Color.Red.B) as IColor;
            //_textFont = new stdole.StdFontClass() as stdole.IFontDisp;
            //_textFont.Name = FontType.宋体.ToString();
            //_textSize = 20;

            ////控件初始化
            //txbxInsertText.Text = "未知文本";
            //txbxInsertText.SelectAll();
            //cmbxFont.DataSource = System.Enum.GetNames(typeof(FontType));
            //cmbxFont.SelectedIndex = 0;
            //cmbxSize.DataSource = _sizeArr;
            //cmbxSize.SelectedIndex = this.cmbxSize.FindString("20");
            //btnColor.BackColor = Color.Red;

            IColor textColor = ElementPropetyImp.GetRGBColor(0,0,0) as IColor;
            IFontDisp textFont = new stdole.StdFontClass() as stdole.IFontDisp;
            textFont.Name = FontType.宋体.ToString();
            InitVariablesAndControls(0, textColor, textFont, 20, "未知文本");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="textAngle">角度</param>
        /// <param name="textColor">颜色</param>
        /// <param name="textFont">字体</param>
        /// <param name="textSize">大小</param>
        /// <param name="insertText">文本</param>
        public InsertTextForm(double textAngle, IColor textColor, IFontDisp textFont, double textSize, string insertText)
        {
            InitializeComponent();
            InitVariablesAndControls(textAngle, textColor, textFont, textSize, insertText);
        }

        private void InitVariablesAndControls(double textAngle, IColor textColor, IFontDisp textFont, double textSize, string insertText)
        {
            
            //控件初始化
            txbxInsertText.Text = insertText;
            txbxInsertText.SelectAll();
            cmbxFont.DataSource = System.Enum.GetNames(typeof(FontType));
            cmbxFont.SelectedIndex = cmbxFont.FindString(textFont.Name);
            cmbxSize.DataSource = _sizeArr;
            cmbxSize.Text = textSize.ToString();

            btnBold.FlatStyle = (textFont.Bold)? FlatStyle.Popup:FlatStyle.Flat;
            btnItalic.FlatStyle = (textFont.Italic) ? FlatStyle.Popup : FlatStyle.Flat;
            btnUnderLine.FlatStyle = (textFont.Underline) ? FlatStyle.Popup : FlatStyle.Flat;
            btnStrikethrough.FlatStyle = (textFont.Strikethrough) ? FlatStyle.Popup : FlatStyle.Flat;

            btnColor.BackColor = System.Drawing.Color.FromArgb((textColor as IRgbColor).Red, (textColor as IRgbColor).Green, (textColor as IRgbColor).Blue);
            nmrcUpDownAngle.Value = Convert.ToDecimal(textAngle);

            //变量初始化
            _textAngle = textAngle;
            _textColor = textColor;
            _textFont = textFont;
            _textSize = textSize;
            _insertText = insertText;
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            DialogResult result = colorDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                btnColor.BackColor = colorDialog.Color;
                _textColor = ElementPropetyImp.GetRGBColor(btnColor.BackColor.R, btnColor.BackColor.G, btnColor.BackColor.B) as IColor;
            }
        }      

        private void cmbxFont_SelectedIndexChanged(object sender, EventArgs e)
        {
            _textFont.Name = cmbxFont.Text;
        }

        private void cmbxSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            _textSize = Convert.ToDouble(cmbxSize.Text);
        }



        private void btnBold_Click(object sender, EventArgs e)
        {
            if (_textFont.Bold)
            {
                _textFont.Bold = false;
                btnBold.FlatStyle = FlatStyle.Flat;
            }
            else
            {
                _textFont.Bold = true;
                btnBold.FlatStyle = FlatStyle.Popup;
            }
        }

        private void btnItalic_Click(object sender, EventArgs e)
        {
            if (_textFont.Italic)
            {
                _textFont.Italic = false;
                btnItalic.FlatStyle = FlatStyle.Flat;
            }
            else
            {
                _textFont.Italic = true;
                btnItalic.FlatStyle = FlatStyle.Popup;
            }
        }

        private void btnUnderLine_Click(object sender, EventArgs e)
        {
            if (_textFont.Underline)
            {
                _textFont.Underline = false;
                btnUnderLine.FlatStyle = FlatStyle.Flat;
            }
            else
            {
                _textFont.Underline = true;
                btnUnderLine.FlatStyle = FlatStyle.Popup;
            }
        }

        private void btnStrikethrough_Click(object sender, EventArgs e)
        {
            if (_textFont.Strikethrough)
            {
                _textFont.Strikethrough = false;
                btnStrikethrough.FlatStyle = FlatStyle.Flat;
            }
            else
            {
                _textFont.Strikethrough = true;
                btnStrikethrough.FlatStyle = FlatStyle.Popup;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            _textAngle = Convert.ToDouble(nmrcUpDownAngle.Value);
            _insertText = txbxInsertText.Text;
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        

    }
}
