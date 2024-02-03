using Microsoft.AspNetCore.Mvc;
using WeatherForecast.BLL.Models;
using WeatherForecast.BLL.Services.Interfaces;
using WeatherForecast.PL.Models;

namespace WeatherForecast.PL.Controllers
{
    [ApiController]
    [Route("api/predictions")]
    public class PredictionsController: ControllerBase
    {
        private readonly IOpenMeteoArchiveService _openMeteoArchiveService;
        private readonly IForecastService _forecastService;

        public PredictionsController(
            IOpenMeteoArchiveService openMeteoArchiveService, 
            IForecastService forecastService)
        {
            _openMeteoArchiveService = openMeteoArchiveService;
            _forecastService = forecastService;
        }

        [HttpGet("full")]
        public async Task<IActionResult> FullPredict(
            [FromQuery]PredictionRequest predictionRequest)
        {
            var weatherData = await _openMeteoArchiveService.GetWeatherDataAsync(predictionRequest.Latitude, predictionRequest.Longitude);
            return Ok(new FullForecastModel
            {
                WeatherCode = _forecastService.ForecastWeatherCode(weatherData, predictionRequest.Days).Forecast,
                MaxTemperature = _forecastService.ForecastMaxTemperature(weatherData, predictionRequest.Days).Forecast,
                MinTemperature = _forecastService.ForecastMinTemperature(weatherData, predictionRequest.Days).Forecast,
                PrecipitationSum = _forecastService.ForecastPrecipitationSum(weatherData, predictionRequest.Days).Forecast,
                RainSum = _forecastService.ForecastRainSum(weatherData, predictionRequest.Days).Forecast,
                MaxWindSpeed = _forecastService.ForecastMaxWindSpeed(weatherData, predictionRequest.Days).Forecast
            });
        }
        
        [HttpGet("weather-code")]
        public async Task<IActionResult> PredictWeatherCode(
            [FromQuery]PredictionRequest predictionRequest)
        {
            var weatherData = await _openMeteoArchiveService.GetWeatherDataAsync(predictionRequest.Latitude, predictionRequest.Longitude);
            return Ok(_forecastService.ForecastWeatherCode(weatherData, predictionRequest.Days));
        }

        [HttpGet("max-temperature")]
        public async Task<IActionResult> PredictMaxTemperature(
            [FromQuery]PredictionRequest predictionRequest)
        {
            var weatherData = await _openMeteoArchiveService.GetWeatherDataAsync(predictionRequest.Latitude, predictionRequest.Longitude);
            return Ok(_forecastService.ForecastMaxTemperature(weatherData, predictionRequest.Days));
        }
        
        [HttpGet("min-temperature")]
        public async Task<IActionResult> PredictMinTemperature(
            [FromQuery]PredictionRequest predictionRequest)
        {
            var weatherData = await _openMeteoArchiveService.GetWeatherDataAsync(predictionRequest.Latitude, predictionRequest.Longitude);
            return Ok(_forecastService.ForecastMinTemperature(weatherData, predictionRequest.Days));
        }
        
        [HttpGet("precipitation-sum")]
        public async Task<IActionResult> PredictPrecipitationSum(
            [FromQuery]PredictionRequest predictionRequest)
        {
            var weatherData = await _openMeteoArchiveService.GetWeatherDataAsync(predictionRequest.Latitude, predictionRequest.Longitude);
            return Ok(_forecastService.ForecastPrecipitationSum(weatherData, predictionRequest.Days));
        }
        
        [HttpGet("rain-sum")]
        public async Task<IActionResult> PredictRainSum(
            [FromQuery]PredictionRequest predictionRequest)
        {
            var weatherData = await _openMeteoArchiveService.GetWeatherDataAsync(predictionRequest.Latitude, predictionRequest.Longitude);
            return Ok(_forecastService.ForecastRainSum(weatherData, predictionRequest.Days));
        }
        
        [HttpGet("max-wind-speed")]
        public async Task<IActionResult> PredictMaxWindSpeed(
            [FromQuery]PredictionRequest predictionRequest)
        {
            var weatherData = await _openMeteoArchiveService.GetWeatherDataAsync(predictionRequest.Latitude, predictionRequest.Longitude);
            return Ok(_forecastService.ForecastMaxWindSpeed(weatherData, predictionRequest.Days));
        }
    }
}
