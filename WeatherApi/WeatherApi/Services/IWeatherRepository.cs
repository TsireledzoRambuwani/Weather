using System.Net;
using WeatherApi.Models;
using WeatherApi.Models.Response;
using WeatherApi.Wrappers;

namespace WeatherApi.Services
{
    public interface IWeatherRepository
    {
        double ConvertCelsiusToFahrenheit(double celsius);
        double ConvertCelsiusToKelvin(double celsius);
        double GetAverageTemperatureInPreiod(DateTime startdate, DateTime enddate, WeatherDto weather);
        ResponseMaxAndMinTemperature GetMaxAndMinTemperatureInPreiod(DateTime startdate, DateTime enddate, WeatherDto weather);
    }
}
