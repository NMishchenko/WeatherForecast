using Newtonsoft.Json;

namespace WeatherForecast.BLL.Models;

public class ForecastModel
{
    [JsonProperty("forecast")]
    public float[]? Forecast { get; set; }
}