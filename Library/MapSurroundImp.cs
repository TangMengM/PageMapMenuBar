using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Controls;

namespace PageMapMenuBar
{
    class MapSurroundImp
    {
        /// <summary>
        /// 获取一个地图制图元素
        /// </summary>
        /// <param name="ipUID"></param>
        /// <param name="ipEnv"></param>
        /// <param name="sName"></param>
        /// <param name="ipLayoutCtrl"></param>
        /// <param name="ipStyle"></param>
        /// <returns></returns>
        public static IMapSurround CreateMapSurround(UID ipUID, IEnvelope ipEnv, string sName, IPageLayoutControlDefault ipLayoutCtrl, IMapSurround ipStyle)
        {
            try
            {
                IMapSurround ms = null;
                IMapFrame mf = ipLayoutCtrl.ActiveView.GraphicsContainer.FindFrame(ipLayoutCtrl.ActiveView.FocusMap) as IMapFrame;
                IMapSurroundFrame msf = mf.CreateSurroundFrame(ipUID, ipStyle);
                IElement ele = msf as IElement;
                ms = msf.MapSurround;
                ms.Name = sName;

                ele.Geometry = ipEnv;

                ipLayoutCtrl.ActiveView.GraphicsContainer.AddElement(ele, 0);
                ele.Geometry = ipEnv; //再加一句才能根据画出来的范围改变图例大小
                ipLayoutCtrl.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, ele, null);
                return ms;
            }
            catch (System.Exception ex)
            {
                return null;
            }
            
        } 
    }
}
