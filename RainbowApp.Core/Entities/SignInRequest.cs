using System.ComponentModel.DataAnnotations;

namespace RainbowApp.Core.Entities
{
    public class SignInRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }
    }
}
