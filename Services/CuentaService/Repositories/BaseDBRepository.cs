using AuthService.Repositories;

namespace CuentaService.Repositories
{
    public abstract class BaseDBRepository
    {
        protected readonly DapperContext _context;
        public BaseDBRepository(DapperContext context)
        {
            _context = context;
        }
    }
}
