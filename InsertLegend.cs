﻿using System;
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
    class InsertLegend : MyPluginEngine.ITool
    {
        private MyPluginEngine.IApplication hk;
        private Bitmap m_hBitmap;

        private InsertNorthArrowForm _symbolForm;
        //private DialogResult _dlgResult;

        private IToolbarMenu _layerMenu = null;
        private PageRightBtnMenu _rightMenu1 = null;
        private PageRightBtnMenu _rightMenu2 = null;

        public InsertLegend()
        {
            m_hBitmap = new Bitmap(this.GetType().Assembly.GetManifestResourceStream("PageMapMenuBar.Image.图例.ico"));
        }

        #region ITool成员
        public Bitmap Bitmap
        {
            get { return m_hBitmap; }
        }

        public string Caption
        {
            get { return "插入图例"; }
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
            get { return "插入图例"; }
        }

        public string Name
        {
            get { return "InsertLegend"; }
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
            get { return "插入指北针"; }
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
            ESRI.ArcGIS.Geometry.IPoint point = this.hk.PageLayoutControl.ActiveView.ScreenDisplay.DisplayTransformation.ToMapPoint(x, y);

            IElement mapSurroundElement = ElementPropetyImp.GetElementFromPage(this.hk.PageLayoutControl, (int)point.X, (int)point.Y);
            _rightMenu1.SetCurrentElement(mapSurroundElement);
            _rightMenu2.SetCurrentElement(mapSurroundElement);
            _layerMenu.PopupMenu(x, y, this.hk.PageLayoutControl.hWnd);
           
            return false;
        }

        public void OnMouseMove(int button, int shift, int x, int y)
        {

        }

        public void OnMouseDown(int button, int shift, int x, int y)
        {
            IRubberBand ipRubber = new RubberEnvelopeClass();
            IEnvelope env = ipRubber.TrackNew(this.hk.PageLayoutControl.ActiveView.ScreenDisplay, null) as IEnvelope;
            //初始化图例信息 
            UID uid = new UIDClass();
            uid.Value = "esriCarto.Legend";
            MapSurroundImp.CreateMapSurround(uid, env, "图例", this.hk.PageLayoutControl, null); 
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

        #endregion

        
    }
}
