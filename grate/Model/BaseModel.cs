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
        /// ����
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
        /// �ı�ֵ���ֶ�
        /// </summary>
        StringCollection _ChageList = new StringCollection();

        /// <summary>
        /// ����,���û����Ϊ������
        /// </summary>
       protected StringCollection _PkList = new StringCollection();
        

        /// <summary>
        /// ���������Ѹı������
        /// </summary>
        public StringCollection ChageList { get { return _ChageList; } }
        /// <summary>
        /// 
        /// </summary>
        public StringCollection PkList { get { return _PkList; } }

       
        /// <summary>
        /// �ı�ֵʱ����
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
        /// �ж�ֵ�Ƿ�һ��
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
        /// �ж��Ƿ��������
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
        /// ����������
        /// </summary>
        /// <returns></returns>
        protected virtual string GetIdentityCell() { return null; }
        /// <summary>
        /// ���ر���
        /// </summary>
        /// <returns></returns>
        protected virtual string GetTableName() { return null; }
        /// <summary>
        /// �������Ʒ���ֵ
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public virtual object GetValue(string name) { return null; }
        /// <summary>
        /// ������������ֵ
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public virtual void SetValue(string name, object value) {  }
    }
}
