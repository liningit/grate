using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace Com.Tool
{
    public partial class Tool
    {
        //md5加密
        public static string GetMD5Hash(String input)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] res = md5.ComputeHash(Encoding.Default.GetBytes(input), 0, input.Length);
            char[] temp = new char[res.Length];
            System.Array.Copy(res, temp, res.Length);
            return new String(temp);
        }
        //绑定CheckBoxList
        public static void BindCheckBoxList(CheckBoxList clist, string values)
        {
            values = "," + values + ",";
            for (int i = 0; i < clist.Items.Count; i++)
            {
                if (values.IndexOf("," + clist.Items[i].Value + ",") != -1)
                {
                    clist.Items[i].Selected = true;
                }
            }
        }
        //获取CheckBoxList值
        public static string GetCheckBoxListValues(CheckBoxList clist)
        {
            string values = "";
            for (int i = 0; i < clist.Items.Count; i++)
            {
                if (clist.Items[i].Selected)
                {
                    values = values + clist.Items[i].Value + ",";
                }
            }
            return values;
        }

        public static string GetValue(string str)
        {
            if (str == "请选择")
            {
                return "";
            }
            return str;
        }

        #region   移除HTML标签

        /**/
        ///   <summary> 
        ///   移除HTML标签 
        ///   </summary> 
        ///   <param   name="HTMLStr">HTMLStr</param> 
        public static string ParseTags(string HTMLStr)
        {
            return System.Text.RegularExpressions.Regex.Replace(HTMLStr, "<[^>]*>", "");
        }

        #endregion

        #region   取出文本中的图片地址
        /**/
        ///   <summary> 
        ///   取出文本中的图片地址 
        ///   </summary> 
        ///   <param   name="HTMLStr">HTMLStr</param> 
        public static string GetImgUrl(string HTMLStr, int startat)
        {
            string str = string.Empty;
        
            Regex r = new Regex(@"<img\s+[^>]*\s*src\s*=\s*([']?)(?<url>\S+)''?[^>]*>",
            RegexOptions.Compiled);
            Match m = r.Match(HTMLStr.ToLower());
            for (int i = 1; i < startat; i++)
            {
                m=m.NextMatch();
            }
            if (m.Success)
                str = m.Result("${url}");
            return str;
        }

        #endregion

        #region 获取html的文本值
        /// <summary>
        ///  获取html的文本值
        /// </summary>
        /// <param name="Htmlstring">html String</param>
        /// <returns></returns>
        public static string GetNoHTML(string Htmlstring)
        {
            //删除脚本   
            Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
            //删除HTML   
            Htmlstring = Regex.Replace(Htmlstring, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"-->", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);

            Htmlstring = Regex.Replace(Htmlstring, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(nbsp|#160);", "   ", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&#(\d+);", "", RegexOptions.IgnoreCase);

            Htmlstring.Replace("<", "");
            Htmlstring.Replace(">", "");
            Htmlstring.Replace("\r\n", "");
            Htmlstring = HttpContext.Current.Server.HtmlEncode(Htmlstring).Trim();

            return Htmlstring;
        }

        /// <summary>
        /// 获取html的文本值
        /// </summary>
        /// <param name="Htmlstring">html String</param>
        /// <param name="length">获取前面多少字的文本,-1表示所有</param>
        /// <returns></returns>
        public static string GetNoHTML(string Htmlstring, int length)
        {
            string text = GetNoHTML(Htmlstring);
            if (text.Length < length || length < 0)
            {
                return text;
            }
            if (length == -1)
            {
                return text;
            }
            return text.Substring(0, length);
        } 
        #endregion

        
    }
}
