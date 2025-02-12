import { Component, viewChild } from '@angular/core';
import { provideNativeDateAdapter } from '@angular/material/core';
import { MatStepperModule } from '@angular/material/stepper';
import { SelectDatesComponent } from "./select-dates/select-dates.component";
import { SelectCustomerComponent } from "./select-customer/select-customer.component";

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
