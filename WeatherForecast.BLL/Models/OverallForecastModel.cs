using Newtonsoft.Json;

namespace WeatherForecast.BLL.Models;

public class FullForecastModel
{
    [JsonProperty("weather_code")]
    public ICollection<float>? WeatherCode { get; set; }
    
    [JsonProperty("temperature_max")]
    public ICollection<float>? MaxTemperature { get; set; }
    
    [JsonProperty("temperature_min")]
    public ICollection<float>? MinTemperature { get; set; }

    [JsonProperty("precipitation_sum")]
    public ICollection<float>? PrecipitationSum { get; set; }
    
    [JsonProperty("rain_sum")]
    public ICollection<float>? RainSum { get; set; }
    
    [JsonProperty("wind_speed_max")]
    public ICollection<float>? MaxWindSpeed { get; set; }
}