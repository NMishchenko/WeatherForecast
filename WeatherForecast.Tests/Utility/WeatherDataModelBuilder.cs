using Bogus;
using WeatherForecast.BLL.Models;

namespace WeatherForecast.Tests.Utility;

public class WeatherDataModelBuilder
{
    private readonly Faker<WeatherDataModel> _faker;

    public WeatherDataModelBuilder()
    {
        _faker = new Faker<WeatherDataModel>()
            .RuleFor(d => d.Latitude, f => f.Address.Latitude())
            .RuleFor(d => d.Longitude, f => f.Address.Longitude())
            .RuleFor(d => d.Time, f => f.Date.RecentOffset(days: 10))
            .RuleFor(d => d.WeatherCode, f => f.Random.Float(0, 100))
            .RuleFor(d => d.MaxTemperature, f => f.Random.Float(-20, 40))
            .RuleFor(d => d.MinTemperature, (f, d) => f.Random.Float(d.MaxTemperature - 10, d.MaxTemperature))
            .RuleFor(d => d.PrecipitationSum, f => f.Random.Float(0, 50))
            .RuleFor(d => d.RainSum, f => f.Random.Float(0, 30))
            .RuleFor(d => d.MaxWindSpeed, f => f.Random.Float(0, 100));
    }

    public WeatherDataModel Build()
    {
        return _faker
            .Generate();
    }

    public IEnumerable<WeatherDataModel> Build(int count)
    {
        return _faker
            .Generate(count);
    }
}