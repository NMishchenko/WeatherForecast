namespace WeatherForecast.BLL.Extensions;

public static class DecimalExtension
{
    public static decimal KelvinToCelsius(this decimal val)
    {
        return val - 273;
    }
}