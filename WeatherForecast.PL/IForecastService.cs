using WeatherForecast.PL.ML;

namespace WeatherForecast.PL;

public interface IForecastService
{
    ForecastModel ForecastTemperature(IList<WeatherData> weatherData);
    ForecastModel ForecastHumidity(IList<WeatherData> weatherData);
    ForecastModel ForecastWindSpeed(IList<WeatherData> weatherData);
}