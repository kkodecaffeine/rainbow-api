using System;
using System.Collections.Generic;

#nullable disable

namespace RainbowApp.Application.Model
{
    public partial class TblMember
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Domain { get; set; }
        public DateTime CreatedYmd { get; set; }
        public DateTime? ChagedYmd { get; set; }
    }
}
