using Microsoft.ML;
using Microsoft.ML.Transforms.TimeSeries;
using WeatherForecast.PL.ML;

namespace WeatherForecast.PL;

public class ForecastService: IForecastService
{
    private readonly MLContext _mlContext;

    public ForecastService()
    {
        _mlContext = new MLContext();
    }

    public ForecastModel ForecastTemperature(IList<WeatherData> weatherData)
    {
        return ForecastVariable(weatherData, nameof(WeatherData.Temperature2M));
    }

    public ForecastModel ForecastHumidity(IList<WeatherData> weatherData)
    {
        return ForecastVariable(weatherData, nameof(WeatherData.Humidity2M));
    }

    public ForecastModel ForecastWindSpeed(IList<WeatherData> weatherData)
    {
        return ForecastVariable(weatherData, nameof(WeatherData.WindSpeed10M));
    }
    
    private ForecastModel ForecastVariable(ICollection<WeatherData> weatherData, string inputColumnName)
    {
        var dataView = _mlContext.Data.LoadFromEnumerable(weatherData);

        var forecastEstimator = _mlContext.Forecasting.ForecastBySsa(
            outputColumnName: nameof(ForecastModel.Forecast),
            inputColumnName: inputColumnName,
            windowSize: 24,
            seriesLength: weatherData.Count,
            trainSize: weatherData.Count,
            horizon: 1);

        var forecastTransformer = forecastEstimator.Fit(dataView);

        var forecastEngine = forecastTransformer.CreateTimeSeriesEngine<WeatherData, ForecastModel>(_mlContext);

        var forecast = forecastEngine.Predict();

        return forecast;
    }
}