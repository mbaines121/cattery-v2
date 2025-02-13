import { Component, inject, input } from '@angular/core';
import { AuthService } from '@auth0/auth0-angular';

@Component({
  selector: 'app-register-button',
  imports: [],
  templateUrl: './register-button.component.html',
  styleUrl: './register-button.component.css'
})
export class RegisterButtonComponent {
  auth = inject(AuthService);
  public text = input.required<string>();
  public classes = input.required<string>();

  public onClickRegister(): void {
    this.auth.loginWithRedirect({
      authorizationParams: {
        screen_hint: 'signup'
      }
    });
  }
}
