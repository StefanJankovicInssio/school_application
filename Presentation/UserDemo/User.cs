namespace Presentation.UserDemo
{
    public class User
    {
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Role { get; set; } = "admin";
    }
}
