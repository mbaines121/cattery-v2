import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { MatCardModule } from '@angular/material/card';
import { LoginButtonComponent } from "../../shared/login-button/login-button.component";
import { RegisterButtonComponent } from '../../shared/register-button/register-button.component';

@Component({
  selector: 'app-landing-layout',
  imports: [
    RouterOutlet, 
    MatCardModule, 
    LoginButtonComponent, 
    RegisterButtonComponent
  ],
  templateUrl: './landing-layout.component.html',
  styleUrl: './landing-layout.component.css'
})
export class LandingLayoutComponent {

  showMobileNav = false;

  toggleMobileNav() {
    this.showMobileNav = !this.showMobileNav;
  }

  hideMobileNav() {
    this.showMobileNav = false;
  }
}
