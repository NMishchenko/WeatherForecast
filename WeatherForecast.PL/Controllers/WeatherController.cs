using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using WeatherForecast.BLL.Services.Interfaces;

namespace WeatherForecast.PL.Controllers
{
    [ApiController]
    [Route("api/weather")]
    public class WeatherController: ControllerBase
    {
        private readonly IWeatherService _weatherService;

        public WeatherController(
            IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        [HttpGet("current")]
        public async Task<IActionResult> PredictTemperature(
            [BindRequired] string latitude,
            [BindRequired] string longitude)
        {
            var weatherData = await _weatherService.GetCurrentAsync(latitude, longitude);
            return Ok(weatherData);
        }
    }
}
