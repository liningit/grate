using System;
using Com.Tool;
namespace LN.Model
{
    /// <summary>
    /// 实体类GrateInfo 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class GrateInfo : BaseModel
    {
        public GrateInfo()
        {
            _PkList.Add(CellName.Id);
        }
        #region Model
        private int _id;
        private string _cName;
        private string _cEmail;
        private string _cTitle;
        private string _cUrl;
        private string _cImage;
        private DateTime _dCtime;
        private int _bFlag;
        private string _cIp;
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
        public string CEmail
        {
            set { _cEmail = value; ChageValue(CellName.CEmail); }
            get { return _cEmail; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CTitle
        {
            set { _cTitle = value; ChageValue(CellName.CTitle); }
            get { return _cTitle; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CUrl
        {
            set { _cUrl = value; ChageValue(CellName.CUrl); }
            get { return _cUrl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CImage
        {
            set { _cImage = value; ChageValue(CellName.CImage); }
            get { return _cImage; }
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
        public int BFlag
        {
            set { _bFlag = value; ChageValue(CellName.BFlag); }
            get { return _bFlag; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CIp
        {
            set { _cIp = value; ChageValue(CellName.CIp); }
            get { return _cIp; }
        }
        #endregion Model
        #region 映射
        /// <summary>
        /// 所有列集合
        /// </summary>
        public struct CellName
        {
            public const string Id = "id";
            public const string CName = "cname";
            public const string CEmail = "cemail";
            public const string CTitle = "ctitle";
            public const string CUrl = "curl";
            public const string CImage = "cimage";
            public const string DCtime = "dctime";
            public const string BFlag = "bflag";
            public const string CIp = "cip";
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
            return "GrateInfo";
        }
        /// <summary>
        /// 根据名称返回值
        /// </summary>
        public override object GetValue(string name)
        {
            switch (name.ToLower())
            {
                case CellName.Id: return Id;
                case CellName.CName: return CName;
                case CellName.CEmail: return CEmail;
                case CellName.CTitle: return CTitle;
                case CellName.CUrl: return CUrl;
                case CellName.CImage: return CImage;
                case CellName.DCtime: return DCtime;
                case CellName.BFlag: return BFlag;
                case CellName.CIp: return CIp;
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
                case CellName.CName: CName = ConvertTool.ToString(value); break;
                case CellName.CEmail: CEmail = ConvertTool.ToString(value); break;
                case CellName.CTitle: CTitle = ConvertTool.ToString(value); break;
                case CellName.CUrl: CUrl = ConvertTool.ToString(value); break;
                case CellName.CImage: CImage = ConvertTool.ToString(value); break;
                case CellName.DCtime: DCtime = ConvertTool.ToDateTime(value); break;
                case CellName.BFlag: BFlag = ConvertTool.ToInt32(value); break;
                case CellName.CIp: CIp = ConvertTool.ToString(value); break;
                default: throw new Exception("没有该字段:" + name);
            }
        }
        #endregion 映射

    }
}

