import { Component, inject } from '@angular/core';
import {Location} from '@angular/common';
import { MatIcon } from '@angular/material/icon';
import { MatButton } from '@angular/material/button';

@Component({
  selector: 'app-not-found',
  imports: [
    MatIcon,
    MatButton
  ],
  templateUrl: './not-found.component.html',
  styleUrl: './not-found.component.css'
})
export class NotFoundComponent {
  private _location = inject(Location);

  back() {
    this._location.back();
  }
}
