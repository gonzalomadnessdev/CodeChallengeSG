namespace AuthService.Services
{
    public interface IPasswordHasher
    {
        string Hash(string password);
        bool Verify(string inputPassword, string passwordHash);
    }
}