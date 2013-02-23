using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LN.Model;
using Com.DAL.Base;
using System.Data;

namespace Com.BLL.Base 
{
    public abstract class BaseBLL<T> where T : BaseModel
    {
        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="model">要添加的数据</param>
        /// <returns>返回最后插入的标识值</returns>
        public int Add(T model)
        {
            return GetDAL().Add(model);
        }
        /// <summary>
        /// 更新一条数据根据PkList
        /// </summary>
        /// <param name="model">要更新的数据</param>
        /// <returns>返回影响的行数</returns>
        public int Update(T model)
        {
            return GetDAL().Update(model);                      
        }
        /// <summary>
        /// 更新一条数据根据PkList
        /// </summary>
        /// <param name="model">要更新的数据</param>
        /// <returns>返回影响的行数</returns>
        public int Update(T model,string userId)
        {
            return GetDAL().Update(model, userId);
        }
        /// <summary>
        /// 删除数据根据ChageList
        /// </summary>
        /// <param name="model">要删除的数据</param>
        /// <returns>返回影响的行数</returns>
        public int Delete(T model)
        {
            return GetDAL().Delete(model);            
        }

        /// <summary>
        /// 查询数据返回第一条数据
        /// </summary>
        /// <param name="model">筛选条件</param>
        /// <returns>返回第一条数据,如果没有则返回null</returns>
        public T GetModel(T model)
        {           
                return GetDAL().GetModel(model);
        }
        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="model">要筛选的条件</param>
        /// <returns>返回查询的数据</returns>
        public List<T> GetList(T model)
        {
            return GetDAL().GetList(model);
        }

        protected abstract BaseDAL<T> GetDAL();
        /// <summary>
        /// 根据idCell返回nameCell列
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public string GetNames(string idStr, List<T> lst, string idCell, string nameCell) 
        {
            if (string.IsNullOrEmpty(idStr.Trim()))
            {
                return "";
            }
            string[] ids = idStr.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            string strName = string.Empty;
            foreach (string id in ids)
            {
                T model = lst.Find(p => p.IsValue(idCell, id));
                if (model != null)
                {
                    strName += "," + model.GetValue(nameCell);
                }
            }
            if (!string.IsNullOrEmpty(strName))
            {
                strName = strName.Substring(1);
            }
            return strName;
        }

    }
}
