namespace RainbowApp.Core.Entities
{
    public class AuthenticateResponse
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }


        public AuthenticateResponse(Account user, string token)
        {
            UserId = user.UserId;
            Name = user.Name;
            Email = user.Email;
            Token = token;
        }
    }
}
