using System;
using System.Text.Json.Serialization;

namespace RainbowApp.Core.Entities
{
    public class Account
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string MailAddr { get; set; }

        [JsonIgnore]
        public string Password { get; set; }
        public DateTime? PasswordResetYmd { get; set; }
        [JsonIgnore]
        public string VerificationToken { get; set; }
        public DateTime? VerifiedYmd { get; set; }
        public bool? IsVerifed { get; set; }
        public string ResetToken { get; set; }
        public DateTime? ResetTokenExpiredYmd { get; set; }
        public string Domain { get; set; }
        public DateTime CreatedYmd { get; set; }
        public DateTime? ChagedYmd { get; set; }
        //public int UserId { get; set; }
        //public string Name { get; set; }
        //public string MailAddr { get; set; }
        //[JsonIgnore]
        //public string Password { get; set; }
        //public string Domain { get; set; }
        //public DateTime CreatedYmd { get; set; }
        //public DateTime? ChangedYmd { get; set; }
    }
}
