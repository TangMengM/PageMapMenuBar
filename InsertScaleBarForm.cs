using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.esriSystem;

namespace PageMapMenuBar
{
    public partial class InsertScaleBarForm : Form
    {
        private int[] _sizeFontArr = { 5, 6, 7, 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };
        private int[] _sizeBarArr = { 5, 6, 7, 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };

        private IStyleGalleryItem m_styleGalleryItem;
        private double _size = 0;
        public double Size
        {
            get { return _size; }
        }

        public InsertScaleBarForm(object mapSurroundItem)
        {
            InitializeComponent();
            m_styleGalleryItem = new ServerStyleGalleryItemClass();
            m_styleGalleryItem.Item = mapSurroundItem;
        }

        #region 控件事件处理
        private void InsertNorthArrowForm_Load(object sender, EventArgs e)
        {
            //Get the ArcGIS install location
            string sInstall = ESRI.ArcGIS.RuntimeManager.ActiveRuntime.Path;

            //Load the ESRI.ServerStyle file into the SymbologyControl
            axSymbologyControl1.LoadStyleFile(sInstall + "\\Styles\\ESRI.ServerStyle");

            //初始化属性控件
            ChangeControlsByItem();

            PreviewImage();
        }

        private void axSymbologyControl1_OnItemSelected(object sender, ESRI.ArcGIS.Controls.ISymbologyControlEvents_OnItemSelectedEvent e)
        {
            m_styleGalleryItem = e.styleGalleryItem as IStyleGalleryItem;

            //更新单位控件值
            cmbxUnit.SelectedIndex = GetUnitIndexFromItem(m_styleGalleryItem.Item);

            //更改文本字体和大小控件的值
            cmbxTextFont.SelectedIndex = cmbxTextFont.FindString(GetTextFontFromItem(m_styleGalleryItem.Item).Name);
            cmbxTextSize.Text = GetTextSizeFromItem(m_styleGalleryItem.Item).ToString();

            //更新文本颜色控件的值
            btnTextColor.BackColor = GetTextColorFromItem(m_styleGalleryItem.Item);

            //更新条块大小和颜色控件的值
            cmbxSymbolSize.Text = GetTextSizeFromItem(m_styleGalleryItem.Item).ToString();
            btnSymbolColor.BackColor = GetSymbolColorFromItem(m_styleGalleryItem.Item);

            PreviewImage();
        }

        private void btnTextColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            DialogResult result = colorDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                btnTextColor.BackColor = colorDialog.Color;
            }
        }
        private void btnSymbolColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            DialogResult result = colorDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                btnSymbolColor.BackColor = colorDialog.Color;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //hide the form
            this.Hide();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _size = Convert.ToDouble(cmbxSymbolSize.Text);
            m_styleGalleryItem = null;
            //hide the form
            this.Hide();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            IScaleBar mapScaleBar = (m_styleGalleryItem.Item as IScaleBar);
            if (mapScaleBar == null) return;

            //设置单位
            int unitIndex = cmbxUnit.SelectedIndex;
            mapScaleBar.Units = (esriUnits)unitIndex;

            //设置文本字体、大小与颜色
            ITextSymbol textSymbol = mapScaleBar.LabelSymbol;
            textSymbol.Font.Name = cmbxTextFont.Text;
            textSymbol.Size = Convert.ToDouble(cmbxTextSize.Text);
            textSymbol.Color = ElementPropetyImp.GetRGBColor(btnTextColor.BackColor.R, btnTextColor.BackColor.G, btnTextColor.BackColor.B) as IColor;

            mapScaleBar.LabelSymbol = textSymbol;

            //设置条块大小与颜色
            mapScaleBar.BarHeight = Convert.ToDouble(cmbxSymbolSize.Text);
            mapScaleBar.BarColor = ElementPropetyImp.GetRGBColor(btnSymbolColor.BackColor.R, btnSymbolColor.BackColor.G, btnSymbolColor.BackColor.B) as IColor;

            PreviewImage();
        }

        #endregion





        #region 公有函数
        /// <summary>
        /// 从该窗口实例中获取一个比例尺元素实例
        /// </summary>
        /// <param name="styleClass"></param>
        /// <returns></returns>
        public IStyleGalleryItem GetItem(ESRI.ArcGIS.Controls.esriSymbologyStyleClass styleClass)
        {
            //m_styleGalleryItem = null;

            //Set the style class of SymbologyControl1
            axSymbologyControl1.StyleClass = styleClass;

            //Change cursor
            this.Cursor = Cursors.Default;

            //Show the modal form
            this.ShowDialog();

            //return the label style that has been selected from the SymbologyControl
            return m_styleGalleryItem;
        }
        #endregion
        
        #region 私有函数
        /// <summary>
        /// 根据当前IStyleGalleryItem的值来更新属性控件状态
        /// </summary>
        private void ChangeControlsByItem()
        {
            //更新单位控件的值
            int unitIndex = GetUnitIndexFromItem(m_styleGalleryItem.Item);
            cmbxUnit.DataSource = System.Enum.GetNames(typeof(UnitsType));
            cmbxUnit.SelectedIndex = unitIndex;
            //更新文本字体控件的值
            stdole.IFontDisp textFont = GetTextFontFromItem(m_styleGalleryItem.Item);
            cmbxTextFont.DataSource = System.Enum.GetNames(typeof(FontType));
            cmbxTextFont.SelectedIndex = cmbxTextFont.FindString(textFont.Name);

            //更新文本大小控件的值
            this.cmbxTextSize.DataSource = _sizeFontArr;
            this.cmbxTextSize.Text = GetTextSizeFromItem(m_styleGalleryItem.Item).ToString();
            //更新文本颜色控件的值
            btnTextColor.BackColor = GetTextColorFromItem(m_styleGalleryItem.Item);
            

            //更新条块大小控件的值
            this.cmbxSymbolSize.DataSource = _sizeBarArr;
            this.cmbxSymbolSize.Text = GetTextSizeFromItem(m_styleGalleryItem.Item).ToString();
            //更新条块颜色控件的值
            btnSymbolColor.BackColor = GetSymbolColorFromItem(m_styleGalleryItem.Item);

        }
        
        /// <summary>
        /// 预览当前元素对象
        /// </summary>
        private void PreviewImage()
        {
            //获得样式类
            ISymbologyStyleClass symbolgyStyleClass = axSymbologyControl1.GetStyleClass(axSymbologyControl1.StyleClass);
            //symbolPictureBox.Size = new System.Drawing.Size((int)GetTextSizeFromItem(m_styleGalleryItem.Item), (int)GetTextSizeFromItem(m_styleGalleryItem.Item));
            //symbolPictureBox.Location = new System.Drawing.Point((symbolPictureBox.Parent.Width - symbolPictureBox.Width) / 2 , 20);
            stdole.IPictureDisp picture = symbolgyStyleClass.PreviewItem(m_styleGalleryItem, symbolPictureBox.Width, symbolPictureBox.Height);
            System.Drawing.Image image = System.Drawing.Image.FromHbitmap(new System.IntPtr(picture.Handle));
            
            symbolPictureBox.Image = image;

        }

        #region 根据当前元素对象获取其指定的属性值
        /// <summary>
        /// 获得单位的枚举实例对应的整型值
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private int GetUnitIndexFromItem(object item)
        {
            if (item == null)
            {
                return 0;
            }

            IMapSurround pMapSurround = item as IMapSurround;
            if (pMapSurround is IScaleBar)
            {
                return (int)((pMapSurround as IScaleBar).Units);
            }

            else
                return 0;
        }

        /// <summary>
        /// 获取文本字体
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private stdole.IFontDisp GetTextFontFromItem(object item)
        {
            if (item == null)
            {
                return null;
            }

            IMapSurround pMapSurround = item as IMapSurround;
            if (pMapSurround is IScaleBar)
            {
                ITextSymbol textSymbol = (pMapSurround as IScaleBar).LabelSymbol;
                return textSymbol.Font;
            }

            else
                return null;
        }

        /// <summary>
        /// 获取文本大小
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private double GetTextSizeFromItem(object item)
        {
            if (item == null)
            {
                return -1;
            }

            IMapSurround pMapSurround = item as IMapSurround;
            if (pMapSurround is IScaleBar)
            {
                ITextSymbol textSymbol = (pMapSurround as IScaleBar).LabelSymbol;
                return textSymbol.Size;
            }

            else
                return 0;
        }

        /// <summary>
        /// 获取文本颜色
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private Color GetTextColorFromItem(object item)
        {
            Color fillColor = Color.Black;
            IRgbColor rgbColor = null;

            IMapSurround pMapSurround = item as IMapSurround;
            if (pMapSurround == null) return Color.Black;
            if (pMapSurround is IScaleBar)
            {
                ITextSymbol textSymbol = (pMapSurround as IScaleBar).LabelSymbol;
                rgbColor = (textSymbol.Color) as IRgbColor;
            }

            //颜色控件赋值
            if (rgbColor != null)
            {
                fillColor = Color.FromArgb(rgbColor.Red, rgbColor.Green, rgbColor.Blue);
            }
            return fillColor;
        }

        /// <summary>
        /// 获取条块大小
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private double GetSymbolSizeFromItem(object item)
        {
            if (item == null)
            {
                return -1;
            }

            IMapSurround pMapSurround = item as IMapSurround;
            if (pMapSurround is IScaleBar)
            {
                return (pMapSurround as IScaleBar).BarHeight;
            }
            else
                return 0;
        }



        /// <summary>
        /// 获取条块颜色
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private Color GetSymbolColorFromItem(object item)
        {
            Color fillColor = Color.Black;
            IRgbColor rgbColor = null;

            IMapSurround pMapSurround = item as IMapSurround;
            if (pMapSurround == null) return Color.Black;
            if (pMapSurround is IScaleBar)
            {
                rgbColor = ((pMapSurround as IScaleBar).BarColor) as IRgbColor; ;
            }

            //颜色控件赋值
            if (rgbColor != null)
            {
                fillColor = Color.FromArgb(rgbColor.Red, rgbColor.Green, rgbColor.Blue);
            }
            return fillColor;
        }
        #endregion



        #endregion

        

    

 




    }
}
