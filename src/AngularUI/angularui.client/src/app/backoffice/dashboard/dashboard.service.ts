import { HttpClient, HttpParams } from "@angular/common/http";
import { inject, Injectable, signal } from "@angular/core";
import { AuthService } from "@auth0/auth0-angular";
import { Observable, throwError } from "rxjs";
import { catchError, concatMap, map, tap } from "rxjs/operators";

export interface DashboardItem {
  title: string;
  value: number;
}

@Injectable({
  providedIn: 'root',
})
export class DashboardService {
  private httpClient = inject(HttpClient);
  private auth = inject(AuthService);
  metadata = {};

  private dashboardItems = signal<DashboardItem[]>([]);

  public loadedDashboardItems = this.dashboardItems.asReadonly();

  getDashboardTiles(): Observable<{ dashboardItems: DashboardItem[] }> {
    return this.auth.user$
      .pipe(
        concatMap((user) =>
          this.httpClient.get<{ dashboardItems: DashboardItem[] }>('/api/dashboard', {
              params: new HttpParams().set('userId', user?.sub ?? '')
            })
            .pipe(
              tap({
                next: response => {
                  this.dashboardItems.set(response.dashboardItems);
                }
              }),
              catchError(() => throwError(() => new Error('Unable to get dashboard items.')))
            )
        )
      );
  }
}