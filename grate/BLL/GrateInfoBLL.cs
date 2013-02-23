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
	/// ҵ���߼���GrateInfoBLL ��ժҪ˵����
	/// </summary>
	public class GrateInfoBLL:BaseBLL<GrateInfo>
	{
		#region  ��Ա����
		/// <summary>
		/// ����DALʵ�ָ��෽��
		/// </summary>
		protected  override BaseDAL<GrateInfo> GetDAL()
		{
		return new GrateInfoDAL();
		}
		#endregion  ��Ա����
	}
}

