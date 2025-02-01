import { AsyncPipe, CommonModule } from '@angular/common';
import { Component, DestroyRef, inject, OnInit, signal } from '@angular/core';
import { AuthService } from '@auth0/auth0-angular';
import { DashboardService, WeatherForecast } from './dashboard.service';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatMenuModule } from '@angular/material/menu';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { map } from 'rxjs';

@Component({
  selector: 'app-dashboard',
  imports: [CommonModule,
      AsyncPipe,
      MatGridListModule,
      MatMenuModule,
      MatIconModule,
      MatButtonModule,
      MatCardModule],
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.css'
})
export class DashboardComponent implements OnInit {
  private breakpointObserver = inject(BreakpointObserver);
  
    /** Based on the screen size, switch from standard to one column per row */
    cards = this.breakpointObserver.observe(Breakpoints.Handset).pipe(
      map(({ matches }) => {
        if (matches) {
          return [
            { title: 'Card 1', cols: 1, rows: 1 },
            { title: 'Card 2', cols: 1, rows: 1 },
            { title: 'Card 3', cols: 1, rows: 1 },
            { title: 'Card 4', cols: 1, rows: 1 }
          ];
        }
  
        return [
          { title: 'Card 1', cols: 2, rows: 1 },
          { title: 'Card 2', cols: 1, rows: 1 },
          { title: 'Card 3', cols: 1, rows: 2 },
          { title: 'Card 4', cols: 1, rows: 1 }
        ];
      })
    );


    

  auth = inject(AuthService);

  isFetching = signal(false);
  error = signal('');

  private destroyRef = inject(DestroyRef);
  private dashboardService = inject(DashboardService);

  //weatherForecasts = signal<WeatherForecast[] | undefined>(undefined);
  weatherforecasts = this.dashboardService.loadedWeatherforecasts;

  ngOnInit(): void {
    this.isFetching.set(true);
    const subscription = this.dashboardService.getDashboardTiles()
      .subscribe({
        next: weatherforecast => {
          //console.log(weatherforecast);
          
        },
        error: error => {
          this.error.set(error.message);
        },
        complete: () => {
          this.isFetching.set(false);
        }
      });

      this.destroyRef.onDestroy(() => { subscription.unsubscribe(); });
  }
}
