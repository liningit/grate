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
	/// ���ݷ�����UserPhoneDAL��
	/// </summary>
	public class UserPhoneDAL:BaseDAL<UserPhone>{
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
		protected override UserPhone GetNewModel()
		{
		return new UserPhone();
		}
		#endregion  ��Ա����
	}
}

