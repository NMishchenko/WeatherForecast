using WeatherForecast.BLL.Models.WeatherReport;

namespace WeatherForecast.BLL.Services.Interfaces;

public interface IWeatherService
{
    Task<WeatherReportModel> GetCurrentAsync(string latitude, string longitude);
}