# Weather Forecast by Modern Crusaders

![Main page](https://i.ibb.co/WsBcWrk/Screenshot-2024-02-02-235817.png "Main page")

Weather Forecast is an application that allows users to watch the current weather conditions and the forecast with the help of the interactive weather map. his project utilizes the Microsoft.ML library to perform time series forecasting for weather data. It predicts future max/min temperature, wind speed, precipitation sum, rain sum based on historical daily weather data via open APIs. The forecasting algorithm employed is Singular Spectrum Analysis (SSA).
It uses Microsoft ASP.NET Core platform for API and Angular framework for UI. The Docker containerization facilitates the deployment of the server and Web UI seamlessly, requiring minimal prerequisites.

## Run localy
1. Clone the repository:
```cmd
git clone https://github.com/NMishchenko/WeatherForecast.git
```
2. Open the folder with docker-compose.yaml file:
```cmd
cd *insert path to docker-compose.yaml here*
```
3. Start the docker containers:
```cmd
docker-compose up
```
4. Open http://localhost:8080 in a browser to access the UI.

`Open http://localhost:7070/swagger to access the application API`

### Open Source APIs use
1. [Open Weather Historical Weather API](https://open-meteo.com/en/docs/historical-weather-api/ "Open Weather Historical Weather API")
2. [OpenWeatherMap Current Weather API](https://openweathermap.org/current "OpenWeatherMap Current Weather API")
3. [MapBox API](https://docs.mapbox.com/api/overview/ "MapBox API")