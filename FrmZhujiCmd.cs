﻿using MyPluginEngine;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace PageMapMenuBar
{
    class FrmZhujiCmd : MyPluginEngine.ICommand
    {
        private MyPluginEngine.IApplication hk;
        private System.Drawing.Bitmap m_hBitmap;
        private ESRI.ArcGIS.SystemUI.ICommand cmd = null;
        FrmZhuji pfrmFlood;

        public FrmZhujiCmd()
        {
            string str = @"..\Data\Image\PageMapMenuBar\13.png";
            if (System.IO.File.Exists(str))
                m_hBitmap = new Bitmap(str);
            else
                m_hBitmap = null;

        }
        #region ICommand 成员
        public System.Drawing.Bitmap Bitmap
        {
            get { return m_hBitmap; }
        }

        public string Caption
        {
            get { return "地图注记"; }
        }

        public string Category
        {
            get { return "CreateDataMenu"; }
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
            get { return "地图注记"; }
        }

        public string Name
        {
            get { return "FrmZhuji"; }
        }

        public void OnClick()
        {
            //System.Windows.Forms.MessageBox.Show("正在开发中！");
            pfrmFlood = new FrmZhuji(hk);
            pfrmFlood.ShowDialog();
        }

        public void OnCreate(IApplication hook)
        {
            if (hook != null)
            {
                this.hk = hook;
                pfrmFlood = new FrmZhuji(hk);
                pfrmFlood.Visible = false;
            }
        }

        public string Tooltip
        {
            get { return "地图注记"; }
        }
        #endregion
    }
}