using Microsoft.Data.SqlClient;
using System.Data;

namespace AuthService.Repositories
{
    public class DapperContext
    {
        private string connectionString;
        public DapperContext(IConfiguration config)
        {
            connectionString = config.GetConnectionString("SG")!;
        }

        public IDbConnection CreateConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
