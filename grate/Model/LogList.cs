using System;
using Com.Tool;
namespace LN.Model
{
    /// <summary>
    /// ʵ����LogList ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
    /// </summary>
    [Serializable]
    public class LogList : BaseModel
    {
        public LogList()
        {
            _PkList.Add(CellName.Id);
        }
        #region Model
        private int _id;
        private string _cSql;
        private string _cParameters;
        private string _cUserId;
        private string _cIp;
        private DateTime _dCtime;
        private string _cMemo;
        /// <summary>
        /// 
        /// </summary>
        public int Id
        {
            set { _id = value; ChageValue(CellName.Id); }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CSql
        {
            set { _cSql = value; ChageValue(CellName.CSql); }
            get { return _cSql; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CParameters
        {
            set { _cParameters = value; ChageValue(CellName.CParameters); }
            get { return _cParameters; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CUserId
        {
            set { _cUserId = value; ChageValue(CellName.CUserId); }
            get { return _cUserId; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CIp
        {
            set { _cIp = value; ChageValue(CellName.CIp); }
            get { return _cIp; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime DCtime
        {
            set { _dCtime = value; ChageValue(CellName.DCtime); }
            get { return _dCtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CMemo
        {
            set { _cMemo = value; ChageValue(CellName.CMemo); }
            get { return _cMemo; }
        }
        #endregion Model
        #region ӳ��
        /// <summary>
        /// �����м���
        /// </summary>
        public struct CellName
        {
            public const string Id = "id";
            public const string CSql = "csql";
            public const string CParameters = "cparameters";
            public const string CUserId = "cuserid";
            public const string CIp = "cip";
            public const string DCtime = "dctime";
            public const string CMemo = "cmemo";
        }
        /// <summary>
        /// ����������
        /// </summary>
        protected override string GetIdentityCell()
        {
            return CellName.Id;
        }
        /// <summary>
        /// �������ݿ����
        /// </summary>
        protected override string GetTableName()
        {
            return "LogList";
        }
        /// <summary>
        /// �������Ʒ���ֵ
        /// </summary>
        public override object GetValue(string name)
        {
            switch (name.ToLower())
            {
                case CellName.Id: return Id;
                case CellName.CSql: return CSql;
                case CellName.CParameters: return CParameters;
                case CellName.CUserId: return CUserId;
                case CellName.CIp: return CIp;
                case CellName.DCtime: return DCtime;
                case CellName.CMemo: return CMemo;
                default: return null;
            }
        }
        /// <summary>
        /// ������������ֵ
        /// </summary>
        public override void SetValue(string name, object value)
        {
            switch (name.ToLower())
            {
                case CellName.Id: Id = Convert.ToInt32(value); break;
                case CellName.CSql: CSql = ConvertTool.ToString(value); break;
                case CellName.CParameters: CParameters = ConvertTool.ToString(value); break;
                case CellName.CUserId: CUserId = ConvertTool.ToString(value); break;
                case CellName.CIp: CIp = ConvertTool.ToString(value); break;
                case CellName.DCtime: DCtime = ConvertTool.ToDateTime(value); break;
                case CellName.CMemo: CMemo = ConvertTool.ToString(value); break;
                default: throw new Exception("û�и��ֶ�:" + name);
            }
        }
        #endregion ӳ��

    }
}

