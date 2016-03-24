using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.OutputUI;
using ESRI.ArcGIS.Output;

namespace PageMapMenuBar
{
    class MapExportImp
    {
        /// <summary>
        /// 将当前布局控件的地图内容导出成图片
        /// </summary>
        /// <param name="pActiveView"></param>
        public static void ExportPictureFile(IActiveView pActiveView)
        {
            IEnvelope pPixelBoundsEnv;
            int hDC;
            //按输出dpi为300（A4打印的默认dpi）计算图片默认像素宽高
            int[] widthHeight = GetPixelSizeImp.GetPixelSize(ExportPageType.A4, 300);
            tagRECT exportRECT;
            exportRECT.left = 0;
            exportRECT.top = 0;
            exportRECT.right = widthHeight[0];
            exportRECT.bottom = widthHeight[1];
            pPixelBoundsEnv = new EnvelopeClass();
            pPixelBoundsEnv.PutCoords(exportRECT.left, exportRECT.top,
            exportRECT.right, exportRECT.bottom);
            IExportFileDialog pExportDialog;
            pExportDialog = new ExportFileDialogClass();
            bool pBool;
            pBool = pExportDialog.DoModal(pPixelBoundsEnv, pActiveView.Extent,
            pActiveView.Extent, 300);
            if (!(pBool)) return;
            IExport pExport;
            pExport = pExportDialog.Export;
            exportRECT.right = (int)pExport.PixelBounds.Envelope.XMax;
            exportRECT.bottom = (int)pExport.PixelBounds.Envelope.YMax;
            hDC = pExport.StartExporting();
            pActiveView.Output(hDC, (int)pExport.Resolution, ref exportRECT, null, null);
            pExport.FinishExporting();
            pExport.Cleanup();
        }
    }
}
