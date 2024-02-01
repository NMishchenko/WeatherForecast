using WeatherForecast.PL.ML;

namespace WeatherForecast.PL;

public interface IOpenMeteoArchiveHttpService
{
    Task<List<WeatherData>> GetWeatherDataAsync(
        string latitude,
        string longitude,
        string startDate = "2023-01-28",
        string endDate = "2024-01-28",
        string hourly = "temperature_2m,relative_humidity_2m,wind_speed_10m");
}