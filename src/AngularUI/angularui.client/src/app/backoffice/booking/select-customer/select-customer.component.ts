import { Component, DestroyRef, inject, OnInit, signal } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatButton } from '@angular/material/button';
import { MatStepperModule } from '@angular/material/stepper';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { map, Observable, retry, startWith } from 'rxjs';
import { AsyncPipe } from '@angular/common';
import { MatInputModule } from '@angular/material/input';
import { BookingService } from '../booking.service';

@Component({
  selector: 'app-select-customer',
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
  templateUrl: './select-customer.component.html',
  styleUrl: './select-customer.component.css'
})
export class SelectCustomerComponent implements OnInit {
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
}
