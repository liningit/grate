using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.Tool
{
    /// <summary>
    /// ��objectת��Ϊ��һ�ֿɿ����͵ķ���
    /// </summary>
    public class ConvertNullable
    {
        /// <summary>
        /// ת��Ϊint�Ŀɿ�����
        /// </summary>
        /// <param name="value">Ҫת����ֵ</param>
        /// <returns>����ֵ</returns>
        public static int? ToInt32(object value)
        {
            if (value == DBNull.Value||value==null||value.ToString()=="")
            {
                return null;
            }
            return Convert.ToInt32(value);
        }

        /// <summary>
        /// ת��Ϊdecimal�Ŀɿ�����
        /// </summary>
        /// <param name="value">Ҫת����ֵ</param>
        /// <returns>����ֵ</returns>
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
    /// ���ɿ�����ת��Ϊ��ͨ���͵���,��Ϊ��ʱ����0
    /// </summary>
    public static class ConvertNullableEx
    {

        /// <summary>
        /// ��int?����ת��Ϊint
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
        /// ��int?����ת��Ϊint
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
        /// ������ת��Ϊint��ʽ,���Ϊ�ջ򲻿�ת���򷵻�0
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
        /// ������ת��Ϊdecimal��ʽ,���Ϊ�ջ򲻿�ת���򷵻�0
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
