using Newtonsoft.Json;

namespace WeatherForecast.BLL.Models.WeatherReport;

public class WeatherReportModel
{
    [JsonProperty("weather")]
    public ICollection<WeatherInfoModel> Weather { get; set; } = new List<WeatherInfoModel>();
    
    [JsonProperty("main")]
    public MainWeatherInfoModel Main { get; set; } = new();
    
    [JsonProperty("wind")]
    public WindInfoModel Wind { get; set; } = new();
}