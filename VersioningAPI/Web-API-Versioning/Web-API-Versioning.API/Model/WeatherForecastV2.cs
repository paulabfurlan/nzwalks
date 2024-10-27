namespace Web_API_Versioning.API.Model
{
    public class WeatherForecastV2
    {
        public DateOnly Date { get; set; }

        public int TemperatureCelsius { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureCelsius / 0.5556);

        public string? Summary { get; set; }
    }
}
