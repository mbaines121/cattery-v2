import { Injectable, signal } from "@angular/core";
import { BookingModel } from "./booking.model";

@Injectable({
  providedIn: 'root',
})
export class LocalStorageService {
  public loadedBookingData = signal<BookingModel>(new BookingModel(null, null, null));

  public SaveDatesData(from: Date, to: Date): void {
    this.Load();

    this.loadedBookingData().from = from;
    this.loadedBookingData().to = to;

    this.Save();
  }

  public SaveCustomerData(customer: string): void {
    this.Load();

    this.loadedBookingData().customer = customer;

    this.Save();
  }

  private Save(): void {
    window.localStorage.setItem('booking-model', JSON.stringify(this.loadedBookingData()));

    console.log('[Saved booking model]', JSON.stringify(this.loadedBookingData()));
  }

  public Load(): void {
    const bookingModelJson = window.localStorage.getItem('booking-model');

    if (bookingModelJson) {
      const loadedForm: BookingModel = JSON.parse(bookingModelJson);

      this.loadedBookingData.set(loadedForm);

      console.log('[Loaded booking model]', bookingModelJson);
    }
  }

  public Reset(): void {
    const emptyModel = new BookingModel(null, null, null);
    window.localStorage.setItem('booking-model', JSON.stringify(emptyModel));
  }
}