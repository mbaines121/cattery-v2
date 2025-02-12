import { Component, viewChild } from '@angular/core';
import { provideNativeDateAdapter } from '@angular/material/core';
import { BookingModel } from './booking.model';
import { MatStepperModule } from '@angular/material/stepper';

import { SelectDatesComponent } from "./select-dates/select-dates.component";
import { SelectCustomerComponent } from "./select-customer/select-customer.component";

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
    MatStepperModule,
    SelectDatesComponent,
    SelectCustomerComponent
],
  providers: [provideNativeDateAdapter()],
  templateUrl: './booking.component.html',
  styleUrl: './booking.component.css'
})
export class BookingComponent {
  public selectDates = viewChild('selectDates');
  public selectCustomer = viewChild('selectCustomer');
}
