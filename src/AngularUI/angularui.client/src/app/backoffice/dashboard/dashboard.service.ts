import { HttpClient } from "@angular/common/http";
import { inject, Injectable, signal } from "@angular/core";
import { AuthService } from "@auth0/auth0-angular";
import { Observable, throwError } from "rxjs";
import { catchError, concatMap, flatMap, map, tap } from "rxjs/operators";

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
  private auth = inject(AuthService);
  metadata = {};

  private weatherforecasts = signal<WeatherForecast[]>([]);

  public loadedWeatherforecasts = this.weatherforecasts.asReadonly();

  getDashboardTiles(): Observable<WeatherForecast[]> {
    return this.auth.user$
      .pipe(
        concatMap((user) =>
          this.httpClient
            .get<WeatherForecast[]>('/api/weatherforecast')
            .pipe(
              tap({
                next: weatherforecasts => {
                  this.weatherforecasts.set(weatherforecasts);
                }
              }),
              catchError(() => throwError(() => new Error('Unable to get dashboard tiles.')))
            )
        ),
        map((user: any) => user.user_metadata),
        tap((meta) => (this.metadata = meta))
      );
  }
}