import { AsyncPipe, CommonModule } from '@angular/common';
import { Component, DestroyRef, inject, OnInit, signal } from '@angular/core';
import { AuthService } from '@auth0/auth0-angular';
import { DashboardService } from './dashboard.service';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatMenuModule } from '@angular/material/menu';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { finalize, retry } from 'rxjs';

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
  public auth = inject(AuthService);
  private destroyRef = inject(DestroyRef);
  private dashboardService = inject(DashboardService);

  isFetching = signal(false);
  error = signal('');

  dashboardItems = this.dashboardService.loadedDashboardItems;

  ngOnInit(): void {
    this.isFetching.set(true);
    const subscription = this.dashboardService.getDashboardTiles()
      .pipe(retry(3))
      .subscribe({
        error: error => {
          this.error.set(error.message);
        },
        next: () => {
          this.isFetching.set(false);
        }
      });

      this.destroyRef.onDestroy(() => { subscription.unsubscribe(); });
  }
}
