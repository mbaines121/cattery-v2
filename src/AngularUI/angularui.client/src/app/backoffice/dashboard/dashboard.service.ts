import { HttpClient, HttpParams } from "@angular/common/http";
import { inject, Injectable, signal } from "@angular/core";
import { AuthService } from "@auth0/auth0-angular";
import { throwError } from "rxjs";
import { catchError, switchMap, tap } from "rxjs/operators";
import { DashboardItem } from "./dashboard.interface";

@Injectable({
  providedIn: 'root',
})
export class DashboardService {
  private httpClient = inject(HttpClient);
  private auth = inject(AuthService);
  metadata = {};

  private dashboardItems = signal<DashboardItem[]>([]);

  public loadedDashboardItems = this.dashboardItems.asReadonly();

  getDashboardTiles() {
    return this.auth.user$
      .pipe(
        switchMap(user => this.getDashboardTilesHelper(user?.sub ?? ''))
      );
  }

  getDashboardTilesHelper(sub: string) {
    return this.httpClient.get<{ dashboardItems: DashboardItem[] }>('/api/dashboard', { 
      params: new HttpParams().set('sub', sub)
    })
      .pipe(
        tap({
          next: response => { this.dashboardItems.set(response.dashboardItems); }
        }),
        catchError(() => throwError(() => new Error('Unable to get dashboard items.')))
      );
  }
}