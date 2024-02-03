using FluentAssertions;
using Microsoft.ML;
using WeatherForecast.BLL.Services;
using WeatherForecast.Tests.Utility;

namespace WeatherForecast.Tests.UnitTests;

[TestFixture]
public class ForecastServiceTests
{
    private ForecastService _forecastService;

    [SetUp]
    public void SetUp()
    {
        _forecastService = new ForecastService(new MLContext());
    }
    
    [TestCase(40.7128f, 74.0060f, 10)]
    [TestCase(51.5072f, 0.1276f, 5)]
    [TestCase(50.4504f, 30.5245f, 7)]
    public void ForecastWeatherCode_Returns_ForecastModel(float lat, float lon, int horizon)
    {
        var weatherData = new WeatherDataModelBuilder().Build(100).ToList();
        foreach (var weather in weatherData)
        {
            weather.Latitude = lat;
            weather.Longitude = lon;
        }

        var result = _forecastService.ForecastWeatherCode(weatherData, horizon);

        result.Should().NotBeNull();
        result.Forecast.Should().NotBeNull();
        result.Forecast?.Count().Should().Be(horizon);
    }

    [TestCase(40.7128f, 74.0060f, 10)]
    [TestCase(51.5072f, 0.1276f, 5)]
    [TestCase(50.4504f, 30.5245f, 7)]
    public void ForecastMaxTemperature_Returns_ForecastModel(float lat, float lon, int horizon)
    {
        var weatherData = new WeatherDataModelBuilder().Build(100).ToList();
        foreach (var weather in weatherData)
        {
            weather.Latitude = lat;
            weather.Longitude = lon;
        }

        var result = _forecastService.ForecastMaxTemperature(weatherData, horizon);

        result.Should().NotBeNull();
        result.Forecast.Should().NotBeNull();
        result.Forecast?.Count().Should().Be(horizon);
    }

    [TestCase(40.7128f, 74.0060f, 10)]
    [TestCase(51.5072f, 0.1276f, 5)]
    [TestCase(50.4504f, 30.5245f, 7)]
    public void ForecastMinTemperature_Returns_ForecastModel(float lat, float lon, int horizon)
    {
        var weatherData = new WeatherDataModelBuilder().Build(100).ToList();
        foreach (var weather in weatherData)
        {
            weather.Latitude = lat;
            weather.Longitude = lon;
        }

        var result = _forecastService.ForecastMinTemperature(weatherData, horizon);

        result.Should().NotBeNull();
        result.Forecast.Should().NotBeNull();
        result.Forecast?.Count().Should().Be(horizon);
    }

    [TestCase(40.7128f, 74.0060f, 10)]
    [TestCase(51.5072f, 0.1276f, 5)]
    [TestCase(50.4504f, 30.5245f, 7)]
    public void ForecastPrecipitationSum_Returns_ForecastModel(float lat, float lon, int horizon)
    {
        var weatherData = new WeatherDataModelBuilder().Build(100).ToList();
        foreach (var weather in weatherData)
        {
            weather.Latitude = lat;
            weather.Longitude = lon;
        }

        var result = _forecastService.ForecastPrecipitationSum(weatherData, horizon);

        result.Should().NotBeNull();
        result.Forecast.Should().NotBeNull();
        result.Forecast?.Count().Should().Be(horizon);
    }

    [TestCase(40.7128f, 74.0060f, 10)]
    [TestCase(51.5072f, 0.1276f, 5)]
    [TestCase(50.4504f, 30.5245f, 7)]
    public void ForecastRainSum_Returns_ForecastModel(float lat, float lon, int horizon)
    {
        var weatherData = new WeatherDataModelBuilder().Build(100).ToList();
        foreach (var weather in weatherData)
        {
            weather.Latitude = lat;
            weather.Longitude = lon;
        }

        var result = _forecastService.ForecastRainSum(weatherData, horizon);

        result.Should().NotBeNull();
        result.Forecast.Should().NotBeNull();
        result.Forecast?.Count().Should().Be(horizon);
    }

    [TestCase(40.7128f, 74.0060f, 10)]
    [TestCase(51.5072f, 0.1276f, 5)]
    [TestCase(50.4504f, 30.5245f, 7)]
    public void ForecastMaxWindSpeed_Returns_ForecastModel(float lat, float lon, int horizon)
    {
        var weatherData = new WeatherDataModelBuilder().Build(100).ToList();
        foreach (var weather in weatherData)
        {
            weather.Latitude = lat;
            weather.Longitude = lon;
        }

        var result = _forecastService.ForecastMaxWindSpeed(weatherData, horizon);

        result.Should().NotBeNull();
        result.Forecast.Should().NotBeNull();
        result.Forecast?.Count().Should().Be(horizon);
    }
}