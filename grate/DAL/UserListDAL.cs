using System;
using System.Data;
using System.Data.Common;
using System.Text;
using System.Collections.Generic;
using LN.Model;
using Com.DAL.Base;
namespace LN.DAL
{
	/// <summary>
	/// ���ݷ�����UserListDAL��
	/// </summary>
	public class UserListDAL:BaseDAL<UserList>{
		#region  ��Ա����

		/// <summary>
		/// �Ƿ����û���,Ĭ������
		/// </summary>
		private static bool UsingCacheStatic = true;
		protected override bool UsingCache
		{
		get { return UsingCacheStatic; }
		set { UsingCacheStatic = value; }
		}
		/// <summary>
		/// ʵ�ָ���ķ��������µ�ʵ����
		/// </summary>
		protected override UserList GetNewModel()
		{
		return new UserList();
		}
		#endregion  ��Ա����
	}
}

