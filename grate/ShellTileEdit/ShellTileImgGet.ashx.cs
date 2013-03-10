using LN.BLL;
using LN.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;

namespace ShellTileEdit
{
    /// <summary>
    /// ShellTileImgGet 的摘要说明
    /// </summary>
    public class ShellTileImgGet : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string guid = context.Request["guid"];
            if (guid != AppObj.GetGuid())
            {
                context.Response.End();
                return;
            }
            int id = Convert.ToInt32(context.Request["id"]);
            ShellTileList shell = new ShellTileListBLL().GetModelByID(id);
            context.Response.ContentType = "image/jpeg";
            string imgPath = context.Server.MapPath("/ShellTileImg" + shell.CImg);
            if (File.Exists(imgPath))
            {

                if (context.Request["isFull"] != "1")
                {
                    string smImgPath = context.Server.MapPath("/ShellTileImg/small" + shell.CImg);
                    if (!File.Exists(smImgPath))
                    {
                        Image img = Image.FromFile(imgPath);
                        ResizePic(img, smImgPath);
                    }                  
                    context.Response.TransmitFile(smImgPath);

                }
                else
                {
                    context.Response.TransmitFile(imgPath);
                }

            }
            context.Response.End();

        }
        public void ResizePic(Image img,string path)
        {
            int w = img.Width;
            int h = img.Height;
            if (w > 240)
            {
                w = 240;
                h = img.Height * 240 / img.Width;
            }
            img = img.GetThumbnailImage(w, h, new Image.GetThumbnailImageAbort(CallBack), IntPtr.Zero);
            img.Save(path);           
        }
      
        private static bool CallBack()
        {
            return false;
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}