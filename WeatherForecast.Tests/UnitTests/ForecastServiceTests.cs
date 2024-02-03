using FluentAssertions;
using Microsoft.ML;
using Moq;
using NUnit.Framework;
using WeatherForecast.BLL.Services;
using WeatherForecast.Tests.Utility;

namespace WeatherForecast.Tests.UnitTests;

[TestFixture]
public class ForecastServiceTests
{
    private ForecastService _forecastService;
    private Mock<MLContext> _mlContextMock;

    [SetUp]
    public void SetUp()
    {
        _mlContextMock = new Mock<MLContext>();
        _forecastService = new ForecastService(_mlContextMock.Object);
    }
    
    [Test]
    public void ForecastWeatherCode_Returns_ForecastModel()
    {
        var weatherData = new WeatherDataModelBuilder().Build(100).ToList();
        var horizon = 10;

        var result = _forecastService.ForecastWeatherCode(weatherData, horizon);

        result.Should().NotBeNull();
    }

}