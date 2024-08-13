using AuthService.Models;

namespace AuthService.Repositories
{
    public class UserInMemRepository : IUserRepository
    {
        private List<User> _users;

        public UserInMemRepository()
        {
            _users = new List<User> { new User { Id = 1, Username = "JohnDoe", Password = "123456" } };
        }
        public IEnumerable<User> GetUserRecords(Func<User, bool> filter)
        {
            var users = _users.Where(filter);
            return users;
        }
    }
}
