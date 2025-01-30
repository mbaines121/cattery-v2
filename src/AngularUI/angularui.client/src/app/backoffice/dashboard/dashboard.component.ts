import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Component, DestroyRef, inject, OnInit, signal } from '@angular/core';
import { AuthService } from '@auth0/auth0-angular';
import { DashboardService, WeatherForecast } from './dashboard.service';

@Component({
  selector: 'app-dashboard',
  imports: [CommonModule],
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.css'
})
export class DashboardComponent implements OnInit {
  auth = inject(AuthService);

  weatherForecasts = signal<WeatherForecast[] | undefined>(undefined);
  isFetching = signal(false);
  error = signal('');

  private destroyRef = inject(DestroyRef);
  private dashboardService = inject(DashboardService);

  ngOnInit(): void {
    this.isFetching.set(true);
    const subscription = this.dashboardService.getDashboardTiles()
      .subscribe({
        next: weatherforecast => {
          console.log(weatherforecast);
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
