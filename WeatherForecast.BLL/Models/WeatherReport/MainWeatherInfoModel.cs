using Newtonsoft.Json;

namespace WeatherForecast.BLL.Models.WeatherReport;

public class MainWeatherInfoModel
{
    [JsonProperty("temp")] 
    public decimal Temperature { get; set; }
    
    [JsonProperty("humidity")] 
    public decimal Humidity { get; set; }
}