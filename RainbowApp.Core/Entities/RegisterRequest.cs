using System;
using System.ComponentModel.DataAnnotations;

namespace RainbowApp.Core.Entities
{
    public class RegisterRequest
    {
        [Required]
        [EmailAddress]
        public string MailAddr { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [Range(typeof(bool), "true", "true")]
        public bool AcceptTerms { get; set; }
    }
}
