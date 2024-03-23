using Microsoft.AspNetCore.Mvc;
using Model;

namespace provider_one.Controllers
{
    [ApiController]
    [Route("api/v1")]
    public class ProviderController : ControllerBase
    {
        private readonly ILogger<ProviderController> _logger;

        public ProviderController(ILogger<ProviderController> logger)
        {
            _logger = logger;
        }

        [HttpGet("Ping")]
        public async Task<IActionResult> Ping()
        {
            return Ok();
        }

        [HttpPost("Search")]
        public async Task<IActionResult> Search()
        {
            return Ok(new ProviderOneSearchResponse());
        }
    }
}
