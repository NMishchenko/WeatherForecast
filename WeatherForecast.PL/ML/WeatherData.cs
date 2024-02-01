namespace WeatherForecast.PL.ML
{
    public class WeatherData
    {
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public DateTime Time { get; set; }
        public float Temperature2M { get; set; }
        public float Humidity2M { get; set; }
        public float WindSpeed10M { get; set; }
    }
}
