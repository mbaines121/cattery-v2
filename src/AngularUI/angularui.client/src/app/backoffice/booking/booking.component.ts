import { Component, DestroyRef, inject, OnInit, signal } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatFormFieldModule } from '@angular/material/form-field';
import { provideNativeDateAdapter } from '@angular/material/core';
import { BookingModel } from './booking.model';
import { MatButton } from '@angular/material/button';
import { MatStepperModule } from '@angular/material/stepper';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { map, Observable, retry, startWith } from 'rxjs';
import { AsyncPipe } from '@angular/common';
import { MatInputModule } from '@angular/material/input';
import { BookingService } from './booking.service';

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
    MatInputModule,
    AsyncPipe
  ],
  providers: [provideNativeDateAdapter()],
  templateUrl: './booking.component.html',
  styleUrl: './booking.component.css'
})
export class BookingComponent implements OnInit {

  ////////////////////////////////////////////////////////////
  // TODO: This needs refactoring into multiple components. //
  ////////////////////////////////////////////////////////////

  public dateForm = new FormGroup({
    from: new FormControl<Date | null>(initialForm?.from, {
      validators: [ Validators.required ]
    }),
    to: new FormControl<Date | null>(initialForm?.to, {
      validators: [ Validators.required ]
    })
  });

  public customersForm = new FormGroup({
    selectedCustomer: new FormControl('', {
      validators: [ Validators.required ]
    })
  });

  public filteredOptions!: Observable<string[]>;

  public isFetchingCustomers = signal(false);
  private destroyRef = inject(DestroyRef);
  private bookingService = inject(BookingService);
  public error = signal('');

  private _filter(value: string): string[] {
    const filterValue = value.toLowerCase();

    return this.bookingService.loadedBookingCustomerItems()
      .filter(customer => customer.name.toLowerCase().includes(filterValue))
      .map(customer => customer.name);
  }

  ngOnInit(): void {
    this.filteredOptions = this.customersForm.controls.selectedCustomer.valueChanges.pipe(
      startWith(''),
      map(value => this._filter(value || '')),
    );

    const savedForm = window.localStorage.getItem('booking-model');

    if (savedForm) {
      const loadedForm: BookingModel = JSON.parse(savedForm);
      if (loadedForm) {
        this.dateForm.patchValue({
          from: loadedForm?.from,
          to: loadedForm?.to
        })
      }
    }

    this.getCustomers();
  }

  getCustomers() {
    this.isFetchingCustomers.set(true);
    const subscription = this.bookingService.getCustomers()
      .pipe(retry(3))
      .subscribe({
        error: error => {
          this.error.set(error.message);
        },
        next: () => {
          this.isFetchingCustomers.set(false);
        }
      });

      this.destroyRef.onDestroy(() => { subscription.unsubscribe(); });
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
    window.localStorage.setItem('booking-model', JSON.stringify(null));

    this.dateForm.reset();
  }
}
