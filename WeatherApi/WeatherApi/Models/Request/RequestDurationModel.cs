namespace WeatherApi.Models.Request
{
    public class RequestDurationModel : TemperatureModel
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
