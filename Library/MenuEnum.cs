using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PageMapMenuBar
{
    enum ExportFileType
    {
        EMF=0, 
        EPS = 1, 
        AI = 2,
        PDF = 3, 
        SVG = 4,
        BMP = 5,
        JPEG = 6,
        PNG = 7, 
        TIFF = 8,
        GIF = 9
    }

    enum FontType
    {
        宋体 = 0,
        仿宋 = 1,
        黑体 = 2,
        楷体 = 3,
        隶书 = 4,
        新宋体 = 5,
        幼圆 = 6,
        微软雅黑 = 7,
        Arial = 8,
        TimesNewRoman = 9
    }

    enum UnitsType
    {
        未知单位 = 0,
        英寸 = 1,
        磅 = 2,
        英尺 = 3,
        码 = 4,
        英里 = 5,
        海里 = 6,
        毫米 = 7,
        厘米 = 8,
        米 = 9,
        千米 = 10,
        十进制度 = 11,
        分米 = 12,
        内部专用 = 13
    }
}
