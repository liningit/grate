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
	/// 业务逻辑类GrateInfoBLL 的摘要说明。
	/// </summary>
	public class GrateInfoBLL:BaseBLL<GrateInfo>
	{
		#region  成员方法
		/// <summary>
		/// 返回DAL实现父类方法
		/// </summary>
		protected  override BaseDAL<GrateInfo> GetDAL()
		{
		return new GrateInfoDAL();
		}
		#endregion  成员方法
	}
}

