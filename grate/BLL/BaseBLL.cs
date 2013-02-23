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
        /// ���һ������
        /// </summary>
        /// <param name="model">Ҫ��ӵ�����</param>
        /// <returns>����������ı�ʶֵ</returns>
        public int Add(T model)
        {
            return GetDAL().Add(model);
        }
        /// <summary>
        /// ����һ�����ݸ���PkList
        /// </summary>
        /// <param name="model">Ҫ���µ�����</param>
        /// <returns>����Ӱ�������</returns>
        public int Update(T model)
        {
            return GetDAL().Update(model);                      
        }
        /// <summary>
        /// ����һ�����ݸ���PkList
        /// </summary>
        /// <param name="model">Ҫ���µ�����</param>
        /// <returns>����Ӱ�������</returns>
        public int Update(T model,string userId)
        {
            return GetDAL().Update(model, userId);
        }
        /// <summary>
        /// ɾ�����ݸ���ChageList
        /// </summary>
        /// <param name="model">Ҫɾ��������</param>
        /// <returns>����Ӱ�������</returns>
        public int Delete(T model)
        {
            return GetDAL().Delete(model);            
        }

        /// <summary>
        /// ��ѯ���ݷ��ص�һ������
        /// </summary>
        /// <param name="model">ɸѡ����</param>
        /// <returns>���ص�һ������,���û���򷵻�null</returns>
        public T GetModel(T model)
        {           
                return GetDAL().GetModel(model);
        }
        /// <summary>
        /// ��ѯ����
        /// </summary>
        /// <param name="model">Ҫɸѡ������</param>
        /// <returns>���ز�ѯ������</returns>
        public List<T> GetList(T model)
        {
            return GetDAL().GetList(model);
        }

        protected abstract BaseDAL<T> GetDAL();
        /// <summary>
        /// ����idCell����nameCell��
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
