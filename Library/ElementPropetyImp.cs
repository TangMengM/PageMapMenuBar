using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.esriSystem;

namespace PageMapMenuBar
{
    class ElementPropetyImp
    {
        /// <summary>
        /// 根据红绿蓝三色值获取一个IRgbColor
        /// </summary>
        /// <param name="red"></param>
        /// <param name="green"></param>
        /// <param name="blue"></param>
        /// <returns></returns>
        public static IRgbColor GetRGBColor(int red, int green, int blue)
        {
            IRgbColor pRgbColor;
            pRgbColor = new RgbColorClass();
            pRgbColor.Red = red;
            pRgbColor.Green = green;
            pRgbColor.Blue = blue;

            return pRgbColor;
        }

        public static InsertTextForm GetTextElementForm(ITextElement textElement)
        {
            try
            {
                if (textElement == null) return null;

                double textAngle = textElement.Symbol.Angle;
                IColor textColor = textElement.Symbol.Color;
                stdole.IFontDisp textFont = textElement.Symbol.Font;
                double textSize = textElement.Symbol.Size;
                string insertText = textElement.Text;
                InsertTextForm insertTextFrm = new InsertTextForm(textAngle, textColor, textFont, textSize, insertText);
                return insertTextFrm;
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }

        public static void SetTextElementByTextForm(InsertTextForm insertTextFrm, ITextElement textElement)
        {
            try
            {
                textElement.Text = insertTextFrm.InsertText;

                ITextSymbol textSymbol = new TextSymbolClass();
                textSymbol.Font = insertTextFrm.TextFont;
                textSymbol.Size = insertTextFrm.TextSize;
                textSymbol.Angle = insertTextFrm.TextAngle;
                textSymbol.Color = insertTextFrm.TextColor;

                textElement.Symbol = textSymbol;
            }
            catch (System.Exception ex)
            {
                return;
            }

        }

        #region 指北针
        /// <summary>
        /// 生成一个默认指北针
        /// </summary>
        /// <param name="pageLayoutControl"></param>
        /// <param name="startX"></param>
        /// <param name="startY"></param>
        /// <returns></returns>
        public static IMapSurround GetDefaultNortthArrow(IPageLayoutControlDefault pageLayoutControl, double startX, double startY)
        {
            try
            {
                IPageLayout pageLayout = pageLayoutControl.PageLayout;
                IActiveView pActiveView = pageLayoutControl.ActiveView;
                IMap map = pActiveView.FocusMap;
                
                if (pageLayout == null || map == null)
                {
                    return null;
                }
                IEnvelope envelope = new EnvelopeClass();
                envelope.PutCoords(startX, startY, startX+48, startY+48); //  Specify the location and size of the north arrow

                IUID uid = new UIDClass();
                uid.Value = "esriCarto.MarkerNorthArrow";

                // Create a Surround. Set the geometry of the MapSurroundFrame to give it a location
                IGraphicsContainer graphicsContainer = pageLayout as IGraphicsContainer; // Dynamic Cast
                IActiveView activeView = pageLayout as IActiveView; // Dynamic Cast
                IFrameElement frameElement = graphicsContainer.FindFrame(map);
                IMapFrame mapFrame = frameElement as IMapFrame; // Dynamic Cast
                IMapSurroundFrame mapSurroundFrame = mapFrame.CreateSurroundFrame(uid as ESRI.ArcGIS.esriSystem.UID, null); // Dynamic Cast
                IElement element = mapSurroundFrame as IElement; // Dynamic Cast
                element.Geometry = envelope;
                IMapSurround mapSurround = mapSurroundFrame.MapSurround;

                return mapSurround;
            }
            catch (System.Exception ex)
            {
            	return null;
            }
            
        }

        /// <summary>
        /// 返回IMapSurroundFrame类型的元素
        /// </summary>
        /// <param name="pageControl"></param>
        /// <param name="pageX"></param>
        /// <param name="pageY"></param>
        /// <returns></returns>
        public static IElement GetElementFromPage(IPageLayoutControlDefault pageControl, int pageX, int pageY)
        {
            try
            {
                pageControl.ActiveView.GraphicsContainer.Reset();
                IElement element = pageControl.ActiveView.GraphicsContainer.Next();
                while (element != null)
                {
                    bool isHit = element.HitTest(pageX, pageY, 1);
                    if (isHit)
                    {
                        return element;
                    }
                    element = pageControl.ActiveView.GraphicsContainer.Next();
                }
                return null;
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region 比例尺
        /// <summary>
        /// 生成默认比例尺
        /// </summary>
        /// <param name="pageLayoutControl"></param>
        /// <param name="startX"></param>
        /// <param name="startY"></param>
        /// <returns></returns>
        public  static IMapSurround GetDefaultScaleBar(IPageLayoutControlDefault pageLayoutControl, double startX, double startY)
        {
            try
            {
                IPageLayout pageLayout = pageLayoutControl.PageLayout;
                IGraphicsContainer container = pageLayout as IGraphicsContainer;
                IActiveView activeView = pageLayout as IActiveView;
                // 获得MapFrame  
                IFrameElement frameElement = container.FindFrame(activeView.FocusMap);
                IMapFrame mapFrame = frameElement as IMapFrame;
                //根据MapSurround的uid，创建相应的MapSurroundFrame和MapSurround  
                UID uid = new UIDClass();
                uid.Value = "esriCarto.AlternatingScaleBar";
                IMapSurroundFrame mapSurroundFrame = mapFrame.CreateSurroundFrame(uid, null);
                //设置MapSurroundFrame中比例尺的样式  
                IMapSurround mapSurround = mapSurroundFrame.MapSurround;
                IScaleBar markerScaleBar = ((IScaleBar)mapSurround);
                markerScaleBar.LabelPosition = esriVertPosEnum.esriBelow;
                markerScaleBar.UseMapSettings();
                //QI，确定mapSurroundFrame的位置  
                IElement element = mapSurroundFrame as IElement;
                IEnvelope envelope = new EnvelopeClass();
                envelope.PutCoords(startX, startY, startX + 10, startY + 10);
                element.Geometry = envelope;

                mapSurround = mapSurroundFrame.MapSurround;
                return mapSurround;

            }
            catch (System.Exception ex)
            {
                return null;
            }
            
        }
        #endregion
    }
}
