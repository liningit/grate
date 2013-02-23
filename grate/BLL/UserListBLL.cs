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
	/// ҵ���߼���UserListBLL ��ժҪ˵����
	/// </summary>
	public class UserListBLL:BaseBLL<UserList>
	{
		#region  ��Ա����
		/// <summary>
		/// ����DALʵ�ָ��෽��
		/// </summary>
		protected override BaseDAL<UserList> GetDAL()
		{
		return new UserListDAL();
		}
		#endregion  ��Ա����
	}
}

