using System;
using System.Data;
using System.Collections.Generic;
using Com.BLL.Base;
using Com.DAL.Base;
using LN.Model;
using LN.DAL;
namespace LN.BLL
{
	/// <summary>
	/// ҵ���߼���LogListBLL ��ժҪ˵����
	/// </summary>
	public class LogListBLL:BaseBLL<LogList>
	{
		#region  ��Ա����
		/// <summary>
		/// ����DALʵ�ָ��෽��
		/// </summary>
		protected override BaseDAL<LogList> GetDAL()
		{
		return new LogListDAL();
		}
		#endregion  ��Ա����
	}
}

