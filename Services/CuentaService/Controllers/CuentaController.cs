using AuthService.Repositories;
using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace CuentaService.Controllers
{
    [ApiController]
    [Route("")]
    public class CuentaController : ControllerBase
    {
        private ILogger _logger;
        private ICuentaRepository _cuentaRepository;

        public CuentaController(ILogger<CuentaController> logger, ICuentaRepository cuentaRepository)
        {
            _logger = logger;
            _cuentaRepository = cuentaRepository;
        }
        [HttpGet("health")]
        public IActionResult Health()
        {
            return Ok();
        }

        [HttpGet("saldo"), Authorize]
        public async Task<IActionResult> Saldo()
        {
            var cuentaId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if(cuentaId == null)
            {
                BadRequest();
            }

            var cuenta = await _cuentaRepository.GetAsync(int.Parse(cuentaId!));

            if (cuenta == null)
            {
                BadRequest();
            }

            return Ok(new { saldo = cuenta!.Saldo });

        }

        //[HttpPost("cashin")]
        //public async Task<IActionResult> CashIn() {
        
        
        //}


    }
}
