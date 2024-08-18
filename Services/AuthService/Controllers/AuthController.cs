using AuthService.Dtos.Requests;
using AuthService.Dtos.Responses;
using AuthService.Repositories;
using AuthService.Services;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace AuthService.Controllers
{
    [Route("")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IJwtTokenGenerator _jwt;
        private ICuentaRepository _cuentaRepository;
        private IPasswordHasher _hasher;
        public AuthController(IJwtTokenGenerator jwt, ICuentaRepository cuentaRepository, IPasswordHasher hasher)
        {
            _jwt = jwt;
            _cuentaRepository = cuentaRepository;
            _hasher = hasher;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var cuenta = await _cuentaRepository.GetAsync(request.Username);

            if (cuenta == null || !_hasher.Verify(request.Password, cuenta.Password)) {
                return BadRequest();
            }

            (var token, var expires) = _jwt.GenerarToken(cuenta.Id);
            return Ok(new LoginResponse { Token = token, Expires = expires});
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var hashedPassword = _hasher.Hash(request.Password);
            await _cuentaRepository.Create(request.Username, hashedPassword);

            return Created();
        }

        //[HttpGet("test")]
        //public async Task<IActionResult> Test()
        //{
        //    var cuentas = await _cuentaRepository.GetCuentasAsync();

        //    return Ok(cuentas);
        //}

        //[HttpGet("testgetsubject")]
        //public async Task<IActionResult> Test2()
        //{
        //    var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
        //    var jwtToken = new JwtSecurityToken(token);

        //    return Ok(jwtToken.Subject);

        //}

        [HttpGet("health")]
        public IActionResult Health()
        {
            return Ok();
        }
    }


}
