using System;
using Com.Tool;
namespace LN.Model
{
    /// <summary>
    /// 实体类ShellTileList 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class ShellTileList : BaseModel
    {
        public ShellTileList()
        {
            _PkList.Add(CellName.Id);
        }
        #region Model
        private int _id;
        private string _cUserId;
        private string _cType;
        private string _cImg;
        private decimal _nOrder;
        private int _iHot;
        private decimal _nWidth;
        private decimal _nHeight;
        private int _bIsTitle;
        private int _bFlag;
        private string _cCheckInfo;
        private string _cDoUser;
        private DateTime _dCTime;
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
        public string CType
        {
            set { _cType = value; ChageValue(CellName.CType); }
            get { return _cType; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CImg
        {
            set { _cImg = value; ChageValue(CellName.CImg); }
            get { return _cImg; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal NOrder
        {
            set { _nOrder = value; ChageValue(CellName.NOrder); }
            get { return _nOrder; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int IHot
        {
            set { _iHot = value; ChageValue(CellName.IHot); }
            get { return _iHot; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal NWidth
        {
            set { _nWidth = value; ChageValue(CellName.NWidth); }
            get { return _nWidth; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal NHeight
        {
            set { _nHeight = value; ChageValue(CellName.NHeight); }
            get { return _nHeight; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int BIsTitle
        {
            set { _bIsTitle = value; ChageValue(CellName.BIsTitle); }
            get { return _bIsTitle; }
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
        public string CCheckInfo
        {
            set { _cCheckInfo = value; ChageValue(CellName.CCheckInfo); }
            get { return _cCheckInfo; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CDoUser
        {
            set { _cDoUser = value; ChageValue(CellName.CDoUser); }
            get { return _cDoUser; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime DCTime
        {
            set { _dCTime = value; ChageValue(CellName.DCTime); }
            get { return _dCTime; }
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
            public const string CType = "ctype";
            public const string CImg = "cimg";
            public const string NOrder = "norder";
            public const string IHot = "ihot";
            public const string NWidth = "nwidth";
            public const string NHeight = "nheight";
            public const string BIsTitle = "bistitle";
            public const string BFlag = "bflag";
            public const string CCheckInfo = "ccheckinfo";
            public const string CDoUser = "cdouser";
            public const string DCTime = "dctime";
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
            return "ShellTileList";
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
                case CellName.CType: return CType;
                case CellName.CImg: return CImg;
                case CellName.NOrder: return NOrder;
                case CellName.IHot: return IHot;
                case CellName.NWidth: return NWidth;
                case CellName.NHeight: return NHeight;
                case CellName.BIsTitle: return BIsTitle;
                case CellName.BFlag: return BFlag;
                case CellName.CCheckInfo: return CCheckInfo;
                case CellName.CDoUser: return CDoUser;
                case CellName.DCTime: return DCTime;
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
                case CellName.CType: CType = ConvertTool.ToString(value); break;
                case CellName.CImg: CImg = ConvertTool.ToString(value); break;
                case CellName.NOrder: NOrder = ConvertTool.ToDecimal(value); break;
                case CellName.IHot: IHot = ConvertTool.ToInt32(value); break;
                case CellName.NWidth: NWidth = ConvertTool.ToDecimal(value); break;
                case CellName.NHeight: NHeight = ConvertTool.ToDecimal(value); break;
                case CellName.BIsTitle: BIsTitle = ConvertTool.ToInt32(value); break;
                case CellName.BFlag: BFlag = ConvertTool.ToInt32(value); break;
                case CellName.CCheckInfo: CCheckInfo = ConvertTool.ToString(value); break;
                case CellName.CDoUser: CDoUser = ConvertTool.ToString(value); break;
                case CellName.DCTime: DCTime = ConvertTool.ToDateTime(value); break;
                default: throw new Exception("没有该字段:" + name);
            }
        }
        #endregion 映射

    }
}

