using System.Collections.Specialized;
using Newtonsoft.Json.Linq;
using WeatherForecast.PL.ML;

namespace WeatherForecast.PL;

public class OpenMeteoArchiveHttpClient: IOpenMeteoArchiveHttpService
{
    private readonly HttpClient _httpClient;

    public OpenMeteoArchiveHttpClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("https://archive-api.open-meteo.com/v1/archive");
    }

    public async Task<List<WeatherData>> GetWeatherDataAsync(
        string latitude,
        string longitude,
        string startDate = "2023-01-28",
        string endDate = "2024-01-28",
        string hourly = "temperature_2m,relative_humidity_2m,wind_speed_10m")
    {
        var queryParams = new NameValueCollection
        {
            { "latitude", latitude },
            { "longitude", longitude },
            { "start_date", startDate },
            { "end_date", endDate },
            { "hourly", hourly }
        };
        
        var response = await _httpClient.GetAsync(ToQueryString(queryParams));
        response.EnsureSuccessStatusCode();

        var weatherDataString = await response.Content.ReadAsStringAsync();

        var jsonObject = JObject.Parse(weatherDataString);
        var hourlyTimeData = (JArray)jsonObject["hourly"]?["time"];
        var temperatureData = (JArray)jsonObject["hourly"]["temperature_2m"];
        var humidityData = (JArray)jsonObject["hourly"]["relative_humidity_2m"];
        var windSpeedData = (JArray)jsonObject["hourly"]["wind_speed_10m"];

        var weatherDataList = new List<WeatherData>();

        for (var i = 0; i < hourlyTimeData.Count; i++)
        {
            var weatherData = new WeatherData
            {
                Latitude = Convert.ToSingle(latitude),
                Longitude = Convert.ToSingle(longitude),
                Time = DateTime.Parse(hourlyTimeData[i].ToString()),
                Temperature2M = Convert.ToSingle(temperatureData?[i].ToString()),
                Humidity2M = Convert.ToSingle(humidityData?[i].ToString()),
                WindSpeed10M = Convert.ToSingle(windSpeedData?[i].ToString())
            };

            weatherDataList.Add(weatherData);
        }

        return weatherDataList;
    }

    private static string ToQueryString(NameValueCollection nvc)
    {
        return "?" + string.Join("&", Array.ConvertAll(nvc.AllKeys, key => $"{Uri.EscapeDataString(key)}={Uri.EscapeDataString(nvc[key])}"));
    }
}