using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.Tool
{
    /// <summary>
    /// 将object转换为另一种可空类型的方法
    /// </summary>
    public class ConvertNullable
    {
        /// <summary>
        /// 转化为int的可空类型
        /// </summary>
        /// <param name="value">要转换的值</param>
        /// <returns>返回值</returns>
        public static int? ToInt32(object value)
        {
            if (value == DBNull.Value||value==null||value.ToString()=="")
            {
                return null;
            }
            return Convert.ToInt32(value);
        }

        /// <summary>
        /// 转化为decimal的可空类型
        /// </summary>
        /// <param name="value">要转换的值</param>
        /// <returns>返回值</returns>
        public static decimal? ToDecimal(object value)
        {
            if (value == DBNull.Value || value == null || value.ToString() == "")
            {
                return null;
            }
            return Convert.ToDecimal(value);
        }      
    }
    /// <summary>
    /// 将可空类型转换为普通类型的类,当为空时返回0
    /// </summary>
    public static class ConvertNullableEx
    {

        /// <summary>
        /// 将int?类型转换为int
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int GetValue(this int? value)
        {

            if (value.HasValue)
            {
                return value.Value;
            }
            return 0;
        }
        /// <summary>
        /// 将int?类型转换为int
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static decimal GetValue(this decimal? value)
        {

            if (value.HasValue)
            {
                return value.Value;
            }
            return 0;
        }
    }

     /// <summary>
    ///  
    /// </summary>
    public static class ConvertEx
    {
        /// <summary>
        /// 将对象转换为int格式,如果为空或不可转换则返回0
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int ToInt32(this object str)
        {
            if (str == null)
            {
                return 0;
            }
            int returnValue = 0;
            int.TryParse(str.ToString(), out returnValue);
            return returnValue;
        }
        /// <summary>
        /// 将对象转换为decimal格式,如果为空或不可转换则返回0
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static decimal ToDecimal(this object str)
        {
            if (str == null)
            {
                return 0;
            }
            decimal returnValue = 0;
            decimal.TryParse(str.ToString(), out returnValue);
            return returnValue;
        }
    }
}
