using WeatherForecast.BLL.Models;

namespace WeatherForecast.BLL.Services.Interfaces;

public interface IForecastService
{
    ForecastModel ForecastWeatherCode(IList<WeatherDataModel> weatherData, int horizon);
    ForecastModel ForecastMaxTemperature(IList<WeatherDataModel> weatherData, int horizon);
    ForecastModel ForecastMinTemperature(IList<WeatherDataModel> weatherData, int horizon);
    ForecastModel ForecastPrecipitationSum(IList<WeatherDataModel> weatherData, int horizon);
    ForecastModel ForecastRainSum(IList<WeatherDataModel> weatherData, int horizon);
    ForecastModel ForecastMaxWindSpeed(IList<WeatherDataModel> weatherData, int horizon);
}