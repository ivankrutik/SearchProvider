using Microsoft.AspNetCore.Mvc;
using RouteProviderOne.Interface.Service;
using System.Net;
using TestTask;

// HTTP GET http://provider-one/api/v1/ping
//      - HTTP 200 if provider is ready
//      - HTTP 500 if provider is down

// HTTP POST http://provider-one/api/v1/search

namespace RouteProviderOne.Controllers
{
    [ApiController]
    [Route("api/v1")]
    public class RouteAPIController : ControllerBase
    {
        private readonly ILogger<RouteAPIController> _logger;
        private readonly ISearchServiceOne _searchServiceOne;
        private readonly ISearchServiceTwo _searchServiceTwo;

        public RouteAPIController(ILogger<RouteAPIController> logger, ISearchServiceOne searchServiceOne, ISearchServiceTwo searchServiceTwo)
        {
            _logger = logger;
            _searchServiceOne = searchServiceOne;
            _searchServiceTwo = searchServiceTwo;
        }

        [HttpGet("Ping")]
        public async Task<IActionResult> Ping()
        {
            var res = await _searchServiceOne.IsAvailableAsync(new CancellationToken());
            var res2 = await _searchServiceTwo.IsAvailableAsync(new CancellationToken());
            if (res || res2)
            {
                return Ok(res);
            }
            else
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost("Search")]
        public async Task<SearchResponse> Search(SearchRequest req)
        {
            return new SearchResponse();
        }
    }
}
