using AuthService.Dtos.Requests;
using AuthService.Dtos.Responses;
using AuthService.Repositories;
using AuthService.Services;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.Controllers
{
    [Route("")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IJwtTokenGenerator _jwt;
        private IUserRepository _userRepository;
        public AuthController(IJwtTokenGenerator jwt, IUserRepository userRepository)
        {
            _jwt = jwt;
            _userRepository = userRepository;
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {
            var user = _userRepository.GetUserRecords((user) => user.Username == request.Username)?.FirstOrDefault();

            if (user == null) {
                return BadRequest();
            }

            //utilizar hashing
            if(user.Password != request.Password)
            {
                return BadRequest();
            }

            (var token, var expires) = _jwt.GenerarToken(user);
            return Ok(new LoginResponse { Token = token, Expires = expires});
        }

        [HttpGet("health")]
        public IActionResult Health()
        {
            return Ok();
        }
    }


}
