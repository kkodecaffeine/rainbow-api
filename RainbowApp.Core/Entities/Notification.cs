﻿using System;
namespace RainbowApp.Core.Entities
{
    public class Notification : BaseEntity
    {
        public int NotiId { get; set; } = 0;
        public int FromUserId { get; set; } = 0;
        public int ToUserId { get; set; } = 0;
        public string NotiHeader { get; set; }
        public string NotiBody { get; set; }
        public bool IsRead { get; set; } = false;
        public string Url { get; set; }
        public DateTime CreatedYmd { get; set; } = DateTime.Now;
        public string Message { get; set; }

        public string CreatedYmdSt => this.CreatedYmd.ToString("dd-MMM-yyyy HH:mm:ss");
        public string IsReadSt => this.IsRead ? "YES" : "NO";

        public string FromUserName { get; set; }
        public string ToUserName { get; set; }
    }
}
