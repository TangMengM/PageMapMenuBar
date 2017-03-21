using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyPluginEngine;

namespace PageMapMenuBar
{
    class InsertMenuDef : IMenuDef
    {
        #region IMenuDef成员
        public string Caption
        {
            get { return "制图"; }
        }

        public string Name
        {
            get { return "InsertMenu"; }
        }

        public long ItemCount
        {
            get { return 7; }
        }

        public void GetItemInfo(int pos, ItemDef itemDef)
        {
            switch (pos)
            {
                case 0:
                    itemDef.ID = "PageMapMenuBar.ExportMapCmd";
                    itemDef.Group = false;
                    break; 
                case 1:
                    itemDef.ID = "PageMapMenuBar.InsertTitle";
                    itemDef.Group = true;
                    break;
                case 2:
                    itemDef.ID = "PageMapMenuBar.InsertText";
                    itemDef.Group = false;
                    break;
                case 3:
                    itemDef.ID = "PageMapMenuBar.InsertNorthArrow";
                    itemDef.Group = false;
                    break;
                case 4:
                    itemDef.ID = "PageMapMenuBar.InsertScaleBar";
                    itemDef.Group = false;
                    break;
                case 5:
                    itemDef.ID = "PageMapMenuBar.InsertLegend";
                    itemDef.Group = false;
                    break;
                case 6:
                    itemDef.ID = "PageMapMenuBar.FrmZhujiCmd";
                    itemDef.Group = false;
                    break;
                
                default:
                    break;
            }
        }
        #endregion
    }
}
