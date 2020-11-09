using System;
using System.Text.Json.Serialization;
namespace RainbowApp.Application.Tasks.Dto
{
    public class UserDto
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string MailAddr { get; set; }
        [JsonIgnore]
        public string Password { get; set; }
        public string Domain { get; set; }
        public DateTime CreatedYmd { get; set; }
        public DateTime? ChangedYmd { get; set; }
    }
}
