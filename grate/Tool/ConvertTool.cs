using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.Tool
{
    public class ConvertTool
    {
        public static string ToString(object value)
        {
            if (value != DBNull.Value)
            {
                return value.ToString();
            }
            return string.Empty;
        }

        public static DateTime ToDateTime(object value)
        {
            if (value != DBNull.Value)
            {
                return Convert.ToDateTime(value);
            }
            return System.Data.SqlTypes.SqlDateTime.MinValue.Value;
        }

        public static int ToInt32(object value)
        {
            if (value != DBNull.Value)
            {
                return Convert.ToInt32(value);
            }
            return 0;
        }

        public static decimal ToDecimal(object value)
        {
            if (value != DBNull.Value)
            {
                return Convert.ToDecimal(value);
            }
            return 0;
        }
    }
}
