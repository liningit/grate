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
	/// ҵ���߼���UserPhoneBLL ��ժҪ˵����
	/// </summary>
	public class UserPhoneBLL:BaseBLL<UserPhone>
	{
		#region  ��Ա����
		/// <summary>
		/// ����DALʵ�ָ��෽��
		/// </summary>
		protected override BaseDAL<UserPhone> GetDAL()
		{
		return new UserPhoneDAL();
		}
		#endregion  ��Ա����
	}
}

