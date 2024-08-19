using CuentaService.Models;

namespace CuentaService.Repositories
{
    public interface ICuentaMovimientoRepository
    {
        Task<bool> Crear(CuentaMovimiento movimiento);
    }
}