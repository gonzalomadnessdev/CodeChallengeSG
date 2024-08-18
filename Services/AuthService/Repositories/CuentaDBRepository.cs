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

        public async Task<IEnumerable<Cuenta>> GetCuentasAsync()
        {

            const string sql = "SELECT * FROM Cuenta";

            using (var conn = _context.CreateConnection())
            {
                var cuentas = conn.QueryAsync<Cuenta>(sql);
                return await cuentas;
            }

        }

        public async Task<bool> Create(string username, string password)
        {
            const string sql = "INSERT INTO Cuenta VALUES (@username, @password)";

            using (var conn = _context.CreateConnection())
            {
                var result = await conn.ExecuteAsync(sql, new { username = username, password = password });
                return result > 0;
            }
        }

        public async Task<Cuenta?> GetAsync(string username)
        {
            const string sql = "SELECT * FROM Cuenta WHERE username = @username";

            using (var conn = _context.CreateConnection())
            {
                var cuenta = conn.QueryFirstOrDefaultAsync<Cuenta>(sql, new { username = username });
                return await cuenta;
            }
        }
    }
}
