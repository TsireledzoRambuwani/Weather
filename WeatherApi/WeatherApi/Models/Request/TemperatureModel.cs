namespace WeatherApi.Models.Request
{
    public abstract class TemperatureModel
    {
        public double Latitude { get; set; }

        public double Longitude { get; set; }
    }
}
