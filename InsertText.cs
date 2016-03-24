using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using MyPluginEngine;
using System.Windows.Forms;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.esriSystem;

namespace PageMapMenuBar
{
    class InsertText : MyPluginEngine.ITool
    {
        private MyPluginEngine.IApplication hk;
        private Bitmap m_hBitmap;

        private ESRI.ArcGIS.SystemUI.ITool tool = null;
        private ESRI.ArcGIS.SystemUI.ICommand cmd = null;

        private InsertTextForm _insertTextFrm;
        private DialogResult _dlgResult;

        private IToolbarMenu _layerMenu = null;
        private PageRightBtnMenu _rightMenu1 = null;
        private PageRightBtnMenu _rightMenu2 = null;

        public InsertText()
        {
            m_hBitmap = new Bitmap(this.GetType().Assembly.GetManifestResourceStream("PageMapMenuBar.Image.文本.ico"));
        }

        #region ITool成员
        public Bitmap Bitmap
        {
            get { return m_hBitmap; }
        }

        public string Caption
        {
            get { return "插入文本"; }
        }

        public string Category
        {
            get { return "InsertMenu"; }
        }

        public bool Checked
        {
            get { return false; }
        }

        public bool Enabled
        {
            get { return true; }
        }

        public int HelpContextId
        {
            get { return 0; }
        }

        public string HelpFile
        {
            get { return ""; }
        }

        public string Message
        {
            get { return "插入文本"; }
        }

        public string Name
        {
            get { return "InsertText"; }
        }

        public void OnClick()
        {
            //cmd.OnClick();
            //this.hk.MapControl.CurrentTool = tool;
            //this.hk.PageLayoutControl.CurrentTool = tool;
            
        }

        public void OnCreate(IApplication hook)
        {
            if (hook != null)
            {
                this.hk = hook;

                _layerMenu = new ToolbarMenuClass();
                _rightMenu1 = new PageRightBtnMenu(this.hk.PageLayoutControl);
                _rightMenu2 = new PageRightBtnMenu(this.hk.PageLayoutControl);
                _layerMenu.AddItem(_rightMenu1, 1, 0, false, esriCommandStyles.esriCommandStyleTextOnly);
                _layerMenu.AddItem(_rightMenu2, 2, 0, false, esriCommandStyles.esriCommandStyleTextOnly);
                _layerMenu.SetHook(this.hk.PageLayoutControl);
            }
        }

        public string Tooltip
        {
            get { return "插入文本"; }
        }

        public int Cursor
        {
            get { return (int)ESRI.ArcGIS.Controls.esriControlsMousePointer.esriPointerCrosshair; }
        }

        public bool Deactivate()
        {
            return false;
        }

        public void OnDblClick()
        {

        }

        public bool OnContextMenu(int x, int y)
        {
            IScreenDisplay screenDisplay = this.hk.PageLayoutControl.ActiveView.ScreenDisplay;
            IDisplayTransformation displayTransformation = screenDisplay.DisplayTransformation;
            ESRI.ArcGIS.Geometry.IPoint point = displayTransformation.ToMapPoint(x, y);

            IElement textElement = ElementPropetyImp.GetElementFromPage(this.hk.PageLayoutControl, (int)point.X, (int)point.Y);
            _rightMenu1.SetCurrentElement(textElement);
            _rightMenu2.SetCurrentElement(textElement);
            _layerMenu.PopupMenu(x, y, this.hk.PageLayoutControl.hWnd);
           
            return false;
        }

        public void OnMouseMove(int button, int shift, int x, int y)
        {

        }

        public void OnMouseDown(int button, int shift, int x, int y)
        {
            #region 旧代码
            _insertTextFrm = new InsertTextForm();
            _dlgResult = _insertTextFrm.ShowDialog();
            if (_dlgResult == DialogResult.OK)
            {
                //Create a point and set its coordinates
                IPoint point = new PointClass();
                point.X = x;
                point.Y = y;

                ITextSymbol textSymbol = new TextSymbolClass();
                textSymbol.Font = _insertTextFrm.TextFont;
                textSymbol.Size = _insertTextFrm.TextSize;
                textSymbol.Angle = _insertTextFrm.TextAngle;
                textSymbol.Color = _insertTextFrm.TextColor;

                //Create a text element
                ITextElement textElement = new TextElementClass();
                textElement.Symbol = textSymbol;
                textElement.Text = _insertTextFrm.InsertText;
                textElement.ScaleText = true;

                //QI to IElment
                IElement element = (IElement)textElement;
                //Set the TextElement's geometry
                element.Geometry = point;

                //Add the element to the GraphicsContainer
                this.hk.PageLayoutControl.ActiveView.GraphicsContainer.AddElement(element, 0);
                //Refresh the PageLayout
                this.hk.PageLayoutControl.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, element, null);

            }
            #endregion

        }

        public void OnMouseUp(int button, int shift, int x, int y)
        {

        }

        public void Refresh(int hDC)
        {

        }

        public void OnKeyDown(int keyCode, int shift)
        {

        }

        public void OnKeyUp(int keyCode, int shift)
        {

        }

        private IElement GetTextElement(int x, int y)
        {
            try
            {
                this.hk.PageLayoutControl.ActiveView.GraphicsContainer.Reset();
                IElement element = this.hk.PageLayoutControl.ActiveView.GraphicsContainer.Next();
                while (element != null)
                {
                    bool isHit = element.HitTest(x, y, 5);
                    //if (element is IMapSurroundFrame && isHit)
                    if (isHit)
                    {
                        return element;
                    }
                    element = this.hk.PageLayoutControl.ActiveView.GraphicsContainer.Next();
                }
                return null;
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }
        #endregion
    }
}
