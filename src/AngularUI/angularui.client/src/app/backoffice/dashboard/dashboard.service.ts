import { HttpClient } from "@angular/common/http";
import { inject, Injectable } from "@angular/core";
import { Observable, throwError } from "rxjs";
import { catchError, map } from "rxjs/operators";

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

  getDashboardTiles(): Observable<WeatherForecast[]> {
    return this.httpClient
      .get<WeatherForecast[]>('/weatherforecast')
      .pipe(
        catchError((error) => { 
          console.log(error);
          return throwError(() => new Error('An error has occurred.')) 
        })
      );
  }
}