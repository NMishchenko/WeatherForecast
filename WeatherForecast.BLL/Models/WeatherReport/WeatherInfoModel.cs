using Newtonsoft.Json;

namespace WeatherForecast.BLL.Models.WeatherReport;

public class WeatherInfoModel
{
    [JsonProperty("main")] 
    public string? Type { get; set; }
    
    [JsonProperty("description")] 
    public string? Description { get; set; }
}