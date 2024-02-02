using Newtonsoft.Json;

namespace WeatherForecast.BLL.Models.WeatherReport;

public class WindInfoModel
{
    [JsonProperty("speed")] 
    public decimal Speed { get; set; }
}