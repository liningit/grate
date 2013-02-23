using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LN.BLL;
using LN.Model;

namespace grate
{
    public partial class _Default : System.Web.UI.Page
    {
        public string QianZhui = "";
        GrateInfoBLL bll = new GrateInfoBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            this.EnableViewState = false;
            if (Request.Url.Authority.ToString().IndexOf("lin.lining") != -1)
            {
                QianZhui = "Lin";
            }
            if (!IsPostBack)
            {
                Bind();
            }
        }

        private void Bind()
        {
            List<GrateInfo> lst = bll.GetList(null).Where(m => m.BFlag == 1).OrderByDescending(m => m.Id).Take(70).ToList();
            GrateInfo model = new GrateInfo();
            model.CUrl = "add";
            model.CImage = "xuweiyidai.png";
            for (int i = 70 - lst.Count; i > 0; i--)
            {
                lst.Add(model);
            }

            rptGrate.DataSource = lst;
            rptGrate.DataBind();
        }
       
        protected void btnSvae_Click(object sender, EventArgs e)
        {
            int count = bll.GetList(null).Where(m => m.BFlag == 1 && m.CIp == Request.UserHostAddress && m.DCtime.AddDays(1) >= DateTime.Now).Count();
            if (count >= 3)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "SearchProperty", "alert('一天同一IP最多添加3条!');location.href = 'Default.aspx';", true);
                return;
            }
            GrateInfo g = new GrateInfo();
            g.CName =GetJsStr( txtName.Text);
            g.CEmail =GetJsStr(  txtEmail.Text);
            g.CTitle =GetJsStr(  txtTitle.Text);
            g.CUrl =GetJsStr(  txtUrl.Text);
            g.BFlag = 1;
            g.DCtime = DateTime.Now;
            g.CIp = Request.UserHostAddress;
            string path = DateTime.Now.ToString("yyyy.MM.dd") + "/";
            string rootPath = Server.MapPath("ImageUpload/");
            if (!System.IO.Directory.Exists(rootPath + path))
            {
                System.IO.Directory.CreateDirectory(rootPath + path);
            }
            path += DateTime.Now.Ticks.ToString() + Guid.NewGuid();
            path += System.IO.Path.GetExtension(fuImg.FileName);
            fuImg.SaveAs(rootPath + path);
            g.CImage = path;
            bll.Add(g);
            Bind();
            ClientScript.RegisterClientScriptBlock(this.GetType(), "SearchProperty", "alert('添加成功!');location.href = 'Default.aspx';", true);
        }
        public string GetStr(object obj)
        {
            string str = "";
            if (obj != null)
            {
                str = obj.ToString();
            }
            return Server.HtmlEncode(str);
        }
        private string GetJsStr(string p)
        {
            return p.Replace("'", "\\'").Replace("\"","\\\"").Replace("\\","\\\\");
        }
    }
}