using System;
using System.Collections.Generic;

#nullable disable

namespace RainbowApp.Application.Model
{
    public partial class TblServiceProvider
    {
        public int Seq { get; set; }
        public string LocalCode { get; set; }
        public string MgtNo { get; set; }
        public string BplcNm { get; set; }
        public DateTime? ApvPermYmd { get; set; }
        public DateTime? ApvCancelYmd { get; set; }
        public string TrdStateGbn { get; set; }
        public string TrdStateNm { get; set; }
        public string DtlStateGbn { get; set; }
        public string DtlStateNm { get; set; }
        public DateTime? DcbYmd { get; set; }
        public DateTime? ClgStdt { get; set; }
        public DateTime? ClgEnddt { get; set; }
        public string SiteTel { get; set; }
        public string RdnWhlAddr { get; set; }
        public string RdnPostNo { get; set; }
        public string PositionX { get; set; }
        public string PositionY { get; set; }
    }
}
