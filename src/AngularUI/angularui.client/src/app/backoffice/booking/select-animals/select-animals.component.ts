import { Component } from '@angular/core';
import { MatStepperModule } from '@angular/material/stepper';

@Component({
  selector: 'app-select-animals',
  imports: [
    MatStepperModule
  ],
  templateUrl: './select-animals.component.html',
  styleUrl: './select-animals.component.css'
})
export class SelectAnimalsComponent {

}
