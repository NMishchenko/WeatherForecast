import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { ApiService } from './api/api.service';
import { WeatherDataModel, WeatherReportModel } from '../models/models';
import { CommonModule, formatDate } from '@angular/common';
import * as mapboxgl from 'mapbox-gl';

@Component({
    selector: 'app-root',
    standalone: true,
    templateUrl: './app.component.html',
    styleUrl: './app.component.scss',
    imports: [CommonModule, RouterOutlet]
})
export class AppComponent {
  title = 'WeatherForecast.UI';
  reportModel!: WeatherReportModel;
  predictionModel!: WeatherDataModel;
  currentDate!: string;

  map!: mapboxgl.Map;
  marker: any;
  style = 'mapbox://styles/mapbox/streets-v11';
  location: string = "Дніпро, Dnipropetrovsk Oblast, Ukraine";

  constructor(
    private api: ApiService,
  ) {}

  ngOnInit() : void {
    this.api.getCurrentWeather("48.4666", "35.0407").subscribe(model => this.reportModel = model);
    this.api.getFullPrediction("48.4666", "35.0407", 7).subscribe(model => this.predictionModel = model);
    this.currentDate = this.getDate(Date.now());

    mapboxgl as typeof mapboxgl;
    this.map = new mapboxgl.Map({
      accessToken:
        'pk.eyJ1Ijoib2F0YW1hbmNodWsiLCJhIjoiY2xnN3k1ODU2MHM3NjNnbzkzMnJ5amFrOSJ9.fUOEKrtONXbZfxQsn4YDlw',
      container: 'map',
      style: this.style,
      zoom: 3,
      center: [-74.5, 40]
    });
    this.marker = new mapboxgl.Marker();

    this.map.addControl(new mapboxgl.NavigationControl());

    this.map.on('click', (event) => {
      this.addMarker(event);
    });
  }

  addMarker(event: mapboxgl.MapMouseEvent & mapboxgl.EventData) {
    const coordinates = event.lngLat;

    this.setCurrentLocation(coordinates);
    this.api.getCurrentWeather(coordinates.lat.toString(), coordinates.lng.toString()).subscribe(model => this.reportModel = model);
    this.api.getFullPrediction(coordinates.lat.toString(), coordinates.lng.toString(), 7).subscribe(model => this.predictionModel = model);
  }

  getWeather(weather: string): string {
    return weather.charAt(0).toUpperCase() + weather.slice(1);
  }

  getRound(num: number, fractionDigits: number): number {
    return Number(num.toFixed(fractionDigits));
  }

  getRoundAbs(num: number, fractionDigits: number): number {
    return Math.abs(this.getRound(num, fractionDigits));
  }

  getMin(num1: number, num2: number): number {
    const result = Math.min(num1, num2);
    return this.getRound(result, 0);
  }

  getMax(num1: number, num2: number): number {
    const result = Math.max(num1, num2);
    return this.getRound(result, 0);
  }

  getRange(n: number): any {
    return Array.from(Array(n).keys());
  }

  getDate(date: Date | number): string {
    return formatDate(date, 'dd.MM.yyyy', 'en-US');
  }

  getNextDate(days: number): string {
    return this.getDate(Date.now() + days * 24 * 60 * 60 * 1000);
  }

  setCurrentLocation(coordinates: any) {
    fetch(`https://api.mapbox.com/geocoding/v5/mapbox.places/${coordinates.lng},${coordinates.lat}.json?access_token=pk.eyJ1Ijoib2F0YW1hbmNodWsiLCJhIjoiY2xnN3k1ODU2MHM3NjNnbzkzMnJ5amFrOSJ9.fUOEKrtONXbZfxQsn4YDlw`)
        .then(response => response.json())
        .then(data => {
            const countryFeature = data.features.find((feature: any) => feature.place_type.includes('country'));
            const cityFeature = data.features.find((feature: any) => feature.place_type.includes('place'));

            let countryName = '';
            let cityName = '';

            if (countryFeature) {
                countryName = countryFeature.place_name;
            }

            if (cityFeature) {
                cityName = cityFeature.place_name;
            }

            if (countryName == "") {
               this.location = "Point location";
            }
            else if (cityName) {
              this.location = cityName;
            }
            else {
              this.location = countryName;
            }
        })
        .catch(error => {
            console.error('Error fetching data:', error);
        });
  }
}
