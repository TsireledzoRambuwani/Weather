

namespace WeatherApi.Models.Response
{
    public class ResponseCurrentWeekTemperature
    {
        public string[] Date { get; set; }

        public double[] Temperature { get; set; }
        public double[] WindSpeed { get; set; }
        public double[] RelativeHumidity { get; set; }
        public string TemperatureUnits { get; set; } = "°C";
        public string WindSpeedUnits { get; set; } = "km/h";
        public string RelativeHumidityUnits { get; set; } = "%";
    }
}
