using System;
using System.Collections.Generic;

#nullable disable

namespace RainbowApp.Application.Model
{
    public partial class TblNotification
    {
        public int NotiId { get; set; }
        public int? FromUserId { get; set; }
        public int? ToUserId { get; set; }
        public string NotiHeader { get; set; }
        public string NotiBody { get; set; }
        public bool? IsRead { get; set; }
        public string Url { get; set; }
        public DateTime? CreatedYmd { get; set; }
    }
}
