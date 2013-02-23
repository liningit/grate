using System;
using System.Collections.Generic;
using System.Text;

namespace Com.Model
{
  
    /// <summary>
    /// 一般是知道 EachPageCount，selectPage，AllCount，
    /// 通过PagesTool设置其他的属性
    /// </summary>
    public class Pages
    {
      
        //每页显示多少条数据
        int eachPageCount;

        public int EachPageCount
        {
            get {   return eachPageCount; }
            set {   eachPageCount = value; }
        }
        //从第多少条开始查询
        int beginCount;

        public int BeginCount
        {
            get { return beginCount; }
            set { beginCount = value; }
        }
        //当前是第几页
        int nowPage;
        public int NowPage
        {
            get { return nowPage; }
            set { nowPage = value; }
        }
        //总共多少条数据
        int allCount;
        public int AllCount
        {
            get { return allCount; }
            set { allCount = value; }
        }
        //总共多少页
        int allPages;
        public int AllPages
        {
            get { return allPages; }
            set { allPages = value; }
        }
        // <<是第几页
        int back;
        public int Back
        {
            get { return back; }
            set { back = value; }
        }
        // >>是第几页
        int next;
        public int Next
        {
            get { return next; }
            set { next = value; }
        }
        //在导航条上显示多少页
        List<string> showPages;
        
        public List<string> ShowPages
        {
          get { return showPages; }
          set { showPages = value; }
        }
    }
}
