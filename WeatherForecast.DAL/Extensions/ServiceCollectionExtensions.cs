using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WeatherForecast.DAL.Extensions;

public static class ServiceCollectionExtensions
{
    const string WeatherForecast = "WeatherForecast";

    public static IServiceCollection AddDataAccessLayerServices(this IServiceCollection services, IConfiguration configuration)
    {
        AddDbContext(services, configuration);
        AddRepositories(services);

        return services;
    }

    private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<WeatherForecastContext>(
            options => options.UseSqlServer(configuration.GetConnectionString(WeatherForecast)));
    }

    private static void AddRepositories(IServiceCollection services)
    {
        // services.AddScoped<ISomeEntityRepository, SomeEntityRepository>();
    }
}