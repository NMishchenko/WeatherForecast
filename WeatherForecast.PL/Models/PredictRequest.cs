using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;

namespace WeatherForecast.PL.Models;

public class PredictionRequest
{
    [BindRequired]
    [JsonProperty("latitude")]
    public string Latitude { get; set; }
    
    [BindRequired]
    [JsonProperty("longitude")]
    public string Longitude { get; set; }

    [BindRequired] 
    [JsonProperty("days")] 
    public int Days { get; set; } = 1;
}