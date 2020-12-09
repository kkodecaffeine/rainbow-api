using System;
using System.Collections.Generic;

#nullable disable

namespace RainbowApp.Application.Model
{
    public partial class TblAccount
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MailAddr { get; set; }
        public string Password { get; set; }
        public DateTime? PasswordResetYmd { get; set; }
        public string VerificationToken { get; set; }
        public DateTime? VerifiedYmd { get; set; }
        public bool? IsVerifed { get; set; }
        public string ResetToken { get; set; }
        public DateTime? ResetTokenExpiredYmd { get; set; }
        public string Domain { get; set; }
        public DateTime CreatedYmd { get; set; }
        public DateTime? ChagedYmd { get; set; }
    }
}
