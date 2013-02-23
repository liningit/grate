using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using Com.Tool;
using System.Linq.Expressions;
using System.Runtime.Serialization;

namespace LN.Model
{
    [Serializable]
    public class BaseModel 
    { 
        /// <summary>
        /// 表名
        /// </summary>
        public string TableName { get { return GetTableName(); } }
        public string IdentityCell
        {
            get
            {
                string _IdentityCell = GetIdentityCell();
                return string.IsNullOrEmpty(_IdentityCell) ? "" : _IdentityCell;
            }
        }
        /// <summary>
        /// 改变值的字段
        /// </summary>
        StringCollection _ChageList = new StringCollection();

        /// <summary>
        /// 主键,如果没有则为自增列
        /// </summary>
       protected StringCollection _PkList = new StringCollection();
        

        /// <summary>
        /// 保存所有已改变的属性
        /// </summary>
        public StringCollection ChageList { get { return _ChageList; } }
        /// <summary>
        /// 
        /// </summary>
        public StringCollection PkList { get { return _PkList; } }

       
        /// <summary>
        /// 改变值时调用
        /// </summary>
        /// <param name="name"></param>
        public void ChageValue(string name)
        {
            if (!ChageList.Contains(name))
            {

                ChageList.Add(name);
            }
        }
        /// <summary>
        /// 判断值是否一致
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public virtual bool IsValue(string name, object value)
        {
            if (value == null)
            {
                return GetValue(name) == null;
            }
            return GetValue(name).ToString().ToLower() == value.ToString().ToLower();
        }

        /// <summary>
        /// 判断是否符合条件
        /// </summary>
        public virtual bool IsSelect(BaseModel model)
        {
            foreach (string cell in model.ChageList)
            {
                if (!IsValue(cell, model.GetValue(cell)))
                {
                    return false;
                }
            }
            return true;
        }    

        /// <summary>
        /// 返回自增列
        /// </summary>
        /// <returns></returns>
        protected virtual string GetIdentityCell() { return null; }
        /// <summary>
        /// 返回表名
        /// </summary>
        /// <returns></returns>
        protected virtual string GetTableName() { return null; }
        /// <summary>
        /// 根据名称返回值
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public virtual object GetValue(string name) { return null; }
        /// <summary>
        /// 根据名称设置值
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public virtual void SetValue(string name, object value) {  }
    }
}
