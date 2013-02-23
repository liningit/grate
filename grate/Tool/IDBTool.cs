using System;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
namespace Com.Tool.DB
{
    public interface IDBTool : IDisposable
    {
        /// <summary>
        /// 开始事务
        /// </summary>
        void BeginTransaction();
        /// <summary>
        /// 提交事务
        /// </summary>
        void Commit();
        /// <summary>
        /// 回滚事务
        /// </summary>
        void Rollback();
        /// <summary>
        /// 返回连接
        /// </summary>
        DbConnection getSqlConnection();

        /// <summary>
        /// 执行普通查询，并返回DataSet
        /// </summary>
        DataSet DS_Query(string str);
        DataSet DS_Query(string str, string name, object value);
        DataSet DS_Query<T>(string str, List<T> lst) where T : IDataParameter;
        DataSet DS_Query(string str, params IDataParameter[] ps);
        /// <summary>
        /// 执行存储过程，返回DataTable
        /// </summary>
        DataTable DT_Query(string str);
        DataTable DT_Query(string str, string name, object value);
        DataTable DT_Query<T>(string str, List<T> lst) where T : IDataParameter;
        DataTable DT_Query(string str, params IDataParameter[] ps);

        /// <summary>
        /// 执行普通查询，并返回IDataReader
        /// </summary>
        IDataReader ExecuteReader(string str);
        IDataReader ExecuteReader(string str, string name, object value);
        IDataReader ExecuteReader<T>(string str, List<T> lst) where T : IDataParameter;
        IDataReader ExecuteReader(string str, params IDataParameter[] ps);

        /// <summary>
        /// 执行删除，插入，等操作 返回影响多少行
        /// </summary>
        int ExecuteNonQuery(string str);
        int ExecuteNonQuery(string str, string name, object value);
        int ExecuteNonQuery<T>(string str, List<T> lst) where T : IDataParameter;
        int ExecuteNonQuery(string str, params IDataParameter[] ps);

        /// <summary>
        ///  执行普通查询，并返回结果集第一行的第一列，忽略其他行其他列
        /// </summary>
        object ExecuteScalar(string str);
        object ExecuteScalar(string str, string name, object value);
        object ExecuteScalar<T>(string str, List<T> lst) where T : IDataParameter;
        object ExecuteScalar(string str, params IDataParameter[] ps);



        /// <summary>
        /// 执行存储过程，返回DataSet
        /// </summary>
        DataSet DS_Stored(string str);
        DataSet DS_Stored(string str, string name, object value);
        DataSet DS_Stored<T>(string str, List<T> lst) where T : IDataParameter;
        DataSet DS_Stored(string str, params IDataParameter[] ps);

        /// <summary>
        /// 执行存储过程，返回DataTable
        /// </summary>
        DataTable DT_Stored(string str);
        DataTable DT_Stored(string str, string name, object value);
        DataTable DT_Stored<T>(string str, List<T> lst) where T : IDataParameter;
        DataTable DT_Stored(string str, params IDataParameter[] ps);

        /// <summary>
        /// 执行存储过程，返回IDataReader
        /// </summary>
        IDataReader ExecuteStored(string str);
        IDataReader ExecuteStored(string str, string name, object value);
        IDataReader ExecuteStored<T>(string str, List<T> lst) where T : IDataParameter;
        IDataReader ExecuteStored(string str, params IDataParameter[] ps);


        /// <summary>
        /// 执行存储过程，并返回影响多少行
        /// </summary>
        int ExecuteStored_NonQuery(string str);
        int ExecuteStored_NonQuery(string str, string name, object value);
        int ExecuteStored_NonQuery<T>(string str, List<T> lst) where T : IDataParameter;
        int ExecuteStored_NonQuery(string str, params IDataParameter[] ps);

        /// <summary>
        /// 执行存储过程，并返回结果集第一行的第一列，忽略其他行其他列
        /// </summary>
        object ExecuteStored_Scalar(string str);
        object ExecuteStored_Scalar(string str, string name, object value);
        object ExecuteStored_Scalar<T>(string str, List<T> lst) where T : IDataParameter;
        object ExecuteStored_Scalar(string str, params IDataParameter[] ps);

      
        

    }
}
