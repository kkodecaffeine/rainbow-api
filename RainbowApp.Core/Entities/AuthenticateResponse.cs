namespace RainbowApp.Core.Entities
{
    public class AuthenticateResponse
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string MailAddr { get; set; }
        public string Token { get; set; }


        public AuthenticateResponse(User user, string token)
        {
            UserId = user.UserId;
            Name = user.Name;
            MailAddr = user.MailAddr;
            Token = token;
        }
    }
}
