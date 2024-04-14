
using WeatherApi.Models;
using WeatherApi.Models.Response;

namespace WeatherApi.Services
{
    public class WeatherRepository : IWeatherRepository
    {

        public double ConvertCelsiusToFahrenheit(double celsius)
          => celsius * 18 / 10 + 32;

        public double ConvertCelsiusToKelvin(double celsius)
            => celsius + 273;

        public double GetAverageTemperatureInPreiod(DateTime startdate, DateTime enddate, WeatherDto weather)
        {
            double average = 0;
            double[] temraturesinrange = GetInRageTemperatures(startdate, enddate, weather);

            if (temraturesinrange.Length != 0)
                     average = temraturesinrange.Average();

            return Math.Round(average);

        }



        public ResponseMaxAndMinTemperature GetMaxAndMinTemperatureInPreiod(DateTime startdate, DateTime enddate,WeatherDto weather)
        {
            ResponseMaxAndMinTemperature response = new ResponseMaxAndMinTemperature();

            double[] temraturesinrange = GetInRageTemperatures(startdate, enddate, weather);

            if (temraturesinrange.Length != 0)
                response = new ResponseMaxAndMinTemperature { MaximunTemperature = Math.Round(temraturesinrange.Max(), 2), MinimumTemperature = Math.Round(temraturesinrange.Min(), 2) };

            return response;
        }


        private static double[] GetInRageTemperatures(DateTime startdate, DateTime enddate, WeatherDto weather)
        {
            int startDateIndex = Array.IndexOf(weather.Hourly.Time, startdate.ToString("yyyy-MM-dd'T'HH:mm"));
            int endDateIndex = Array.IndexOf(weather.Hourly.Time, enddate.ToString("yyyy-MM-dd'T'HH:mm")) + 1;

            double[] temraturesinrange = weather.Hourly.Temperature2M[startDateIndex..endDateIndex];
            return temraturesinrange;
        }
    }
}