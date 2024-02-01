using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace WeatherForecast.PL.Controllers
{
    [ApiController]
    [Route("api/predictions")]
    public class PredictionsController: ControllerBase
    {
        private readonly IOpenMeteoArchiveHttpService _openMeteoArchiveHttpService;
        private readonly IForecastService _forecastService;

        public PredictionsController(
            IOpenMeteoArchiveHttpService openMeteoArchiveHttpService, 
            IForecastService forecastService)
        {
            _openMeteoArchiveHttpService = openMeteoArchiveHttpService;
            _forecastService = forecastService;
        }

        [HttpPost("temperature")]
        public async Task<IActionResult> PredictTemperature(
            [BindRequired] string latitude,
            [BindRequired]string longitude)
        {
            var weatherData = await _openMeteoArchiveHttpService.GetWeatherDataAsync(latitude, longitude);
            return Ok(_forecastService.ForecastTemperature(weatherData));
        }
        
        [HttpPost("humidity")]
        public async Task<IActionResult> PredictHumidity(
            [BindRequired] string latitude,
            [BindRequired]string longitude)
        {
            var weatherData = await _openMeteoArchiveHttpService.GetWeatherDataAsync(latitude, longitude);
            return Ok(_forecastService.ForecastHumidity(weatherData));
        }
        
        [HttpPost("wind-speed")]
        public async Task<IActionResult> PredictWindSpeed(
            [BindRequired] string latitude,
            [BindRequired]string longitude)
        {
            var weatherData = await _openMeteoArchiveHttpService.GetWeatherDataAsync(latitude, longitude);
            return Ok(_forecastService.ForecastWindSpeed(weatherData));
        }
    }
}
