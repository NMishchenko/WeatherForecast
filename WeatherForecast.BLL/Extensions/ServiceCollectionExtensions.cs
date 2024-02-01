using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using WeatherForecast.BLL.Services;
using WeatherForecast.BLL.Services.Interfaces;

namespace WeatherForecast.BLL.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddBusinessLogicLayerServices(this IServiceCollection services)
    {
        AddMapper(services);
        AddValidators(services);
        AddServices(services);

        return services;
    }

    private static void AddMapper(IServiceCollection services)
    {
        var mappingConfig = new MapperConfiguration(mc =>
        {
            // mc.AddProfile(new SomeEntityMappingProfile());
        });

        services.AddSingleton(mappingConfig.CreateMapper());
    }

    private static void AddServices(IServiceCollection services)
    {
        services.AddScoped<IWeatherService, WeatherService>();
        services.AddScoped<IForecastService, ForecastService>();
        services.AddScoped<IOpenMeteoArchiveService, OpenMeteoArchiveService>();
    }

    private static void AddValidators(IServiceCollection services)
    {
        // services.AddScoped<IValidator<SomeModel>, SomeModelValidator>();
    }
}