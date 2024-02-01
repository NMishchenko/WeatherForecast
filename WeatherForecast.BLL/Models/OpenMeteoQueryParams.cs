using Newtonsoft.Json;

namespace WeatherForecast.BLL.Models;

public class OpenMeteoQueryParamsModel
{
    [JsonProperty("startDate")]
    public string? StartDate { get; set; }
        
    [JsonProperty("endDate")]
    public string? EndDate { get; set; }

    [JsonProperty("daily")]
    public ICollection<string>? Daily { get; set; } = new List<string>
    {
        "weather_code", "temperature_2m_max", "temperature_2m_min", "precipitation_sum", "rain_sum",
        "wind_speed_10m_max"
    };
}