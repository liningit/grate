using System;
using System.Collections.Generic;
using System.Text;
using Com.Model;

namespace Com.Tool
{
    public class PagesTool
    {
        public static int EachPageCount = 10;
        public static void setPages(Pages pg)
        {
            if (pg.EachPageCount == 0)
            {
                pg.EachPageCount = EachPageCount;
            }
     
            pg.AllPages = (pg.AllCount-1) / pg.EachPageCount + 1;
            if(pg.NowPage<1)
            {
                pg.NowPage = 1;
            }
            if (pg.NowPage > pg.AllPages)
            {
                pg.NowPage = pg.AllPages;
            }
            pg.BeginCount = (pg.NowPage - 1) * pg.EachPageCount;
            int i = ((pg.NowPage - 1) / 5) * 5 + 1;
            int temp=i+5;
            if (temp > pg.AllPages)
            {
                temp = pg.AllPages+1;
            }
            pg.Back = i-5;
            List<string> aryShowPages = new List<string>();
            for (; i < temp; i++)
            {
                aryShowPages.Add(i.ToString());   
            }
            pg.ShowPages = aryShowPages;
            pg.Next = i;

        }
    }
}
