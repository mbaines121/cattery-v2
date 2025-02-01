import { Component, inject } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { Router } from '@angular/router';
import { MatTooltipModule } from '@angular/material/tooltip';

@Component({
  selector: 'app-account-button',
  imports: [MatButtonModule, MatIconModule, MatTooltipModule],
  templateUrl: './account-button.component.html',
  styleUrl: './account-button.component.css'
})
export class AccountButtonComponent {
  private router = inject(Router);

  account(): void {
     this.router.navigate(['/app/profile']);
  }
}
