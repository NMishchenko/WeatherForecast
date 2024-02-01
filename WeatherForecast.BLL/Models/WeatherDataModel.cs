using Newtonsoft.Json;

namespace WeatherForecast.BLL.Models;

public class WeatherDataModel
{
    [JsonProperty("latitude")]
    public float Latitude { get; set; }
    
    [JsonProperty("longitude")]
    public float Longitude { get; set; }
    
    [JsonProperty("time")]
    public DateTime Time { get; set; }

    [JsonProperty("weather_code")]
    public float WeatherCode { get; set; }
    
    [JsonProperty("temperature_max")]
    public float MaxTemperature { get; set; }
    
    [JsonProperty("temperature_min")]
    public float MinTemperature { get; set; }

    [JsonProperty("precipitation_sum")]
    public float PrecipitationSum { get; set; }
    
    [JsonProperty("rain_sum")]
    public float RainSum { get; set; }
    
    [JsonProperty("wind_speed_max")]
    public float MaxWindSpeed { get; set; }
}