namespace AuthService.Services
{
    public class PasswordHasher : IPasswordHasher
    {
        public string Hash(string password)
        {
            return BCrypt.Net.BCrypt.EnhancedHashPassword(password);
        }

        public bool Verify(string inputPassword, string passwordHash)
        {
            return BCrypt.Net.BCrypt.EnhancedVerify(inputPassword, passwordHash);
        }
    }
}
