import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatButton } from '@angular/material/button';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { MatInputModule } from '@angular/material/input';
import { BookingModel } from '../booking.model';

let initialForm: BookingModel;
const savedForm = window.localStorage.getItem('booking-model');

if (savedForm) {
  const loadedForm: BookingModel = JSON.parse(savedForm);
  if (loadedForm) {
    initialForm = loadedForm;
  }
}

@Component({
  selector: 'app-select-dates',
  imports: [
    ReactiveFormsModule,
      MatFormFieldModule,
      MatDatepickerModule,
      MatButton,
      MatAutocompleteModule,
      MatInputModule
  ],
  templateUrl: './select-dates.component.html',
  styleUrl: './select-dates.component.css'
})
export class SelectDatesComponent implements OnInit {
  public dateForm = new FormGroup({
    from: new FormControl<Date | null>(initialForm?.from, {
      validators: [ Validators.required ]
    }),
    to: new FormControl<Date | null>(initialForm?.to, {
      validators: [ Validators.required ]
    })
  });

  ngOnInit(): void {
    const bookingModelJson = window.localStorage.getItem('booking-model');

    if (bookingModelJson) {
      const loadedForm: BookingModel = JSON.parse(bookingModelJson);
      if (loadedForm) {
        this.dateForm.patchValue({
          from: loadedForm?.from,
          to: loadedForm?.to
        })
      }
    }
  }

  onSubmit() {
    if (this.dateForm.invalid) {
      console.log('INVALID FORM');
      return;
    }

    const enteredFromDate = this.dateForm.value.from;
    const enteredToDate = this.dateForm.value.to;

    if (enteredFromDate && enteredToDate) {
      const bookingModel = new BookingModel(enteredFromDate, enteredToDate);

      window.localStorage.setItem('booking-model', JSON.stringify(bookingModel));
    } else {

    }
  }

  reset() {
    const emptyModel = new BookingModel(null, null);
    window.localStorage.setItem('booking-model', JSON.stringify(emptyModel));

    this.dateForm.reset();
  }
}
