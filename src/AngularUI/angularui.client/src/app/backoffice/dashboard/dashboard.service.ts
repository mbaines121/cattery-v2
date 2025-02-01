import { HttpClient } from "@angular/common/http";
import { inject, Injectable, signal } from "@angular/core";
import { Observable, throwError } from "rxjs";
import { catchError, map, tap } from "rxjs/operators";

export interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}

@Injectable({
  providedIn: 'root',
})
export class DashboardService {
  private httpClient = inject(HttpClient);

  private weatherforecasts = signal<WeatherForecast[]>([]);

  public loadedWeatherforecasts = this.weatherforecasts.asReadonly();

  getDashboardTiles(): Observable<WeatherForecast[]> {
    return this.httpClient
      .get<WeatherForecast[]>('/weatherforecast')
      .pipe(
        tap({
          next: weatherforecasts => this.weatherforecasts.set(weatherforecasts)
        }),
        catchError((error) => { 
          console.log(error);
          return throwError(() => new Error('Unable to get dashboard tiles.'))
        })
      );
  }
}