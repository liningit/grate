using System;
using Com.Tool;
namespace LN.Model
{
    /// <summary>
    /// 实体类UserList 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class UserList : BaseModel
    {
        public UserList()
        {
            _PkList.Add(CellName.Id);
        }
        #region Model
        private int _id;
        private string _cUserId;
        private string _cUserName;
        private string _cLoginName;
        private string _cPassWord;
        private string _cType;
        private DateTime _dCTime;
        private int _bflag;
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
        public string CUserId
        {
            set { _cUserId = value; ChageValue(CellName.CUserId); }
            get { return _cUserId; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CUserName
        {
            set { _cUserName = value; ChageValue(CellName.CUserName); }
            get { return _cUserName; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CLoginName
        {
            set { _cLoginName = value; ChageValue(CellName.CLoginName); }
            get { return _cLoginName; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CPassWord
        {
            set { _cPassWord = value; ChageValue(CellName.CPassWord); }
            get { return _cPassWord; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CType
        {
            set { _cType = value; ChageValue(CellName.CType); }
            get { return _cType; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime DCTime
        {
            set { _dCTime = value; ChageValue(CellName.DCTime); }
            get { return _dCTime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Bflag
        {
            set { _bflag = value; ChageValue(CellName.Bflag); }
            get { return _bflag; }
        }
        #endregion Model
        #region 映射
        /// <summary>
        /// 所有列集合
        /// </summary>
        public struct CellName
        {
            public const string Id = "id";
            public const string CUserId = "cuserid";
            public const string CUserName = "cusername";
            public const string CLoginName = "cloginname";
            public const string CPassWord = "cpassword";
            public const string CType = "ctype";
            public const string DCTime = "dctime";
            public const string Bflag = "bflag";
        }
        /// <summary>
        /// 返回自增列
        /// </summary>
        protected override string GetIdentityCell()
        {
            return CellName.Id;
        }
        /// <summary>
        /// 返回数据库表名
        /// </summary>
        protected override string GetTableName()
        {
            return "UserList";
        }
        /// <summary>
        /// 根据名称返回值
        /// </summary>
        public override object GetValue(string name)
        {
            switch (name.ToLower())
            {
                case CellName.Id: return Id;
                case CellName.CUserId: return CUserId;
                case CellName.CUserName: return CUserName;
                case CellName.CLoginName: return CLoginName;
                case CellName.CPassWord: return CPassWord;
                case CellName.CType: return CType;
                case CellName.DCTime: return DCTime;
                case CellName.Bflag: return Bflag;
                default: return null;
            }
        }
        /// <summary>
        /// 根据名称设置值
        /// </summary>
        public override void SetValue(string name, object value)
        {
            switch (name.ToLower())
            {
                case CellName.Id: Id = Convert.ToInt32(value); break;
                case CellName.CUserId: CUserId = ConvertTool.ToString(value); break;
                case CellName.CUserName: CUserName = ConvertTool.ToString(value); break;
                case CellName.CLoginName: CLoginName = ConvertTool.ToString(value); break;
                case CellName.CPassWord: CPassWord = ConvertTool.ToString(value); break;
                case CellName.CType: CType = ConvertTool.ToString(value); break;
                case CellName.DCTime: DCTime = ConvertTool.ToDateTime(value); break;
                case CellName.Bflag: Bflag = ConvertTool.ToInt32(value); break;
                default: throw new Exception("没有该字段:" + name);
            }
        }
        #endregion 映射

    }
}

