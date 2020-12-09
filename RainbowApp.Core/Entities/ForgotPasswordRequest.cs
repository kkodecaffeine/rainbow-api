using System.ComponentModel.DataAnnotations;

namespace RainbowApp.Core.Entities
{
    public class ForgotPasswordRequest
    {
        [Required]
        [EmailAddress]
        public string MailAddr { get; set; }
    }
}
