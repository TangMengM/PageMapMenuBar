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

namespace PageMapMenuBar
{
    public partial class InsertNorthArrowForm : Form
    {
        private IStyleGalleryItem m_styleGalleryItem;
        private double _size = 0;
        public double Size
        {
            get { return _size; }
        }

        public InsertNorthArrowForm(object mapSurroundItem)
        {
            InitializeComponent();
            m_styleGalleryItem = new ServerStyleGalleryItemClass();
            m_styleGalleryItem.Item = mapSurroundItem;
        }

        private void InsertNorthArrowForm_Load(object sender, EventArgs e)
        {
            //Get the ArcGIS install location
            string sInstall = ESRI.ArcGIS.RuntimeManager.ActiveRuntime.Path;

            //Load the ESRI.ServerStyle file into the SymbologyControl
            axSymbologyControl1.LoadStyleFile(sInstall + "\\Styles\\ESRI.ServerStyle");

            //初始化属性控件
            ChangeControlsByItem();
        }

        /// <summary>
        /// 根据当前IStyleGalleryItem的值来更新属性控件状态
        /// </summary>
        private void ChangeControlsByItem()
        {
            //更新颜色控件的颜色
            btnFillColor.BackColor = GetColorFromItem(m_styleGalleryItem.Item);

            //更新大小属性控件的值
            this.symbolSize.Value = Convert.ToDecimal(GetSizeFromItem(m_styleGalleryItem.Item));
        }

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
       

        private void axSymbologyControl1_OnItemSelected(object sender, ESRI.ArcGIS.Controls.ISymbologyControlEvents_OnItemSelectedEvent e)
        {
            m_styleGalleryItem = e.styleGalleryItem as IStyleGalleryItem;

            //更新颜色控件的颜色
            btnFillColor.BackColor = GetColorFromItem(m_styleGalleryItem.Item);

            //更新大小属性控件的值
            this.symbolSize.Value = Convert.ToDecimal(GetSizeFromItem(m_styleGalleryItem.Item));

            PreviewImage();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //hide the form
            this.Hide(); 
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _size = Convert.ToDouble(symbolSize.Value);
            m_styleGalleryItem = null;
            //hide the form
            this.Hide();
        }

        #region 私有函数
        private void PreviewImage()
        {
            //获得样式类
            ISymbologyStyleClass symbolgyStyleClass = axSymbologyControl1.GetStyleClass(axSymbologyControl1.StyleClass);
            symbolPictureBox.Size = new System.Drawing.Size((int)GetSizeFromItem(m_styleGalleryItem.Item), (int)GetSizeFromItem(m_styleGalleryItem.Item));
            symbolPictureBox.Location = new System.Drawing.Point((symbolPictureBox.Parent.Width - symbolPictureBox.Width) / 2 , 20); ;
            stdole.IPictureDisp picture = symbolgyStyleClass.PreviewItem(m_styleGalleryItem, symbolPictureBox.Width, symbolPictureBox.Height);
            System.Drawing.Image image = System.Drawing.Image.FromHbitmap(new System.IntPtr(picture.Handle));
            
            symbolPictureBox.Image = image;

        }

        private double GetSizeFromItem(object item)
        {
            if (item == null)
            {
                return -1;
            }

            IMapSurround pMapSurround = item as IMapSurround;
            if (pMapSurround is IMarkerNorthArrow)
            {
                return (pMapSurround as IMarkerNorthArrow).MarkerSymbol.Size;
            }

            //if (pSymbol is IMarkerSymbol)
            //{
            //    return (pSymbol as IMarkerSymbol).Size;

            //}
            //else if (pSymbol is ILineSymbol)
            //{
            //    return (pSymbol as ILineSymbol).Width;
            //}
            //else if (pSymbol is IFillSymbol)
            //{
            //    return (pSymbol as IFillSymbol).Outline.Width;
            //}
            else
                return 0;
        }

        private Color GetColorFromItem(object item)
        {
            Color fillColor = Color.Black;
            IRgbColor rgbColor = null;

            IMapSurround pMapSurround = item as IMapSurround;
            if (pMapSurround == null) return Color.Black;
            if (pMapSurround is IMarkerNorthArrow)
            {
                rgbColor = ((pMapSurround as IMarkerNorthArrow).MarkerSymbol.Color) as IRgbColor; ;
            }

            //颜色控件赋值
            if (rgbColor != null)
            {
                fillColor = Color.FromArgb(rgbColor.Red, rgbColor.Green, rgbColor.Blue);
            }
            return fillColor;
        }
        #endregion

        private void symbolSize_ValueChanged(object sender, EventArgs e)
        {
            IMapSurround pMapSurround = m_styleGalleryItem.Item as IMapSurround;
            if (symbolSize.Value < 0)
            {
                MessageBox.Show("请输入一个大于0的数字。");
            }
            double tempSize = Convert.ToDouble(symbolSize.Value);

            if (pMapSurround is IMarkerNorthArrow)
            {
                IMarkerSymbol markerSymbol = (pMapSurround as IMarkerNorthArrow).MarkerSymbol;
                markerSymbol.Size = tempSize;
                (pMapSurround as IMarkerNorthArrow).MarkerSymbol = markerSymbol;
                //pMapSurround.Refresh();
            }
            else
                return;

            PreviewImage();

            _size = Convert.ToDouble(symbolSize.Value);
        }

        private void btnFillColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            DialogResult result = colorDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                btnFillColor.BackColor = colorDialog.Color;

                IMapSurround pMapSurround = m_styleGalleryItem.Item as IMapSurround;
                if (pMapSurround == null) return;

                if (pMapSurround is IMarkerNorthArrow)
                {
                    IMarkerSymbol markerSymbol = (pMapSurround as IMarkerNorthArrow).MarkerSymbol;
                    markerSymbol.Color = ElementPropetyImp.GetRGBColor(colorDialog.Color.R, colorDialog.Color.G, colorDialog.Color.B);
                    (pMapSurround as IMarkerNorthArrow).MarkerSymbol = markerSymbol;
                }              
                else
                    return;

                PreviewImage();
            }
        }

    }
}
