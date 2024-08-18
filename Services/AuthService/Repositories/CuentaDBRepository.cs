using AuthService.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace AuthService.Repositories
{
    public class CuentaDBRepository : ICuentaRepository
    {
        private readonly DapperContext _context;
        public CuentaDBRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<bool> ExistsAsync(string username)
        {
            const string sql = "SELECT COUNT(1) FROM Cuenta WHERE username = @username";

            using (var conn = _context.CreateConnection())
            {
                var cuenta = await conn.ExecuteScalarAsync<bool>(sql, new { username });
                return cuenta;
            }
        }

        public async Task<IEnumerable<Cuenta>> GetCuentasAsync()
        {

            const string sql = "SELECT * FROM Cuenta";

            using (var conn = _context.CreateConnection())
            {
                var cuentas = conn.QueryAsync<Cuenta>(sql);
                return await cuentas;
            }

        }

        public async Task<bool> Create(Cuenta cuenta)
        {
            const string sql = "INSERT INTO Cuenta (Username, Password) VALUES (@username, @password)";

            using (var conn = _context.CreateConnection())
            {
                var result = await conn.ExecuteAsync(sql, new { username = cuenta.Username, password = cuenta.Password });
                return result > 0;
            }
        }

        public async Task<Cuenta?> GetAsync(string username)
        {
            const string sql = "SELECT * FROM Cuenta WHERE username = @username";

            using (var conn = _context.CreateConnection())
            {
                var cuenta = await conn.QueryFirstOrDefaultAsync<Cuenta>(sql, new { username });
                return cuenta;
            }
        }
    }
}
