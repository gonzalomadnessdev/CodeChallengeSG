using CuentaService.Models;
using CuentaService.Repositories;
using Dapper;

namespace AuthService.Repositories
{
    public class CuentaDBRepository : BaseDBRepository, ICuentaRepository
    {
        public CuentaDBRepository(DapperContext context) : base(context)
        {
        }

        public async Task<bool> ExistsAsync(int id)
        {
            const string sql = "SELECT COUNT(1) FROM Cuenta WHERE id = @id";

            using (var conn = _context.CreateConnection())
            {
                var cuenta = await conn.ExecuteScalarAsync<bool>(sql, new { id });
                return cuenta;
            }
        }

        public async Task<Cuenta?> GetAsync(int id)
        {
            const string sql = "SELECT c.Id , cm.Saldo FROM Cuenta c LEFT JOIN CuentaMovimiento cm ON cm.CuentaId = c.Id WHERE c.id = @id";

            using (var conn = _context.CreateConnection())
            {
                var cuenta = await conn.QueryFirstOrDefaultAsync<Cuenta>(sql, new { id });
                return cuenta;
            }
        }
    }
}
