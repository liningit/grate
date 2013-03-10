using Com.Tool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShellTileEdit
{
    public class AppObj
    {
        public static string GetGuid()
        {
            object obj = CacheTool.GetCache("downImgGuid");
            if (obj != null)
            {
                return obj.ToString();
            }
            obj = Guid.NewGuid().ToString();
            CacheTool.SetCache("downImgGuid", obj, DateTime.Now.AddHours(6));
            return obj.ToString();
        }
    }
}