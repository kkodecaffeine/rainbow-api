using System;

namespace RainbowApp.Core.Entities
{
    public class ServiceProvider
    {
        public string LocalCode { get; set; }
        public string MgtNo { get; set; }
        /// <summary>
        /// 사업장명
        /// </summary>
        public string BplcNm { get; set; }
        public DateTime ApvPermYmd { get; set; }
        public DateTime ApvCancelYmd { get; set; }

        /// <summary>
        /// 영업상태코드
        /// </summary>
        public string TrdStateGbn { get; set; }
        /// <summary>
        /// 영업상태명
        /// </summary>
        public string TrdStateNm { get; set; }
        /// <summary>
        /// 상세영업상태코드
        /// </summary>
        public string DtlStateGbn { get; set; }
        /// <summary>
        /// 상세영업상태명
        /// </summary>
        public string DtlStateNm { get; set; }
        /// <summary>
        /// 폐업일자
        /// </summary>
        public DateTime DcbYmd { get; set; }
        /// <summary>
        /// 휴업시작일자
        /// </summary>
        public DateTime? ClgStdt { get; set; }
        /// <summary>
        /// 휴업종료일자
        /// </summary>
        public DateTime? ClgEnddt { get; set; }
        public string SiteTel { get; set; }
        /// <summary>
        /// 도로명주소
        /// </summary>
        public string RdnWhlAddr { get; set; }
        /// <summary>
        /// 도로명우편번호
        /// </summary>
        public string RdnPostNo { get; set; }
        public string PositionX { get; set; }
        public string PositionY { get; set; }
    }
}
