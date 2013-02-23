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
	/// 业务逻辑类UserPhoneBLL 的摘要说明。
	/// </summary>
	public class UserPhoneBLL:BaseBLL<UserPhone>
	{
		#region  成员方法
		/// <summary>
		/// 返回DAL实现父类方法
		/// </summary>
		protected override BaseDAL<UserPhone> GetDAL()
		{
		return new UserPhoneDAL();
		}
		#endregion  成员方法
	}
}

