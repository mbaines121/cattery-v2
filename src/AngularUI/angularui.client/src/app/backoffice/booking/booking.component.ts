import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatFormFieldModule } from '@angular/material/form-field';
import { provideNativeDateAdapter } from '@angular/material/core';
import { BookingModel } from './booking.model';
import { MatButton } from '@angular/material/button';
import { MatStepperModule } from '@angular/material/stepper';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { map, Observable, startWith } from 'rxjs';
import { AsyncPipe } from '@angular/common';

let initialForm: BookingModel;
const savedForm = window.localStorage.getItem('booking-model');

if (savedForm) {
  const loadedForm: BookingModel = JSON.parse(savedForm);
  if (loadedForm) {
    initialForm = loadedForm;
  }
}

@Component({
  selector: 'app-booking',
  imports: [
    ReactiveFormsModule, 
    MatFormFieldModule, 
    MatDatepickerModule, 
    MatButton, 
    MatStepperModule,
    MatAutocompleteModule,
    AsyncPipe
  ],
  providers: [provideNativeDateAdapter()],
  templateUrl: './booking.component.html',
  styleUrl: './booking.component.css'
})
export class BookingComponent implements OnInit {

  // TODO: This needs refactoring into multiple components.

  public firstForm = new FormGroup({
    from: new FormControl<Date | null>(initialForm?.from, {
      validators: [ Validators.required ]
    }),
    to: new FormControl<Date | null>(initialForm?.to, {
      validators: [ Validators.required ]
    })
  });

  public secondForm = new FormGroup({
    selectedCustomer: new FormControl('', {
      validators: [ Validators.required ]
    })
  });

  options: string[] = ['One', 'Two', 'Three'];
  filteredOptions!: Observable<string[]>;

  private _filter(value: string): string[] {
    const filterValue = value.toLowerCase();

    return this.options.filter(option => option.toLowerCase().includes(filterValue));
  }

  constructor() {

  }

  ngOnInit(): void {
    this.filteredOptions = this.secondForm.controls.selectedCustomer.valueChanges.pipe(
      startWith(''),
      map(value => this._filter(value || '')),
    );

    const savedForm = window.localStorage.getItem('booking-model');

    if (savedForm) {
      const loadedForm: BookingModel = JSON.parse(savedForm);
      if (loadedForm) {
        this.firstForm.patchValue({
          from: loadedForm?.from,
          to: loadedForm?.to
        })
      }
    }
  }

  onSubmit() {
    if (this.firstForm.invalid) {
      console.log('INVALID FORM');
      return;
    }

    const enteredFromDate = this.firstForm.value.from;
    const enteredToDate = this.firstForm.value.to;

    if (enteredFromDate && enteredToDate) {
      const bookingModel = new BookingModel(enteredFromDate, enteredToDate);

      window.localStorage.setItem('booking-model', JSON.stringify(bookingModel));
    } else {

    }
  }

  reset() {
    const emptyModel = new BookingModel(null, null);
    window.localStorage.setItem('booking-model', JSON.stringify(null));

    this.firstForm.reset();
  }
}
