using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data;
using System.Collections;
using System.Linq;
using Com.Tool;
using Com.Tool.DB;
using LN.Model;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web;
using LN.DAL;

namespace Com.DAL.Base
{
    public abstract class BaseDAL<T> where T : BaseModel
    {
        public BaseDAL()
        {
        }

        #region 基础方法
        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="model">要添加的数据</param>
        /// <returns>返回最后插入的标识值</returns>
        public int Add(T model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strPar = new StringBuilder();
            List<IDataParameter> lstSp = new List<IDataParameter>();
            strSql.Append("insert into ");
            strSql.Append(model.TableName);
            strSql.Append("(");
            foreach (string str in model.ChageList)
            {
                if (model.IdentityCell.ToLower() != str.ToLower())
                {
                    strSql.Append(str); strSql.Append(",");
                    strPar.Append("@"); strPar.Append(str); strPar.Append(",");
                    lstSp.Add(SQLDBTool.getParameter("@" + str, model.GetValue(str)));
                }
            }
            strSql.Remove(strSql.Length - 1, 1);
            strPar.Remove(strPar.Length - 1, 1);
            strSql.Append(")values(");
            strSql.Append(strPar.ToString());
            strSql.Append(");select @@IDENTITY");
            using (IDBTool DBTool = new SQLDBTool())
            {
                RemoveCatch();
                return DBTool.ExecuteScalar(strSql.ToString(), lstSp).ToInt32();
            }
        }

        /// <summary>
        /// 更新一条数据根据PkList
        /// </summary>
        /// <param name="model">要添加的数据</param>
        /// <returns>返回影响的行数</returns>
        public int Update(T model)
        {
           return Update(model, string.Empty);
        }
        /// <summary>
        /// 更新一条数据根据PkList
        /// </summary>
        /// <param name="model">要添加的数据</param>
        /// <returns>返回影响的行数</returns>
        public int Update(T model, string userId)
        {
            StringBuilder strSql = new StringBuilder();
            List<IDataParameter> lstSp = new List<IDataParameter>();
            strSql.Append("update ");
            strSql.Append(model.TableName);
            strSql.Append(" set ");
            foreach (string str in model.ChageList)
            {
                if (model.IdentityCell.ToLower() != str.ToLower() && !model.PkList.Contains(str))
                {
                    strSql.Append(str); strSql.Append("=@"); strSql.Append(str); strSql.Append(",");
                    lstSp.Add(SQLDBTool.getParameter("@" + str, model.GetValue(str)));
                }
            }
            strSql.Remove(strSql.Length - 1, 1);
            strSql.Append(" where ");
            foreach (string str in model.PkList)
            {
                strSql.Append(str); strSql.Append("=@"); strSql.Append(str); strSql.Append(" and ");
                lstSp.Add(SQLDBTool.getParameter("@" + str, model.GetValue(str)));
            }

            strSql.Remove(strSql.Length - 4, 4);
            using (IDBTool DBTool = new SQLDBTool())
            {
                RemoveCatch();
                string sql = strSql.ToString();
                if (!string.IsNullOrEmpty(userId))
                {
                    LogList log = new LogList();
                    log.CSql = sql;
                    log.CUserId = userId;
                    log.DCtime = DateTime.Now;
                    try
                    {
                        foreach (IDataParameter p in lstSp)
                        {
                            log.CParameters += p.ParameterName + "=" + p.Value + "  {endParameter}  ";
                        }
                        log.CIp = HttpContext.Current.Request.UserHostAddress;
                    }
                    catch (Exception)
                    {
                    }

                   
                    new LogListDAL().Add(log);
                }
                return DBTool.ExecuteNonQuery(sql, lstSp).ToInt32();
            }
        }
        /// <summary>
        /// 删除数据根据ChageList
        /// </summary>
        /// <param name="model">要添加的数据</param>
        /// <returns>返回影响的行数</returns>
        public int Delete(T model)
        {
            StringBuilder strSql = new StringBuilder();
            List<IDataParameter> lstSp = new List<IDataParameter>();
            strSql.Append("delete ");
            strSql.Append(model.TableName);
            strSql.Append(" where ");
            foreach (string str in model.ChageList)
            {
                strSql.Append(str); strSql.Append("=@"); strSql.Append(str); strSql.Append(" and ");
                lstSp.Add(SQLDBTool.getParameter("@" + str, model.GetValue(str)));
            }
            strSql.Remove(strSql.Length - 4, 4);
            using (IDBTool DBTool = new SQLDBTool())
            {
                RemoveCatch();
                return DBTool.ExecuteNonQuery(strSql.ToString(), lstSp).ToInt32();
            }
        }



        /// <summary>
        /// 查询数据返回第一条数据
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="model">要查询的条件</param>
        /// <returns>返回第一条数据,如果没有则返回null</returns>
        public T GetModel(T model)
        {
            return GetList(model).FirstOrDefault();
        }

        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="model">查询条件</param>
        /// <returns>返回数据</returns>
        public List<T> GetList(T model)
        {
            if (UsingCache)
            {
                List<T> lst = GetAllListByCatch();
                if (model != null)
                {
                    lst = lst.Where(m => m.IsSelect(model)).ToList();
                }
                //深度复制一个对象,防止里面的对象改变后catch里面的对象也改变
                MemoryStream ms = new MemoryStream();
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(ms, lst);     // list1中元素的类要实现ISerializable接口
                ms.Seek(0, SeekOrigin.Begin);
                List<T> list2 = (List<T>)bf.Deserialize(ms);
                return list2;
            }
            else
            {
                return GetListByTable(SelectByModel(model));
            }
        }

        /// <summary>
        /// 查询数据
        /// </summary>     
        /// <param name="model">查询条件</param>
        /// <returns>返回数据</returns>
        public DataTable SelectByModel(T model)
        {
            if (model == null)
            {
                model = GetNewModel();
            }
            StringBuilder strSql = new StringBuilder();
            List<IDataParameter> lstSp = new List<IDataParameter>();
            strSql.Append("select * from ");
            strSql.Append(model.TableName);
            if (model.ChageList.Count > 0)
            {
                strSql.Append(" where ");
                foreach (string str in model.ChageList)
                {
                    strSql.Append(str); strSql.Append("=@"); strSql.Append(str); strSql.Append(" and ");
                    lstSp.Add(SQLDBTool.getParameter("@" + str, model.GetValue(str)));
                }
                strSql.Remove(strSql.Length - 4, 4);
            }
            using (IDBTool DBTool = new SQLDBTool())
            {
                return DBTool.DT_Query(strSql.ToString(), lstSp);
            }
        }
        /// <summary>
        /// 查询数据
        /// </summary>     
        /// <param name="model">查询条件</param>
        /// <returns>返回数据</returns>
        public DataTable SelectBySql(string where)
        {

            T model = GetNewModel();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from ");
            strSql.Append(model.TableName);
            if (!string.IsNullOrEmpty(where))
            {
                strSql.Append(" where " + where);
            }
            using (IDBTool DBTool = new SQLDBTool())
            {
                return DBTool.DT_Query(strSql.ToString());
            }
        }
        /// <summary>
        /// 根据缓存返回所有对象
        /// </summary>
        private List<T> GetAllListByCatch()
        {
            List<T> lst = CacheTool.GetCache(typeof(T).ToString()) as List<T>;
            if (lst == null)
            {
                lst = GetListByTable(SelectByModel(null));
                CacheTool.SetCache(typeof(T).ToString(), lst);
            }
            return lst;
        }

        private void RemoveCatch()
        {
            CacheTool.RemoveCache(typeof(T).ToString());
        }
        /// <summary>
        /// 根据datatable返回实体集合
        /// </summary>
        private List<T> GetListByTable(DataTable dt)
        {
            List<T> lst = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                lst.Add(GetModelByRow(row));
            }
            return lst;
        }
        /// <summary>
        /// 设置Model
        /// </summary>     
        private T GetModelByRow(DataRow row)
        {
            T model = GetNewModel();
            foreach (DataColumn col in row.Table.Columns)
            {
                model.SetValue(col.ColumnName, row[col]);
            }
            return model as T;
        }

        /// <summary>
        /// 返回一个新的实体类,子类实现
        /// </summary>
        /// <returns></returns>
        protected abstract T GetNewModel();
        /// <summary>
        /// 是否启用缓存,子类实现
        /// </summary>
        protected abstract bool UsingCache { get; set; }
        #endregion

        #region 返回IN里面的SQL语句
        protected string getInSQL(string str, IList lst, List<IDataParameter> lstSp, SqlDbType type)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < lst.Count; i++)
            {
                string temp = str + i;
                if (i != 0)
                {
                    sb.Append(",");
                }
                sb.Append(temp);
                lstSp.Add(SQLDBTool.getParameter(temp, lst[i], type));
            }
            return sb.ToString();
        }
        #endregion
    }
}
