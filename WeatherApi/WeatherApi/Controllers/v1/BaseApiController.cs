
using Microsoft.AspNetCore.Mvc;
using WeatherApi.Helpers;

namespace WeatherApi.Controllers.v1

{
    [Route("api/")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        protected readonly IHTTPClientHelperRepository _helperRepository;

        public BaseApiController(IHTTPClientHelperRepository helperRepository)
        {

            _helperRepository = helperRepository;

        }
    }
}
