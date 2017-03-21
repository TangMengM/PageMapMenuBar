using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PageMapMenuBar
{
    public partial class FrmZhuji : Form
    {
        IMap pMap;
        IRgbColor pRGB = new RgbColorClass();
        private MyPluginEngine.IApplication hk;
        public FrmZhuji(MyPluginEngine.IApplication hook)
        {
            InitializeComponent();
            this.hk = hook;//你试试！
            pMap = hk.MapControl.Map;
            ////禁用Glass主题
            //this.EnableGlass = false;
            //不显示最大化最小化按钮
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            //去除图标
            this.ShowIcon = false;
        }

        private void cbxLayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbxField.Items.Clear();
            addfield();
        }

        private void cbxField_SelectedIndexChanged(object sender, EventArgs e)
        {
            string fieldname = cbxField.SelectedItem.ToString();
        }

        private void btnSelectColor_Click(object sender, EventArgs e)
        {
            pRGB = new RgbColorClass();
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                pRGB.Blue = colorDialog1.Color.B;
                pRGB.Green = colorDialog1.Color.G;
                pRGB.Red = colorDialog1.Color.R;
            }
        }

        private void btnA_Click(object sender, EventArgs e)
        {

            if (cbxLayer.SelectedItem == null)
            {
                MessageBox.Show("请选择要标注的图层！");
                return;
            }
            if (cbxField.SelectedItem == null)
            {
                MessageBox.Show("请选择要标注的字段！");
                return;
            }

            if (radioButton1.Checked)
            {
                LayerLabel();
            }
            if (radioButton2.Checked)
            {
                Annotation();
            }
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmZhuji_Load(object sender, EventArgs e)
        {
            addlayer();
            if (cbxLayer.Items.Count != 0)
            {
                cbxLayer.SelectedIndex = 0;
                addfield();
            }
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
        }
        private void Annotation()
        {
            string fieldname = cbxField.SelectedItem.ToString();
            IFeatureLayer featureLayer = getlayerbyname(cbxLayer.SelectedItem.ToString());
            IGeoFeatureLayer pGeoFeatLyr = featureLayer as IGeoFeatureLayer;
            stdole.IFontDisp pFont = new stdole.StdFontClass() as stdole.IFontDisp;
            pFont.Name = comboBox2.SelectedItem.ToString();
            ITextSymbol pTextSymbol = new TextSymbolClass();
            pTextSymbol.Size = Convert.ToInt16(comboBox3.SelectedItem.ToString());
            pTextSymbol.Font = pFont;
            if (pRGB.NullColor)
            {
                pRGB.Red = 255;
                pRGB.Blue = 0;
                pRGB.Green = 0;
            }
            pTextSymbol.Color = pRGB;
            IAnnotateLayerPropertiesCollection pAnnoProps = pGeoFeatLyr.AnnotationProperties;
            pAnnoProps.Clear();
            ILabelEngineLayerProperties pLabelEngine = new LabelEngineLayerPropertiesClass();
            pLabelEngine.Symbol = pTextSymbol;
            pLabelEngine.Expression = "[" + fieldname + "]";
            IAnnotateLayerProperties pAnnoLayerProps = pLabelEngine as IAnnotateLayerProperties;
            pAnnoLayerProps.DisplayAnnotation = true;
            pAnnoLayerProps.LabelWhichFeatures = esriLabelWhichFeatures.esriAllFeatures;
            pAnnoProps.Add(pAnnoLayerProps);
            pGeoFeatLyr.DisplayField = fieldname;
            pGeoFeatLyr.DisplayAnnotation = true;
            IActiveView pActiveView = pMap as IActiveView;
            pActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
        }

        private void LayerLabel()
        {
            IFeatureLayer featureLayer = getlayerbyname(cbxLayer.SelectedItem.ToString());
            IGeoFeatureLayer geoFeatureLayer = featureLayer as IGeoFeatureLayer;
            IFeatureClass featureclass = featureLayer.FeatureClass;
            IFields pFields = featureclass.Fields;
            int i = pFields.FindField(cbxField.SelectedItem.ToString());
            IField field = pFields.get_Field(i);
            geoFeatureLayer.DisplayField = field.Name;
            geoFeatureLayer.DisplayAnnotation = true;

            IActiveView pActiveView = pMap as IActiveView;
            pActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
        }

        private void textelementlable()
        {
            IFeatureLayer pfl = getlayerbyname(cbxLayer.SelectedItem.ToString());
            IFeatureClass featureclass = pfl.FeatureClass;
            IFeatureCursor pFeatureCursor;
            pFeatureCursor = featureclass.Search(null, true);
            IFeature pFeat = pFeatureCursor.NextFeature();
            while (pFeat != null)
            {
                IFields pFields = pFeat.Fields;
                int i = pFields.FindField(cbxField.SelectedItem.ToString()); ;
                IEnvelope pEnv = pFeat.Extent;
                IPoint pPoint = new PointClass();
                pPoint.PutCoords(pEnv.XMin + pEnv.Width / 2, pEnv.YMin + pEnv.Height / 2);
                stdole.IFontDisp pFont = new stdole.StdFontClass() as stdole.IFontDisp;
                pFont.Name = comboBox2.SelectedItem.ToString();
                ITextSymbol pTextSymbol = new TextSymbolClass();

                pTextSymbol.Size = Convert.ToInt16(comboBox3.SelectedItem.ToString());
                pTextSymbol.Font = pFont;
                if (pRGB.NullColor)
                {
                    pRGB.Red = 110;
                    pRGB.Blue = 200;
                    pRGB.Green = 60;
                }
                pTextSymbol.Color = pRGB;

                ITextElement pTextEle = new TextElementClass();
                pTextEle.Text = pFeat.get_Value(i).ToString();
                pTextEle.ScaleText = true;
                pTextEle.Symbol = pTextSymbol;
                IElement pEle = pTextEle as IElement;
                pEle.Geometry = pPoint;
                IActiveView pActiveView = pMap as IActiveView;
                IGraphicsContainer pGraphicsContainer = pMap as IGraphicsContainer;
                pGraphicsContainer.AddElement(pEle, 0);
                pActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
                pPoint = null;
                pEle = null;
                pFeat = pFeatureCursor.NextFeature();
            }
        }
        private void addfield()
        {
            cbxField.Items.Clear();
            string layername = cbxLayer.SelectedItem.ToString();
            IFeatureLayer pflayer = getlayerbyname(layername);
            for (int i = 0; i <= pflayer.FeatureClass.Fields.FieldCount - 1; i++)
            {
                cbxField.Items.Add(pflayer.FeatureClass.Fields.get_Field(i).Name.ToString());
            }
        }
        private IFeatureLayer getlayerbyname(string layername)
        {
            ILayer layer = null;
            IFeatureLayer flayer = null;
            for (int i = 0; i <= hk.MapControl.LayerCount - 1; i++)
            {
                layer = hk.MapControl.get_Layer(i);
                if (layername == hk.MapControl.get_Layer(i).Name.ToString() && layer is IFeatureLayer)
                { flayer = layer as IFeatureLayer; break; }
            }
            return flayer;

        }
        private void addlayer()
        {
            try
            {
                cbxLayer.Items.Clear();
                if (hk.MapControl.LayerCount > 0)
                {
                    cbxLayer.Enabled = true;
                    for (int i = 0; i <= hk.MapControl.LayerCount - 1; i++)
                    { cbxLayer.Items.Add(hk.MapControl.get_Layer(i).Name); }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }


        
        //private void button2_Click(object sender, EventArgs e)
        //{
        //    int CharIndex;
        //    //int LyrIndex;
            
        //    CharIndex = cbxLayer.Text.IndexOf(cbxLayer.Text);
        //    //LyrIndex = Convert.ToInt32(cbxLayer.Text.Substring(0, CharIndex));
            

        //    IFeatureLayer pFeatureLayer;
        //    pFeatureLayer = (IFeatureLayer)pMap.get_Layer(CharIndex);
        //    IRgbColor MyColor = new RgbColorClass();
        //    NOTFunLabelFeatureLayer(pFeatureLayer, cbxField.Text, MyColor, 12);
        //}
        //#region 图层标注不显示
        ///// <summary>
        ///// 图层标注不显示
        ///// </summary>
        ///// <param name="pFeaturelayer">标注图层</param>
        ///// <param name="sLableField">标注字段</param>
        ///// <param name="pRGB">颜色</param>
        ///// <param name="size">大小</param>
        //public static void NOTFunLabelFeatureLayer(IFeatureLayer pFeaturelayer, string sLableField, IRgbColor pRGB, int size)
        //{
        //    //判断图层是否为空
        //    if (pFeaturelayer == null)
        //        return;
        //    IGeoFeatureLayer pGeoFeaturelayer = (IGeoFeatureLayer)pFeaturelayer;
        //    IAnnotateLayerPropertiesCollection pAnnoLayerPropsCollection;
        //    pAnnoLayerPropsCollection = pGeoFeaturelayer.AnnotationProperties;
        //    pAnnoLayerPropsCollection.Clear();

        //    //pGeoFeaturelayer.DisplayAnnotation = false;//很重要，必须设置


        //    //stdole.IFontDisp  pFont; //字体
        //    ITextSymbol pTextSymbol;

        //    //pFont.Name = "新宋体";
        //    //pFont.Size = 9;
        //    //未指定字体颜色则默认为黑色
        //    if (pRGB == null)
        //    {
        //        pRGB = new RgbColorClass();
        //        pRGB.Red = 0;
        //        pRGB.Green = 0;
        //        pRGB.Blue = 0;
        //    }

        //    pTextSymbol = new TextSymbolClass();
        //    pTextSymbol.Color = (IColor)pRGB;
        //    pTextSymbol.Size = size; //标注大小

        //    IBasicOverposterLayerProperties pBasicOverposterlayerProps = new BasicOverposterLayerPropertiesClass();
        //    switch (pFeaturelayer.FeatureClass.ShapeType)//判断图层类型
        //    {
        //        case ESRI.ArcGIS.Geometry.esriGeometryType.esriGeometryPolygon:
        //            pBasicOverposterlayerProps.FeatureType = esriBasicOverposterFeatureType.esriOverposterPolygon;
        //            break;
        //        case ESRI.ArcGIS.Geometry.esriGeometryType.esriGeometryPoint:
        //            pBasicOverposterlayerProps.FeatureType = esriBasicOverposterFeatureType.esriOverposterPoint;
        //            break;
        //        case ESRI.ArcGIS.Geometry.esriGeometryType.esriGeometryPolyline:
        //            pBasicOverposterlayerProps.FeatureType = esriBasicOverposterFeatureType.esriOverposterPolyline;
        //            break;
        //    }

        //    ILabelEngineLayerProperties pLabelEnginelayerProps = new LabelEngineLayerPropertiesClass();
        //    pLabelEnginelayerProps.Expression = "[" + sLableField + "]";
        //    pLabelEnginelayerProps.Symbol = pTextSymbol;
        //    pLabelEnginelayerProps.BasicOverposterLayerProperties = pBasicOverposterlayerProps;

        //    pAnnoLayerPropsCollection.Add((IAnnotateLayerProperties)pLabelEnginelayerProps);
        //    pGeoFeaturelayer.DisplayAnnotation = false;//很重要，必须设置
        //    //axMapControl1.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewBackground, null, null);
        //}
        //#endregion

    }
}
