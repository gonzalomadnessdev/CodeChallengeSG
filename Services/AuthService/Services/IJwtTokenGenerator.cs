
using AuthService.Models;

namespace AuthService.Services
{
    public interface IJwtTokenGenerator
    {
        (string, DateTime) GenerarToken(User user);
    }
}