using System;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
namespace Com.Tool.DB
{
    public interface IDBTool : IDisposable
    {
        /// <summary>
        /// ��ʼ����
        /// </summary>
        void BeginTransaction();
        /// <summary>
        /// �ύ����
        /// </summary>
        void Commit();
        /// <summary>
        /// �ع�����
        /// </summary>
        void Rollback();
        /// <summary>
        /// ��������
        /// </summary>
        DbConnection getSqlConnection();

        /// <summary>
        /// ִ����ͨ��ѯ��������DataSet
        /// </summary>
        DataSet DS_Query(string str);
        DataSet DS_Query(string str, string name, object value);
        DataSet DS_Query<T>(string str, List<T> lst) where T : IDataParameter;
        DataSet DS_Query(string str, params IDataParameter[] ps);
        /// <summary>
        /// ִ�д洢���̣�����DataTable
        /// </summary>
        DataTable DT_Query(string str);
        DataTable DT_Query(string str, string name, object value);
        DataTable DT_Query<T>(string str, List<T> lst) where T : IDataParameter;
        DataTable DT_Query(string str, params IDataParameter[] ps);

        /// <summary>
        /// ִ����ͨ��ѯ��������IDataReader
        /// </summary>
        IDataReader ExecuteReader(string str);
        IDataReader ExecuteReader(string str, string name, object value);
        IDataReader ExecuteReader<T>(string str, List<T> lst) where T : IDataParameter;
        IDataReader ExecuteReader(string str, params IDataParameter[] ps);

        /// <summary>
        /// ִ��ɾ�������룬�Ȳ��� ����Ӱ�������
        /// </summary>
        int ExecuteNonQuery(string str);
        int ExecuteNonQuery(string str, string name, object value);
        int ExecuteNonQuery<T>(string str, List<T> lst) where T : IDataParameter;
        int ExecuteNonQuery(string str, params IDataParameter[] ps);

        /// <summary>
        ///  ִ����ͨ��ѯ�������ؽ������һ�еĵ�һ�У�����������������
        /// </summary>
        object ExecuteScalar(string str);
        object ExecuteScalar(string str, string name, object value);
        object ExecuteScalar<T>(string str, List<T> lst) where T : IDataParameter;
        object ExecuteScalar(string str, params IDataParameter[] ps);



        /// <summary>
        /// ִ�д洢���̣�����DataSet
        /// </summary>
        DataSet DS_Stored(string str);
        DataSet DS_Stored(string str, string name, object value);
        DataSet DS_Stored<T>(string str, List<T> lst) where T : IDataParameter;
        DataSet DS_Stored(string str, params IDataParameter[] ps);

        /// <summary>
        /// ִ�д洢���̣�����DataTable
        /// </summary>
        DataTable DT_Stored(string str);
        DataTable DT_Stored(string str, string name, object value);
        DataTable DT_Stored<T>(string str, List<T> lst) where T : IDataParameter;
        DataTable DT_Stored(string str, params IDataParameter[] ps);

        /// <summary>
        /// ִ�д洢���̣�����IDataReader
        /// </summary>
        IDataReader ExecuteStored(string str);
        IDataReader ExecuteStored(string str, string name, object value);
        IDataReader ExecuteStored<T>(string str, List<T> lst) where T : IDataParameter;
        IDataReader ExecuteStored(string str, params IDataParameter[] ps);


        /// <summary>
        /// ִ�д洢���̣�������Ӱ�������
        /// </summary>
        int ExecuteStored_NonQuery(string str);
        int ExecuteStored_NonQuery(string str, string name, object value);
        int ExecuteStored_NonQuery<T>(string str, List<T> lst) where T : IDataParameter;
        int ExecuteStored_NonQuery(string str, params IDataParameter[] ps);

        /// <summary>
        /// ִ�д洢���̣������ؽ������һ�еĵ�һ�У�����������������
        /// </summary>
        object ExecuteStored_Scalar(string str);
        object ExecuteStored_Scalar(string str, string name, object value);
        object ExecuteStored_Scalar<T>(string str, List<T> lst) where T : IDataParameter;
        object ExecuteStored_Scalar(string str, params IDataParameter[] ps);

      
        

    }
}
