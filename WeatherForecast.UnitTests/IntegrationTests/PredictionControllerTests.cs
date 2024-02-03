using Newtonsoft.Json;
using System.Net;
using System.Text;
using WeatherForecast.PL.Models;
using WeatherForecast.PL;
using Microsoft.AspNetCore.Mvc.Testing;

namespace WeatherForecast.UnitTests.IntegrationTests
{
    [TestFixture]
    public class PredictionControllerTests: IDisposable
    {
        private WebApplicationFactory<Startup> _factory;
        private HttpClient _client;

        public PredictionControllerTests()
        {
            _factory = new WebApplicationFactory<Startup>();
            _client = _factory.CreateClient();
        }

        public void Dispose()
        {
            _client.Dispose();
            _factory.Dispose();
        }

        [Test]
        public async Task FullPredict_Returns_OK()
        {
            var latitude = 40.7128;
            var longitude = 74.006;
            var days = 7;
            var url = $"/api/predictions/full?Latitude={latitude}&Longitude={longitude}&Days={days}";

            var response = await _client.GetAsync(url);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public async Task PredictWeatherCode_Returns_OK()
        {
            var latitude = 40.7128;
            var longitude = 74.006;
            var days = 7;
            var url = $"/api/predictions/weather-code?Latitude={latitude}&Longitude={longitude}&Days={days}";

            var response = await _client.GetAsync(url);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public async Task PredictMaxTemperature_Returns_OK()
        {
            var latitude = 40.7128;
            var longitude = 74.006;
            var days = 7;
            var url = $"/api/predictions/max-temperature?Latitude={latitude}&Longitude={longitude}&Days={days}";

            var response = await _client.GetAsync(url);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public async Task PredictMinTemperature_Returns_OK()
        {
            var latitude = 40.7128;
            var longitude = 74.006;
            var days = 7;
            var url = $"/api/predictions/min-temperature?Latitude={latitude}&Longitude={longitude}&Days={days}";

            var response = await _client.GetAsync(url);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public async Task PredictPrecipitationSum_Returns_OK()
        {
            var latitude = 40.7128;
            var longitude = 74.006;
            var days = 7;
            var url = $"/api/predictions/precipitation-sum?Latitude={latitude}&Longitude={longitude}&Days={days}";

            var response = await _client.GetAsync(url);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public async Task PredictRainSum_Returns_OK()
        {
            var latitude = 40.7128;
            var longitude = 74.006;
            var days = 7;
            var url = $"/api/predictions/rain-sum?Latitude={latitude}&Longitude={longitude}&Days={days}";

            var response = await _client.GetAsync(url);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public async Task PredictMaxWindSpeed_Returns_OK()
        {
            var latitude = 40.7128;
            var longitude = 74.006;
            var days = 7;
            var url = $"/api/predictions/max-wind-speed?Latitude={latitude}&Longitude={longitude}&Days={days}";

            var response = await _client.GetAsync(url);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
    }
}
