using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using MyPluginEngine;
using ESRI.ArcGIS.Carto;

namespace PageMapMenuBar
{
    class ExportMapCmd : MyPluginEngine.ICommand
    {
        private MyPluginEngine.IApplication hk;
        private Bitmap m_hBitmap = null;

        public ExportMapCmd()
        {
            m_hBitmap = new Bitmap(this.GetType().Assembly.GetManifestResourceStream("PageMapMenuBar.Image.导出.ico"));
        }

        #region ICommond成员

        public Bitmap Bitmap
        {
            get { return m_hBitmap; }
        }

        public string Caption
        {
            get { return "导出地图"; }
        }

        public string Category
        {
            get { return "PageMapMenu"; }
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
            get { return "导出地图"; }
        }

        public string Name
        {
            get { return "ExportMap"; }
        }

        public void OnClick()
        {
            IActiveView docActiveView = this.hk.PageLayoutControl.ActiveView;
            MapExportImp.ExportPictureFile(docActiveView);

        }

        public void OnCreate(IApplication hook)
        {
            if (hook != null)
            {
                this.hk = hook;

            }
        }

        public string Tooltip
        {
            get { return "导出地图"; }
        }
        #endregion
    }
}
