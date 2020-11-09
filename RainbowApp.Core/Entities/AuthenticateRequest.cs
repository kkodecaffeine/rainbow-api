using System.ComponentModel.DataAnnotations;

namespace RainbowApp.Core.Entities
{
    public class AuthenticateRequest
    {
        [Required]
        public string MailAddr { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
