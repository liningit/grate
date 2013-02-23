using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using Com.Tool;
using System.Configuration;

namespace Com.Tool.DB
{
    public class SQLDBTool : IDBTool
    {
        private static readonly CommandType Text = CommandType.Text;
        private static readonly CommandType StoredProcedure = CommandType.StoredProcedure;
        public static  string connStr 
        {
            get{
                return ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
               // return "Data Source=OAF7LP8IVXTBNCV\\SQLEXPRESS;Initial Catalog=pos;Integrated Security=True";
            
            }
        }
        SqlConnection conn;
        private SqlCommand cmd;
        SqlTransaction tran;

        public SQLDBTool()
        {
           // conn = new SqlConnection("Data Source=.\\SQLSERVER2008;Initial Catalog=test;Integrated Security=True");
            conn = new SqlConnection(connStr);
            conn.Open();
            cmd = new SqlCommand();
            cmd.Connection = conn;
        }

        #region 执行普通查询
        #region 执行普通查询，并返回IDataReader
        /// <summary>
        /// 执行普通查询，并返回IDataReader
        /// </summary>
        public IDataReader ExecuteReader(string str)
        {
            setCmd(str, Text);
            return cmd.ExecuteReader();
        }
        /// <summary>
        /// 执行普通查询，并返回IDataReader
        /// </summary>
        public IDataReader ExecuteReader<T>(string str, List<T> lst) where T : IDataParameter
        {
            setCmd(str, Text, lst);
            return cmd.ExecuteReader();
        }
        /// <summary>
        /// 执行普通查询，并返回IDataReader
        /// </summary>
        public IDataReader ExecuteReader(string str, params IDataParameter[] ps)
        {

            setCmd(str, Text, ps);
            return cmd.ExecuteReader();
        }
        /// <summary>
        /// 执行普通查询，并返回IDataReader
        /// </summary>
        public IDataReader ExecuteReader(string str, string name, object value)
        {
            setCmd(str, Text);
            cmd.Parameters.Add(getParameter(name, value));
            return cmd.ExecuteReader();
        }

         #endregion

        #region 执行普通查询，并返回DataTable
        /// <summary>
        ///  执行普通查询，并返回DataTable
        /// </summary>
        public DataTable DT_Query(string str)
        {
            setCmd(str, Text);

            return getDT();
        }
        /// <summary>
        ///  执行普通查询，并返回DataTable
        /// </summary>
        public DataTable DT_Query<T>(string str, List<T> lst) where T : IDataParameter
        {
            setCmd(str, Text, lst);
            return getDT();
        }
        /// <summary>
        ///  执行普通查询，并返回DataTable
        /// </summary>
        public DataTable DT_Query(string str, params IDataParameter[] ps)
        {
            setCmd(str, Text, ps);

            return getDT();
        }
        /// <summary>
        ///  执行普通查询，并返回DataTable
        /// </summary>
        public DataTable DT_Query(string str, string name, object value)
        {
            setCmd(str, Text);
            cmd.Parameters.Add(getParameter(name, value));
            return getDT();
        }

        #endregion

        #region 执行普通查询，并返回DataSet
        /// <summary>
        ///  执行普通查询，并返回DataSet
        /// </summary>
        public DataSet DS_Query(string str)
        {
            setCmd(str, Text);
            return getDS();
        }
        /// <summary>
        ///  执行普通查询，并返回DataSet
        /// </summary>
        public DataSet DS_Query<T>(string str, List<T> lst) where T : IDataParameter
        {
            setCmd(str, Text, lst);
            return getDS();
        }
        /// <summary>
        ///  执行普通查询，并返回DataSet
        /// </summary>
        public DataSet DS_Query(string str, params IDataParameter[] ps)
        {
            setCmd(str, Text, ps);
            return getDS();
        }
        /// <summary>
        ///  执行普通查询，并返回DataSet
        /// </summary>
        public DataSet DS_Query(string str, string name, object value)
        {
            setCmd(str, Text);
            cmd.Parameters.Add(getParameter(name, value));
            return getDS();
        }

        #endregion

        #region 执行普通查询，并返回结果集第一行的第一列，忽略其他行其他列
         /// <summary>
        ///  执行普通查询，并返回结果集第一行的第一列，忽略其他行其他列
         /// </summary>
        public object ExecuteScalar(string str)
        {
            setCmd(str, Text);
            return cmd.ExecuteScalar();
        }
        /// <summary>
        ///  执行普通查询，并返回结果集第一行的第一列，忽略其他行其他列
        /// </summary>
        public object ExecuteScalar<T>(string str, List<T> lst) where T : IDataParameter
        {
            setCmd(str, Text, lst);
            return cmd.ExecuteScalar();
        }
        /// <summary>
        ///  执行普通查询，并返回结果集第一行的第一列，忽略其他行其他列
        /// </summary>
        public object ExecuteScalar(string str, params IDataParameter[] ps)
        {

            setCmd(str, Text, ps);
            return cmd.ExecuteScalar();
        }
        /// <summary>
        ///  执行普通查询，并返回结果集第一行的第一列，忽略其他行其他列
        /// </summary>
        public object ExecuteScalar(string str, string name, object value)
        {
            setCmd(str, Text);
            cmd.Parameters.Add(getParameter(name, value));
            return cmd.ExecuteScalar();
        }
        #endregion

        #region 执行删除，插入，等操作 返回影响多少行

        /// <summary>
        /// 执行删除，插入，等操作 返回影响多少行
        /// </summary>
        public int ExecuteNonQuery(string str)
        {
            setCmd(str, Text);
            return cmd.ExecuteNonQuery();
        }
        /// <summary>
        /// 执行删除，插入，等操作 返回影响多少行
        /// </summary>
        public int ExecuteNonQuery<T>(string str, List<T> lst) where T : IDataParameter
        {
            setCmd(str, Text, lst);
            return cmd.ExecuteNonQuery();
        }
        /// <summary>
        /// 执行删除，插入，等操作 返回影响多少行
        /// </summary>
        public int ExecuteNonQuery(string str, params IDataParameter[] ps)
        {
            setCmd(str, Text, ps);
            return cmd.ExecuteNonQuery();
        }
        /// <summary>
        /// 执行删除，插入，等操作 返回影响多少行
        /// </summary>
        public int ExecuteNonQuery(string str, string name, object value)
        {
            setCmd(str, Text);
            cmd.Parameters.Add(getParameter(name, value));
            return cmd.ExecuteNonQuery();
        }
        #endregion 
        #endregion


        #region 执行存储过程

        #region 执行存储过程，返回DataSet
       /// <summary>
        /// 执行存储过程，返回DataSet
       /// </summary>
        public DataSet DS_Stored(string str)
        {

            setCmd(str, StoredProcedure);
            return getDS();

        }
        /// <summary>
        /// 执行存储过程，返回DataSet
        /// </summary>
        public DataSet DS_Stored<T>(string str, List<T> lst) where T : IDataParameter
        {
            setCmd(str, StoredProcedure, lst);
            return getDS();
        }
        /// <summary>
        /// 执行存储过程，返回DataSet
        /// </summary>
        public DataSet DS_Stored(string str, params IDataParameter[] ps)
        {
            setCmd(str, StoredProcedure, ps);
            return getDS();
        }
        /// <summary>
        /// 执行存储过程，返回DataSet
        /// </summary>
        public DataSet DS_Stored(string str, string name, object value)
        {
            setCmd(str, StoredProcedure);
            cmd.Parameters.Add(getParameter(name, value));
            return getDS();
        }
        #endregion

        #region 执行存储过程，返回DataTable
        /// <summary>
        ///执行存储过程，返回DataTable
        /// </summary>
        public DataTable DT_Stored(string str)
        {
            setCmd(str, StoredProcedure);
            return getDT();
        }
        /// <summary>
        ///执行存储过程，返回DataTable
        /// </summary>
        public DataTable DT_Stored<T>(string str, List<T> lst) where T : IDataParameter
        {
            setCmd(str, StoredProcedure, lst);
            return getDT();
        }
        /// <summary>
        ///执行存储过程，返回DataTable
        /// </summary>
        public DataTable DT_Stored(string str, params IDataParameter[] ps)
        {
            setCmd(str, StoredProcedure, ps);
            return getDT();
        }
        /// <summary>
        ///执行存储过程，返回DataTable
        /// </summary>
        public DataTable DT_Stored(string str, string name, object value)
        {
            setCmd(str, StoredProcedure);
            cmd.Parameters.Add(getParameter(name, value));
            return getDT();
        }
        #endregion

        #region  执行存储过程，并返回IDataReader
        /// <summary>
        /// 执行存储过程，并返回IDataReader
        /// </summary>
        public IDataReader ExecuteStored(string str)
        {
            setCmd(str, StoredProcedure);
            return cmd.ExecuteReader();
        }
        /// <summary>
        /// 执行存储过程，并返回IDataReader
        /// </summary>
        public IDataReader ExecuteStored<T>(string str, List<T> lst) where T : IDataParameter
        {

            setCmd(str, StoredProcedure, lst);
            return cmd.ExecuteReader();
        }
        /// <summary>
        /// 执行存储过程，并返回IDataReader
        /// </summary>
        public IDataReader ExecuteStored(string str, params IDataParameter[] ps)
        {
            setCmd(str, StoredProcedure, ps);
            return cmd.ExecuteReader();
        }
        /// <summary>
        /// 执行存储过程，并返回IDataReader
        /// </summary>
        public IDataReader ExecuteStored(string str, string name, object value)
        {
            setCmd(str, StoredProcedure);
            cmd.Parameters.Add(getParameter(name, value));
            return cmd.ExecuteReader();
        }
        #endregion

        #region 执行存储过程，并返回影响多少行
        /// <summary>
        /// 执行存储过程，并返回影响多少行
        /// </summary>
        public int ExecuteStored_NonQuery(string str)
        {
            setCmd(str, StoredProcedure);
            return cmd.ExecuteNonQuery();
        }
        /// <summary>
        /// 执行存储过程，并返回影响多少行
        /// </summary>
        public int ExecuteStored_NonQuery<T>(string str, List<T> lst) where T:IDataParameter
        {
            setCmd(str, StoredProcedure, lst);
            return cmd.ExecuteNonQuery();
        }
        /// <summary>
        /// 执行存储过程，并返回影响多少行
        /// </summary>
        public int ExecuteStored_NonQuery(string str, params IDataParameter[] ps)
        {
            setCmd(str, StoredProcedure, ps);
            return cmd.ExecuteNonQuery();
        }
        /// <summary>
        /// 执行存储过程，并返回影响多少行
        /// </summary>
        public int ExecuteStored_NonQuery(string str, string name, object value)
        {
            setCmd(str, StoredProcedure);
            cmd.Parameters.Add(getParameter(name, value));
            return cmd.ExecuteNonQuery();
        }
        #endregion

        #region 执行存储过程，并返回结果集第一行的第一列，忽略其他行其他列
        /// <summary>
        /// 执行存储过程，并返回结果集第一行的第一列，忽略其他行其他列
        /// </summary>
        public object ExecuteStored_Scalar(string str)
        {
            setCmd(str, StoredProcedure);
            return cmd.ExecuteScalar();
        }
        /// <summary>
        /// 执行存储过程，并返回结果集第一行的第一列，忽略其他行其他列
        /// </summary>
        public object ExecuteStored_Scalar<T>(string str, List<T> lst) where T : IDataParameter
        {

            setCmd(str, StoredProcedure, lst);
            return cmd.ExecuteScalar();
        }
        /// <summary>
        /// 执行存储过程，并返回结果集第一行的第一列，忽略其他行其他列
        /// </summary>
        public object ExecuteStored_Scalar(string str, params IDataParameter[] ps)
        {
            setCmd(str, StoredProcedure, ps);
            return cmd.ExecuteScalar();
        }
        /// <summary>
        /// 执行存储过程，并返回结果集第一行的第一列，忽略其他行其他列
        /// </summary>
        public object ExecuteStored_Scalar(string str, string name, object value)
        {
            setCmd(str, StoredProcedure);
            cmd.Parameters.Add(getParameter(name, value));
            return cmd.ExecuteScalar();
        }
        #endregion
        #endregion


        #region 事务开始，提交，取消
        public void BeginTransaction()
        {
            tran = conn.BeginTransaction();
            cmd.Transaction = tran;
        }
        public void Commit()
        {
            tran.Commit();
            tran = null;
            cmd.Transaction = null;
        }
        public void Rollback()
        {
            tran.Rollback();
            tran = null;
            cmd.Transaction = null;
        }

        #endregion

        #region IDisposable 成员

        public void Dispose()
        {
            if (tran != null)
            {
                tran.Rollback();
            }
            cmd.Dispose();
            conn.Close();
        }

        #endregion

        #region 返回连接
        public DbConnection getSqlConnection()
        {
            return conn;
        } 
        #endregion

        #region 返回SqlParameter
        public static SqlParameter getParameter(string k, object v)
        {
            SqlParameter sp = new SqlParameter();

            sp.ParameterName = k;

            if (v == null)
            {
                sp.Value = DBNull.Value;
            }
            else
            {
                sp.Value = v;
            }
            return sp;

        }
        public static SqlParameter getParameter(string k, object v, SqlDbType t)
        {
            SqlParameter sp = new SqlParameter();
            sp.SqlDbType = t;
            sp.ParameterName = k;

            if (v == null)
            {
                sp.Value = DBNull.Value;
            }
            else
            {
                sp.Value = v;
            }
            return sp;

        }
        public static SqlParameter getParameter(string k, object v, SqlDbType t, int s)
        {
            SqlParameter sp = new SqlParameter(k, t, s);
           
            if (v == null)
            {
                sp.Value = DBNull.Value;
            }
            else
            {
                sp.Value = v;
            }
            return sp;
        }
        /// <summary>
        /// 返回输出参数
        /// </summary>
        /// <param name="k"></param>
        /// <param name="t"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public static SqlParameter getParameter(string k,  SqlDbType t, int s)
        {
            SqlParameter sp = new SqlParameter(k, t, s);
            sp.Direction = ParameterDirection.Output;
            return sp;
        }
        public static SqlParameter getParameter(SqlDbType t, int s)
        {
            SqlParameter sp = new SqlParameter(null,t,s);
            sp.Direction = ParameterDirection.ReturnValue;
            return sp;
        }
        public static SqlParameter getParameter(SqlDbType t)
        {
            SqlParameter sp = new SqlParameter( null,t);
            sp.Direction = ParameterDirection.ReturnValue;
            return sp;
        }

        #endregion


        #region 私有方法

        #region cmd移除参数，释放资源
        private void CmdDispose()
        {
            cmd.Parameters.Clear();
            cmd.Dispose();
        }
        #endregion


        #region 设置cmd类型参数等
        private void setCmd<T>(string sql, CommandType type, List<T> lst)where T:IDataParameter
        {
            CmdDispose();
            cmd.CommandText = sql;
            cmd.CommandType = type;
            foreach (IDataParameter sp in lst)
            {
                cmd.Parameters.Add(sp);
            }
        }
        private void setCmd(string sql, CommandType type)
        {
            CmdDispose();
            cmd.CommandText = sql;
            cmd.CommandType = type;
        }
        private void setCmd(string sql, CommandType type, IDataParameter[] ps)
        {
            CmdDispose();
            cmd.CommandText = sql;
            cmd.CommandType = type;
            foreach (SqlParameter sp in ps)
            {
                cmd.Parameters.Add(sp);
            }
        }
        #endregion


        #region 返回DataTable
        private DataTable getDT()
        {
            SqlDataAdapter apt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            apt.Fill(dt);
            return dt;
        }
        #endregion

        #region 返回DataSet
        private DataSet getDS()
        {
            SqlDataAdapter apt = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            apt.Fill(ds);
            return ds;
        }
        #endregion 
        #endregion

        #region IDBTool 成员


     
        #endregion
    }


}
