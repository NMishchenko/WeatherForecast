using Newtonsoft.Json;

namespace WeatherForecast.BLL.Models;

public class WeatherDataListModel
{
    [JsonProperty("daily")]
    public WeatherDataListItemModel? Daily { get; set; }
}

public class WeatherDataListItemModel
{
    [JsonProperty("time")]
    public IList<string>? TimeUnits { get; set; }

    [JsonProperty("weather_code")]
    public IList<int?>? WeatherCodeUnits { get; set; }
    
    [JsonProperty("temperature_2m_max")]
    public IList<float?>? MaxTemperatureUnits { get; set; }
    
    [JsonProperty("temperature_2m_min")]
    public IList<float?>? MinTemperatureUnits { get; set; }

    [JsonProperty("precipitation_sum")]
    public IList<float?>? PrecipitationSumUnits { get; set; }
    
    [JsonProperty("rain_sum")]
    public IList<float?>? RainSumUnits { get; set; }
    
    [JsonProperty("wind_speed_10m_max")]
    public IList<float?>? MaxWindSpeedUnits { get; set; }
}