using Flurl.Http;
using Flurl.Http.Newtonsoft;

namespace WeatherForecast.PL;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var startup = new Startup(builder.Configuration);
        startup.ConfigureServices(builder.Services);
        FlurlHttp.Clients.WithDefaults(b =>
            b.WithSettings(settings =>
            {
                settings.JsonSerializer = new NewtonsoftJsonSerializer();
            }));

        var app = builder.Build();
        startup.Configure(app, builder.Environment);

        // TODO: Do we need this? Auto applying the last migration, for this moment it doesn't work
        // using (var scope = app.Services.CreateScope())
        // {
        //     var context = scope.ServiceProvider.GetRequiredService<WeatherForecastContext>();
        //     await context.Database.MigrateAsync();
        // }

        await app.RunAsync();
    }
}
