using Flurl;
using Flurl.Http;
using WeatherForecast.BLL.Models;
using WeatherForecast.BLL.Services.Interfaces;

namespace WeatherForecast.BLL.Services;

public class OpenMeteoArchiveService: IOpenMeteoArchiveService
{
    private const string ApiUrl = "https://archive-api.open-meteo.com/v1/archive";

    public async Task<List<WeatherDataModel>> GetWeatherDataAsync(
        string latitude,
        string longitude,
        OpenMeteoQueryParamsModel? openMeteoQueryParams = default)
    {
        openMeteoQueryParams ??= new OpenMeteoQueryParamsModel
        {
            StartDate = DateTime.UtcNow.AddYears(-3).ToString("yyyy-MM-dd"),
            EndDate = DateTime.UtcNow.AddDays(-1).ToString("yyyy-MM-dd")
        };
        var response = await ApiUrl
            .SetQueryParams(new
            {
                latitude,
                longitude,
                start_date = openMeteoQueryParams.StartDate,
                end_date = openMeteoQueryParams.EndDate,
                daily = openMeteoQueryParams.Daily
            })
            .GetJsonAsync<WeatherDataListModel>();

        var result = new List<WeatherDataModel>();

        for (var i = 0; i < response?.Daily?.TimeUnits?.Count; i++)
        {
            var time = response.Daily.TimeUnits[i];
            var weatherCode = response.Daily?.WeatherCodeUnits?[i];
            var maxTemperature = response?.Daily?.MaxTemperatureUnits?[i];
            var minTemperature = response?.Daily?.MinTemperatureUnits?[i];
            var precipitationSum = response?.Daily?.PrecipitationSumUnits?[i];
            var rainSum = response?.Daily?.RainSumUnits?[i];
            var maxWindSpeed = response?.Daily?.MaxWindSpeedUnits?[i];
            
            var weatherData = new WeatherDataModel
            {
                Latitude = Convert.ToSingle(latitude),
                Longitude = Convert.ToSingle(longitude),
                Time = DateTime.Parse(time),
                WeatherCode = weatherCode ?? 0,
                MaxTemperature = maxTemperature ?? 0,
                MinTemperature = minTemperature ?? 0,
                PrecipitationSum = precipitationSum ?? 0,
                RainSum = rainSum ?? 0,
                MaxWindSpeed = maxWindSpeed ?? 0
            };

            result.Add(weatherData);
        }

        return result;
    }
}