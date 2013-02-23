using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.Tool
{
    public  class StringTool
    {
        /// <summary>
        /// 对sql语句进行编码防止注入攻击
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ExSqlEncode(object obj)
        {
            if (obj == null)
            {
                return null;
            }
            string str = obj.ToString();
            if (string.IsNullOrEmpty(str))
            {
                return str;
            }
            return str.Replace("'", "''");
        }
    }
}
