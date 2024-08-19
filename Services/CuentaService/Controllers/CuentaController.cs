using AuthService.Repositories;
using Azure.Core;
using CuentaService.Dtos.Requests;
using CuentaService.Services;
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
        private ICuentasMovimientosService _cuentasMovimientosService;

        public CuentaController(ILogger<CuentaController> logger, ICuentaRepository cuentaRepository, ICuentasMovimientosService cuentasMovimientosService)
        {
            _logger = logger;
            _cuentaRepository = cuentaRepository;
            _cuentasMovimientosService = cuentasMovimientosService;
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
                return BadRequest();
            }

            var cuenta = await _cuentaRepository.GetAsync(int.Parse(cuentaId!));

            if (cuenta == null)
            {
                return BadRequest();
            }

            return Ok(new { saldo = cuenta!.Saldo });

        }

        [HttpPost("cashin")]
        public async Task<IActionResult> CashIn([FromBody] MovimientoRequest request)
        {
            var cuentaId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (cuentaId == null)
            {
                return BadRequest();
            }

            await _cuentasMovimientosService.CashIn(int.Parse(cuentaId), request.Importe);
            return Ok();
        }

        [HttpPost("cashout")]
        public async Task<IActionResult> CashOut([FromBody] MovimientoRequest request)
        {
            var cuentaId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (cuentaId == null)
            {
                return BadRequest();
            }

            await _cuentasMovimientosService.CashOut(int.Parse(cuentaId), request.Importe);
            return Ok();
        }


    }
}
