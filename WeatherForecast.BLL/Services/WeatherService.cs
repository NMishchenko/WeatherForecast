using Flurl;
using Flurl.Http;
using Microsoft.Extensions.Configuration;
using WeatherForecast.BLL.Extensions;
using WeatherForecast.BLL.Models.WeatherReport;
using WeatherForecast.BLL.Services.Interfaces;

namespace WeatherForecast.BLL.Services;

public class WeatherService : IWeatherService
{
    private readonly IConfiguration _configuration;

    public WeatherService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<WeatherReportModel> GetCurrentAsync(string latitude, string longitude)
    {
        var apiKey = _configuration.GetSection("OpenWeatherApiKey").Value;
        var response = await "https://api.openweathermap.org/data/2.5/weather"
            .SetQueryParams(new
            {
                lat = latitude,
                lon = longitude,
                appid = apiKey
            })
            .GetJsonAsync<WeatherReportModel>();
        response.Main.Temperature = response.Main.Temperature.KelvinToCelsius();

        return response;
    }
}