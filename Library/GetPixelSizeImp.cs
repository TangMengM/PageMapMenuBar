using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PageMapMenuBar
{
    class GetPixelSizeImp
    {
        private const double Page_Width_A0 = 84.1;
        private const double Page_Height_A0 = 118.88;
        private const double Page_Width_A1 = 59.4;
        private const double Page_Height_A1 = 84.1;
        private const double Page_Width_A2 = 42;
        private const double Page_Height_A2 = 59.4;
        private const double Page_Width_A3 = 29.7;
        private const double Page_Height_A3 = 42;
        private const double Page_Width_A4 = 21;
        private const double Page_Height_A4 = 29.7;
        private const double Page_Width_A5 = 14.8;
        private const double Page_Height_A5 = 21;

        private const double Inch_2_CM = 2.54;

        /// <summary>
        /// 根据厘米长度和dpi获取像素数
        /// </summary>
        /// <param name="pW"></param>
        /// <param name="pH"></param>
        public static int[] GetPixelSize(ExportPageType pageType, int dpi)
        {
            try
            {
                double pageWidth = 0;
                double pageHeight = 0;
                switch (pageType)
                {
                    case ExportPageType.A0:
                        pageWidth = Page_Width_A0;
                        pageHeight = Page_Height_A0;
                        break;
                    case ExportPageType.A1:
                        pageWidth = Page_Width_A1;
                        pageHeight = Page_Height_A1;
                        break;
                    case ExportPageType.A2:
                        pageWidth = Page_Width_A2;
                        pageHeight = Page_Height_A2;
                        break;
                    case ExportPageType.A3:
                        pageWidth = Page_Width_A3;
                        pageHeight = Page_Height_A3;
                        break;
                    case ExportPageType.A4:
                        pageWidth = Page_Width_A4;
                        pageHeight = Page_Height_A4;
                        break;
                    case ExportPageType.A5:
                        pageWidth = Page_Width_A5;
                        pageHeight = Page_Height_A5;
                        break;
                    default:
                        pageWidth = Page_Width_A4;
                        pageHeight = Page_Height_A4;
                        break;
                }
                double tempWidth = pageWidth / Inch_2_CM * dpi;
                double tempHeight = pageHeight / Inch_2_CM * dpi;
                int intWidth = Convert.ToInt32(tempWidth);
                int intHeight = Convert.ToInt32(tempHeight);
                int width = (intWidth < tempWidth) ? (intWidth + 1) : intWidth;
                int height = (intHeight < tempHeight) ? (intHeight + 1) : intHeight;
                return new int[] { width, height };
            }
            catch (System.Exception ex)
            {
                return new int[] { 0, 0 };
            }
            
        }
    }

    /// <summary>
    /// 输出纸张的类型
    /// </summary>
    public enum ExportPageType
    {
        A0=0,
        A1=1,
        A2=2,
        A3=3,
        A4=4,
        A5=5
    }
}
