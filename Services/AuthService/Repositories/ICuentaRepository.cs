using AuthService.Models;

namespace AuthService.Repositories
{
    public interface ICuentaRepository
    {
        Task<bool> ExistsAsync(string username);
        Task<Cuenta?> GetAsync(string username);
        Task<IEnumerable<Cuenta>> GetCuentasAsync();
        Task<bool> Create(Cuenta cuenta);
    }
}