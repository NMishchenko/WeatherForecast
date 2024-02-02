import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {WeatherDataModel, WeatherReportModel} from "../../models/models";

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private httpClient: HttpClient) { }
  API_URL = 'https://localhost:7071/api';

  getCurrentWeather(latitude: string, longitude: string): Observable<WeatherReportModel> {
    return this.httpClient.get<WeatherReportModel>(
      `${this.API_URL}/weather/current?latitude=${latitude}&longitude=${longitude}`);
  }

  getFullPrediction(latitude: string, longitude: string, days: number): Observable<WeatherDataModel> {
    return this.httpClient.get<WeatherDataModel>(
      `${this.API_URL}/predictions/full?latitude=${latitude}&longitude=${longitude}&days=${days}`);
  }
}
