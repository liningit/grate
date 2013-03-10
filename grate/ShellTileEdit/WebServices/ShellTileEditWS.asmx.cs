using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using LN.Model;
using System.IO;
using LN.BLL;
using Com.Tool;

namespace ShellTileEdit.WebServices
{
    /// <summary>
    /// ShellTileEditWS 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class ShellTileEditWS : System.Web.Services.WebService
    {

        [WebMethod]
        public string SaveTitle(string userId, byte[] img, string imgName, byte[] bgImg, string bgImgName)
        {
            string strReturn = "";
            if (string.IsNullOrEmpty(imgName) && string.IsNullOrEmpty(bgImgName))
            {
                return "没有可上传的图片!";
            }
            if (SaveImg(userId, img, imgName, "A") == "existe")
            {
                strReturn += "正面图片已存在!";
            }
            else
            {
                strReturn += "正面图片上传成功!.";
            }

            if (SaveImg(userId, bgImg, bgImgName, "B") == "existe")
            {
                strReturn += "背面图片已存在!";
            }
            else
            {
                strReturn += "背面图片上传成功!.";
            }

            return strReturn;
        }
        [WebMethod]
        public string SaveImage(string userId, byte[] img, string imgName)
        {
            string strReturn = "";
            if (string.IsNullOrEmpty(imgName))
            {
                return "没有可上传的图片!";
            }
            if (SaveImg(userId, img, imgName, "Q") == "existe")
            {
                strReturn = "该图片已存在!";
            }
            else
            {
                strReturn = "图片上传成功!.";
            }
            return strReturn;
        }
        private string SaveImg(string userId, byte[] img, string imgName, string ctype)
        {
            imgName = imgName.Replace("\\", "/");
            if (string.IsNullOrEmpty(imgName))
            {
                return string.Empty;
            }
            imgName = imgName.Substring(imgName.LastIndexOf("/"));
            if (ctype == "Q")
            {
                imgName = "/Q" + imgName;
            }
            string fullName = Server.MapPath("../ShellTileImg") + imgName;
            if (!File.Exists(fullName))
            {
                using (FileStream fs = File.Create(fullName, img.Length))
                {
                    fs.Write(img, 0, img.Length);
                }
                System.Drawing.Image bmp = System.Drawing.Image.FromFile(fullName);
                ShellTileList sh = new ShellTileList();
                sh.CUserId = userId;
                sh.CImg = imgName;
                sh.CType = ctype;
                sh.BFlag = 2;
                sh.IHot = 0;
                sh.NOrder = 0;
                sh.DCTime = DateTime.Now;
                sh.NWidth = bmp.Width;
                sh.NHeight = bmp.Height;
                if (ctype == "Q")
                {
                    sh.BIsTitle = 0;
                }
                else
                {
                    sh.BIsTitle = 1;
                }
                new ShellTileListBLL().Add(sh);
            }
            else
            {
                return "existe";
            }
            return string.Empty;
        }
        public static int OneCount = 10;
        /// <summary>
        /// 获取共享桌面图片
        /// </summary>
        [WebMethod]
        public List<string> GetNextImg(string beginImg)
        {
            List<ShellTileList> lst = new ShellTileListBLL().GetList(null).FindAll(m => m.BFlag == 1 || m.BFlag == 2).OrderByDescending(m => m.Id).ToList();
            lst = lst.FindAll(m => m.BIsTitle == 1);
            if (string.IsNullOrEmpty(beginImg))
            {
                lst = lst.Take(30).ToList();
            }
            else
            {
                lst = lst.Skip(lst.FindIndex(m => m.CImg == beginImg) + 1).Take(30).ToList();
            }
            List<string> lstImg = new List<string>();
            foreach (ShellTileList tile in lst)
            {
                lstImg.Add(tile.CImg);
            }
            return lstImg;
        }
        /// <summary>
        /// 设置图片状态(审核或删除)
        /// </summary>   
        [WebMethod]
        public string SetImgStatus(string CImg, int bflag, string userId)
        {
            UserList user = new UserListBLL().GetModel(new UserList() { CUserId = userId });
            if (user == null || (user.CType != "manager" && user.CType != "admin"))
            {
                return "没有权限";
            }
            ShellTileListBLL bll = new ShellTileListBLL();
         
            List<ShellTileList> lst=null;
            if (CImg.Contains("Get.ashx?id="))
            {
                lst = bll.GetList(null).FindAll(m =>  CImg.Contains("Get.ashx?id=" + m.Id+"&"));
            }
            else
            {
                CImg = "," + CImg + ",";
                lst = bll.GetList(null).FindAll(m => CImg.Contains("," + m.CImg + ","));
            }
            if (lst.Count==0)
            {
                return "该图片不存在";
            }
            foreach (ShellTileList sh in lst)
            {
                sh.BFlag = bflag;
                sh.CDoUser += "," + userId;
                sh.CCheckInfo = DateTime.Now.ToString();
                bll.Update(sh, userId);
            }
            return "修改成功!";
        }
        /// <summary>
        /// 用户登录
        /// </summary>
        [WebMethod]
        public UserList Login(string userName, string pass)
        {
            UserList user = new UserList() { CLoginName = userName, CPassWord = pass, Bflag = 1 };
            user = new UserListBLL().GetModel(user);
            return user;
        }
        /// <summary>
        /// 用户注册
        /// </summary>
        [WebMethod]
        public UserList Register(UserList user)
        {
            UserList ru = new UserList() { CUserName = user.CUserName };
            if (new UserListBLL().GetModel(ru) != null)
            {
                throw new Exception("该昵称已存在!");
            }
            ru = new UserList() { CLoginName = user.CLoginName };
            if (new UserListBLL().GetModel(ru) != null)
            {
                throw new Exception("该登录名已存在!");
            }
            ru = new UserList() { CUserId = user.CUserId };
            if (new UserListBLL().GetModel(ru) != null)
            {
                user.CUserId = Guid.NewGuid().ToString();
            }
            user.Bflag = 1;
            user.DCTime = DateTime.Now;
            user.CType = "user";
            user.Id = new UserListBLL().Add(user);
            return user;
        }

        /// <summary>
        /// 获取共享桌面图片(所有待审核)
        /// </summary>
        [WebMethod]
        public List<ShellTileList> GetNextDaiShenHeImg(string beginImg)
        {
            bool isEnd;
            if (beginImg == "/end.jpg")
            {
                return new List<ShellTileList>();
            }
            List<ShellTileList> lst = GetNextImg(beginImg, -1, "DaiShenHe", out isEnd);
            if (isEnd)
            {
                lst.Add(new ShellTileList() { CImg = "/end.jpg" });
            }
            return lst;
        }
        /// <summary>
        /// 获取共享桌面图片(已审核)
        /// </summary>
        [WebMethod]
        public List<ShellTileList> GetNextQImg(string beginImg)
        {
            bool isEnd;          
            List<ShellTileList> lst = GetNextImg(beginImg, 0, "ShenHe", out isEnd);          
            return lst;
        }
        private static List<ShellTileList> GetNextImg(string beginImg, int isTitle, string status, out bool isEnd)
        {
            List<ShellTileList> lst = new ShellTileListBLL().GetList(null).OrderByDescending(m => m.Id).ToList();
            if (status == "DaiShenHe")
            {
                lst = lst.FindAll(m => m.BFlag == 2);
            }
            else
            {
                lst = lst.FindAll(m => m.BFlag == 1 || m.BFlag == 2);
            }
            if (isTitle != -1)
            {
                lst = lst.FindAll(m => m.BIsTitle == isTitle);
            }
            if (lst.Count == 0)
            {
                isEnd = true;
            }
            else
            {
                ShellTileList last = lst.Last();
                if (string.IsNullOrEmpty(beginImg))
                {
                    lst = lst.Take(OneCount).ToList();
                }
                else
                {
                    lst = lst.Skip(lst.FindIndex(m => beginImg.Contains("Get.ashx?id=" + m.Id+"&")) + 1).Take(OneCount).ToList();
                }
                if (lst.Count > 0)
                {
                    isEnd = lst.Last() == last;
                }
                else
                {
                    isEnd = true;
                }
            }
            foreach (ShellTileList shell in lst)
            {
                shell.CImg = "Get.ashx?id=" + shell.Id + "&guid=" + AppObj.GetGuid()+"&name="+shell.CImg;
            }
            return lst;
        }

     
    }
}
