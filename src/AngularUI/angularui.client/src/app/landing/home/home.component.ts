import { Component } from '@angular/core';
import { RegisterButtonComponent } from '../../shared/register-button/register-button.component';

@Component({
  selector: 'app-home',
  imports: [RegisterButtonComponent],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {

}
