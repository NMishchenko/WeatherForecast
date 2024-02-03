using Microsoft.ML;
using Microsoft.ML.Transforms.TimeSeries;
using WeatherForecast.BLL.Models;
using WeatherForecast.BLL.Services.Interfaces;

namespace WeatherForecast.BLL.Services;

public class ForecastService: IForecastService
{
    private readonly MLContext _mlContext;

    public ForecastService(MLContext mlContext)
    {
        _mlContext = mlContext;
    }
    
    public ForecastModel ForecastWeatherCode(IList<WeatherDataModel> weatherData, int horizon)
    {
        return ForecastVariable(weatherData, nameof(WeatherDataModel.WeatherCode), horizon);
    }

    public ForecastModel ForecastMaxTemperature(IList<WeatherDataModel> weatherData, int horizon)
    {
        return ForecastVariable(weatherData, nameof(WeatherDataModel.MaxTemperature), horizon);
    }

    public ForecastModel ForecastMinTemperature(IList<WeatherDataModel> weatherData, int horizon)
    {
        return ForecastVariable(weatherData, nameof(WeatherDataModel.MinTemperature), horizon);
    }

    public ForecastModel ForecastPrecipitationSum(IList<WeatherDataModel> weatherData, int horizon)
    {
        return ForecastVariable(weatherData, nameof(WeatherDataModel.PrecipitationSum), horizon);
    }
    
    public ForecastModel ForecastRainSum(IList<WeatherDataModel> weatherData, int horizon)
    {
        return ForecastVariable(weatherData, nameof(WeatherDataModel.RainSum), horizon);
    }
    
    public ForecastModel ForecastMaxWindSpeed(IList<WeatherDataModel> weatherData, int horizon)
    {
        return ForecastVariable(weatherData, nameof(WeatherDataModel.MaxWindSpeed), horizon);
    }
    
    private ForecastModel ForecastVariable(
        ICollection<WeatherDataModel> weatherData, 
        string inputColumnName, 
        int horizon)
    {
        var dataView = _mlContext.Data.LoadFromEnumerable(weatherData);

        var forecastEstimator = _mlContext.Forecasting.ForecastBySsa(
            outputColumnName: nameof(ForecastModel.Forecast),
            inputColumnName: inputColumnName,
            windowSize: 365,
            seriesLength: weatherData.Count,
            trainSize: weatherData.Count - 365,
            horizon: horizon);

        var forecastTransformer = forecastEstimator.Fit(dataView);

        var forecastEngine = forecastTransformer.CreateTimeSeriesEngine<WeatherDataModel, ForecastModel>(_mlContext);

        var forecast = forecastEngine.Predict();

        return forecast;
    }
}