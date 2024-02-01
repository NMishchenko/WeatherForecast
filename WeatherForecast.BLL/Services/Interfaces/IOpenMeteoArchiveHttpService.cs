using WeatherForecast.BLL.Models;

namespace WeatherForecast.BLL.Services.Interfaces;

public interface IOpenMeteoArchiveService
{
    Task<List<WeatherDataModel>> GetWeatherDataAsync(
        string latitude,
        string longitude,
        OpenMeteoQueryParamsModel? openMeteoQueryParams = default);
}