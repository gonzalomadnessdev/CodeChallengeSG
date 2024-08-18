using Microsoft.AspNetCore.Mvc;

namespace CuentaService.Controllers
{
    [ApiController]
    [Route("")]
    public class CuentaController : ControllerBase
    {

        [HttpGet("health")]
        public IActionResult Health()
        {
            return Ok();
        }
    }
}
