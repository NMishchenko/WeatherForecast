export interface WeatherDataModel {
  weatherCode: number[];
  maxTemperature: number[];
  minTemperature: number[];
  precipitationSum: number[];
  rainSum: number[];
  maxWindSpeed: number[];
}

export interface WindInfoModel {
  speed: number;
}

export interface MainWeatherInfoModel {
  temperature: number;
  humidity: number;
}

export interface WeatherInfoModel {
  type: string;
  description: string;
}

export interface WeatherReportModel {
  weather: WeatherInfoModel[];
  main: MainWeatherInfoModel;
  wind: WindInfoModel;
}
