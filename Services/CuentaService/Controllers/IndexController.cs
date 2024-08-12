using Microsoft.AspNetCore.Mvc;

namespace CuentaService.Controllers
{
    [ApiController]
    [Route("")]
    public class IndexController : ControllerBase
    {
        private readonly ILogger<IndexController> _logger;

        public IndexController(ILogger<IndexController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "")]
        public string Get()
        {
            return "Ok";
        }
    }
}
