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
	/// ҵ���߼���VCardBLL ��ժҪ˵����
	/// </summary>
	public class VCardBLL:BaseBLL<VCard>
	{
		#region  ��Ա����
		/// <summary>
		/// ����DALʵ�ָ��෽��
		/// </summary>
		protected override BaseDAL<VCard> GetDAL()
		{
		return new VCardDAL();
		}
		#endregion  ��Ա����
	}
}

