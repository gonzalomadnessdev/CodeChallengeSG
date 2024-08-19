
namespace CuentaService.Services
{
    public interface ICuentasMovimientosService
    {
        Task CashIn(int cuentaId, decimal importe);
        Task CashOut(int cuentaId, decimal importe);
    }
}