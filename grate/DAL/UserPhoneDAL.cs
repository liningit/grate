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
	/// 数据访问类UserPhoneDAL。
	/// </summary>
	public class UserPhoneDAL:BaseDAL<UserPhone>{
		#region  成员方法

		/// <summary>
		/// 是否启用缓存,默认启用
		/// </summary>
		private static bool UsingCacheStatic = true;
		protected override bool UsingCache
		{
		get { return UsingCacheStatic; }
		set { UsingCacheStatic = value; }
		}
		/// <summary>
		/// 实现父类的方法返回新的实体类
		/// </summary>
		protected override UserPhone GetNewModel()
		{
		return new UserPhone();
		}
		#endregion  成员方法
	}
}

