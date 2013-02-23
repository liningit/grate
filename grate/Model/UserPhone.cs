using System;
using Com.Tool;
namespace LN.Model
{
    /// <summary>
    /// ʵ����UserPhone ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
    /// </summary>
    [Serializable]
    public class UserPhone : BaseModel
    {
        public UserPhone()
        {
            _PkList.Add(CellName.Id);
        }
        #region Model
        private int _id;
        private string _cName;
        private string _cPhone;
        private string _cUser;
        private string _cGroupCode;
        private string _cIp;
        private int _bFlag;
        private DateTime _dCtime;
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
        public string CName
        {
            set { _cName = value; ChageValue(CellName.CName); }
            get { return _cName; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CPhone
        {
            set { _cPhone = value; ChageValue(CellName.CPhone); }
            get { return _cPhone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CUser
        {
            set { _cUser = value; ChageValue(CellName.CUser); }
            get { return _cUser; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CGroupCode
        {
            set { _cGroupCode = value; ChageValue(CellName.CGroupCode); }
            get { return _cGroupCode; }
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
        public int BFlag
        {
            set { _bFlag = value; ChageValue(CellName.BFlag); }
            get { return _bFlag; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime DCtime
        {
            set { _dCtime = value; ChageValue(CellName.DCtime); }
            get { return _dCtime; }
        }
        #endregion Model
        #region ӳ��
        /// <summary>
        /// �����м���
        /// </summary>
        public struct CellName
        {
            public const string Id = "id";
            public const string CName = "cname";
            public const string CPhone = "cphone";
            public const string CUser = "cuser";
            public const string CGroupCode = "cgroupcode";
            public const string CIp = "cip";
            public const string BFlag = "bflag";
            public const string DCtime = "dctime";
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
            return "UserPhone";
        }
        /// <summary>
        /// �������Ʒ���ֵ
        /// </summary>
        public override object GetValue(string name)
        {
            switch (name.ToLower())
            {
                case CellName.Id: return Id;
                case CellName.CName: return CName;
                case CellName.CPhone: return CPhone;
                case CellName.CUser: return CUser;
                case CellName.CGroupCode: return CGroupCode;
                case CellName.CIp: return CIp;
                case CellName.BFlag: return BFlag;
                case CellName.DCtime: return DCtime;
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
                case CellName.CName: CName = ConvertTool.ToString(value); break;
                case CellName.CPhone: CPhone = ConvertTool.ToString(value); break;
                case CellName.CUser: CUser = ConvertTool.ToString(value); break;
                case CellName.CGroupCode: CGroupCode = ConvertTool.ToString(value); break;
                case CellName.CIp: CIp = ConvertTool.ToString(value); break;
                case CellName.BFlag: BFlag = ConvertTool.ToInt32(value); break;
                case CellName.DCtime: DCtime = ConvertTool.ToDateTime(value); break;
                default: throw new Exception("û�и��ֶ�:" + name);
            }
        }
        #endregion ӳ��

    }
}

