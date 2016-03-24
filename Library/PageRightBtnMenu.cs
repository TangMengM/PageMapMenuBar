using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.ADF;
using System.Windows.Forms;
using System.Data;

/**
 * author hwg 
 * 2016/2/21
 * 版式视图上元素的插入与修改
 * PageLayoutControl 上右键时弹出快捷菜单
 * 
 * */
namespace PageMapMenuBar
{
    public class PageRightBtnMenu : ESRI.ArcGIS.ADF.BaseClasses.BaseCommand, ICommandSubType
    {
        private IHookHelper m_hookHelper = new HookHelperClass();
        private long m_subType;
        private IPageLayoutControlDefault m_pageLayoutControl;

        private IElement m_currentElement = null;
        
        public PageRightBtnMenu(IPageLayoutControlDefault pageLayoutControl)
        {
            this.m_pageLayoutControl = pageLayoutControl;
        }

        public override void OnClick()
        {
            if (m_currentElement == null) return;
            
            switch (m_subType)
            {
                case 1:
                    try
                    {
                        if (m_currentElement is IMapFrame) break;
                        this.m_pageLayoutControl.GraphicsContainer.DeleteElement(m_currentElement);
                        this.m_pageLayoutControl.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
                        break;
                    }
                    catch (System.Exception ex)
                    {
                        break;
                    }                   
                case 2:
                    if (m_currentElement is ITextElement)
                    {
                        ITextElement textElement = m_currentElement as ITextElement;
                        InsertTextForm textFrm = ElementPropetyImp.GetTextElementForm(textElement);
                        if (textFrm.ShowDialog() == DialogResult.OK)
                        {
                            ElementPropetyImp.SetTextElementByTextForm(textFrm, textElement);
                            //Refresh the PageLayout
                            this.m_pageLayoutControl.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, textElement, null);
                        }                      
                    }
                    else if (m_currentElement is IMapSurroundFrame)
                    {
                        IMapSurroundFrame mapSurroundFrame = m_currentElement as IMapSurroundFrame;
                        IMapSurround pMapSurround = mapSurroundFrame.MapSurround;
                        //原始 envelope
                        IEnvelope originEnvelope = (mapSurroundFrame as IElement).Geometry.Envelope;
                        double xmin = originEnvelope.XMin;
                        double ymin = originEnvelope.YMin;

                        IStyleGalleryItem styleGalleryItem = null;
                        if (pMapSurround is IMarkerNorthArrow)
                        {
                            InsertNorthArrowForm symbolForm1 = new InsertNorthArrowForm(pMapSurround);                           
                            styleGalleryItem = symbolForm1.GetItem(esriSymbologyStyleClass.esriStyleClassNorthArrows);
                            symbolForm1.Dispose();
                        }
                        else if (pMapSurround is IScaleBar)
                        {
                            InsertScaleBarForm symbolForm2 = new InsertScaleBarForm(pMapSurround);                           
                            styleGalleryItem = symbolForm2.GetItem(esriSymbologyStyleClass.esriStyleClassScaleBars);
                            symbolForm2.Dispose();
                        }
                        //InsertNorthArrowForm symbolForm = new InsertNorthArrowForm(pMapSurround);
                        //IStyleGalleryItem styleGalleryItem = symbolForm.GetItem(esriSymbologyStyleClass.esriStyleClassNorthArrows);
                        //Release the form
                        
                        if (styleGalleryItem == null) return;

                        mapSurroundFrame.MapSurround = (IMapSurround)styleGalleryItem.Item;                     

                        //QI to IElement and set its geometry
                        IElement element = (IElement)mapSurroundFrame;

                        //Refresh the PageLayout
                        this.m_pageLayoutControl.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, element, null);
                    }
                    
                    break;
                
                default:
                    break;
            }
        }

        public override void OnCreate(object hook)
        {
            m_hookHelper.Hook = hook;
        }

        #region ICommandSubType 成员

        public int GetCount()
        {
            return 2;
        }

        public void SetSubType(int SubType)
        {
            m_subType = SubType;
        }

        public void SetCurrentElement(IElement element)
        {
            m_currentElement = element;
        }

        #endregion

        #region 属性
        public override string Caption
        {
            get
            {
                switch (m_subType)
                {
                    case 1:
                        return "删除元素";
                    case 2:
                        return "修改元素";
                    default:
                        return "";
                }
            }
        }

        public override bool Enabled
        {
            get
            {
                bool enabled = false;
                int i;
                switch (m_subType)
                {
                    case 1:
                        if (!(m_currentElement == null || m_currentElement is IMapFrame))
                        {
                            enabled = true;
                        }
                        break;
                    case 2:
                        if ((m_currentElement != null)&&(m_currentElement is ITextElement))
                        {
                            enabled = true;
                        }
                        if (m_currentElement is IMapSurroundFrame)
                        {
                            IMapSurroundFrame mapSurroundFrame = m_currentElement as IMapSurroundFrame;
                            if ((m_currentElement != null)&&(mapSurroundFrame.MapSurround is IScaleBar || mapSurroundFrame.MapSurround is IMarkerNorthArrow))
                            {
                                enabled = true;
                            }                                                  
                        }
                        break;
                    default:
                        break;
                }
                return enabled;
            }
        }
        #endregion
    }
}
