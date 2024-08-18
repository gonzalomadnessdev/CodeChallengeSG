using AuthService.Repositories;
using CuentaService.Models;
using Dapper;

namespace CuentaService.Repositories
{
    public class CuentaMovimientoDBRepository : BaseDBRepository
    {
        public CuentaMovimientoDBRepository(DapperContext context) : base(context)
        {
        }

        public async Task<bool> Crear(CuentaMovimiento movimiento)
        {
            const string sql = "INSERT INTO CuentaMovimiento (CuentaId, Importe, Saldo) VALUES (@cuentaId, @importe, @saldo)";

            using (var conn = _context.CreateConnection())
            {
                var result = await conn.ExecuteAsync(sql, new { cuentaId = movimiento.CuentaId, importe = movimiento.Importe, saldo = movimiento.Saldo });
                return result > 0;
            }
        }

    }
}
