﻿using Microsoft.Extensions.ML;
using WeatherForecast.BLL.Extensions;
using WeatherForecast.DAL.Extensions;
using WeatherForecast.PL.Extensions;
using WeatherForecast.PL.Middleware;
using WeatherForecast.PL.ML;

namespace WeatherForecast.PL;

public class Startup
{
    const string FrontOriginPolicyName = "WeatherForecastUI";

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers(options =>
            options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);

        services.AddCors(options =>
        {
            options.AddPolicy(FrontOriginPolicyName, policy =>
            {
                // TODO: Add correct IP address of the Angular application
                var ip = Configuration.GetValue<string>("Settings:UIIPAddress");
                policy
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .WithOrigins(ip);
            });       
        });
       
        services.AddEndpointsApiExplorer();
        
        services.AddDataAccessLayerServices(Configuration);
        services.AddBusinessLogicLayerServices();
        services.AddPresentationLayer(Configuration);

        services.AddHttpClient<IOpenMeteoArchiveHttpService, OpenMeteoArchiveHttpClient>();
        services.AddScoped<IForecastService, ForecastService>();
    }

    public void Configure(WebApplication app, IWebHostEnvironment env)
    {
        app.UseCors(FrontOriginPolicyName);
        
        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseMiddleware<ExceptionHandlerMiddleware>();

        app.UseHttpsRedirection();

        app.MapControllers();
    }
}