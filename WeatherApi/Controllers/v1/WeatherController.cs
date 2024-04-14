using Microsoft.AspNetCore.Mvc;
using WeatherApi.Helpers;
using WeatherApi.Models;
using WeatherApi.Models.Request;
using WeatherApi.Models.Response;
using WeatherApi.Services;
using WeatherApi.Wrappers;

namespace WeatherApi.Controllers.v1
{
    public class WeatherController : BaseApiController
    {
        private readonly IWeatherRepository _weatherUnit;
        private const string endpontsuffix = "current=temperature_2m,wind_speed_10m&hourly=temperature_2m,relative_humidity_2m,wind_speed_10m";
        public WeatherController(IHTTPClientHelperRepository helperRepository, IWeatherRepository weatherUnit) : base(helperRepository)
        {
            _weatherUnit = weatherUnit;
        }

        [HttpGet("weather")]
        public async Task<IActionResult> Get([FromQuery] RequestWeatherModel request)
        {
            var (data, code, message) = await _helperRepository
                                               .GetAsync<WeatherDto>
                                               ($"forecast?latitude={request.Latitude}&longitude={request.Longitude}&{endpontsuffix}");

            if (data is null)
                return Ok(new Response<bool?>(message, code));

            return Ok(data);
        }

        [HttpGet("celsiusToFahrenheit")]
        public IActionResult CelsiusToFahrenheit([FromQuery] RequestTemperatureModel request)
        {

            double fahrenheit = _weatherUnit.ConvertCelsiusToFahrenheit(request.Celsius);

            return Ok(new ResponseConvertedTemperature { Temperature = fahrenheit });
        }


        [HttpGet("celsiusToKelvin")]
        public IActionResult CelsiusToKelvin([FromQuery] RequestTemperatureModel request)
        {

            double kelvin = _weatherUnit.ConvertCelsiusToFahrenheit(request.Celsius);

            return Ok(new ResponseConvertedTemperature { Temperature = kelvin });
        }

        [HttpGet("GetAverageTemperatureInPreiod")]
        public async Task<IActionResult> GetAverageTemperatureInPreiod([FromQuery] RequestDurationModel request)
        {
            var (data, code, message) = await _helperRepository
                                               .GetAsync<WeatherDto>
                                               ($"forecast?latitude={request.Latitude}&longitude={request.Longitude}&{endpontsuffix}");

            if (data is null)
                return Ok(new Response<bool?>(message, code));
            var response = _weatherUnit.GetAverageTemperatureInPreiod(request.StartDate,request.EndDate,data);


            return Ok(response);
        }

        [HttpGet("GetMaxAndMinTemperatureInPreiod")]
        public async Task<IActionResult> GetMaxAndMinTemperatureInPreiod([FromQuery] RequestDurationModel request)
        {
            var (data, code, message) = await _helperRepository
                                               .GetAsync<WeatherDto>
                                               ($"forecast?latitude={request.Latitude}&longitude={request.Longitude}&{endpontsuffix}");

            if (data is null)
                return Ok(new Response<bool?>(message, code));

            var response = _weatherUnit.GetMaxAndMinTemperatureInPreiod(request.StartDate, request.EndDate, data);

            if (response == null)
                return NotFound();

            return Ok(response);
        }

        //Data Visualization

        [HttpGet("GetWeatherForCurrentWeek")]
        public async Task<IActionResult> GetWeatherForCurrentWeek([FromQuery] RequestWeatherModel request)
        {
            var (data, code, message) = await _helperRepository
                                               .GetAsync<WeatherDto>
                                               ($"forecast?latitude={request.Latitude}&longitude={request.Longitude}&{endpontsuffix}");

            if (data is null)
                return Ok(new Response<bool?>(message, code));

         


            return Ok(new ResponseCurrentWeekTemperature
            {
                Temperature = data.Hourly.Temperature2M,
                WindSpeed =data.Hourly.WindSpeed10M,
                RelativeHumidity =data.Hourly.RelativeHumidity2M,
                Date =data.Hourly.Time
            });
        }


    }
}
