using CuentaService.Models;

namespace AuthService.Repositories
{
    public interface ICuentaRepository
    {
        Task<bool> ExistsAsync(int id);
        Task<Cuenta?> GetAsync(int id);
    }
}