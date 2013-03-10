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
	/// ҵ���߼���ShellTileListBLL ��ժҪ˵����
	/// </summary>
	public class ShellTileListBLL:BaseBLL<ShellTileList>
	{
		#region  ��Ա����
		/// <summary>
		/// ����DALʵ�ָ��෽��
		/// </summary>
		protected override BaseDAL<ShellTileList> GetDAL()
		{
		return new ShellTileListDAL();
		}
		#endregion  ��Ա����

        public ShellTileList GetModelByID(int id)
        {
            return GetModel(new ShellTileList() { Id = id });
        }
	}
}

