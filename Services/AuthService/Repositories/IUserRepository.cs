using AuthService.Models;

namespace AuthService.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUserRecords(Func<User, bool> filter);
    }
}