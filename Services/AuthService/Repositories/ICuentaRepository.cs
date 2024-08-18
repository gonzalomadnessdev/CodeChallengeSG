using AuthService.Models;

namespace AuthService.Repositories
{
    public interface ICuentaRepository
    {
        Task<Cuenta?> GetAsync(string username);
        Task<IEnumerable<Cuenta>> GetCuentasAsync();
        Task<bool> Create(string username, string password);
    }
}