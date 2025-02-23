import { HttpClient, HttpParams } from "@angular/common/http";
import { inject, Injectable, signal } from "@angular/core";
import { AuthService } from "@auth0/auth0-angular";
import { throwError } from "rxjs";
import { catchError, concatMap, tap } from "rxjs/operators";
import { BookingCustomerItem } from "./booking.interface";

@Injectable({
  providedIn: 'root',
})
export class BookingService {
  private httpClient = inject(HttpClient);
  private auth = inject(AuthService);

  private bookingCustomerItem = signal<BookingCustomerItem[]>([]);

  public loadedBookingCustomerItems = this.bookingCustomerItem.asReadonly();

  getCustomers() {
    return this.auth.user$.pipe(
        concatMap(user => this.getCustomersHelper(user?.sub ?? ''))
      );
  }

  getCustomersHelper(sub: string) {
    return this.httpClient.get<{ bookingCustomerItems: BookingCustomerItem[] }>('/api/booking/customers', {
      params: new HttpParams().set('userId', sub)
    }).pipe(
        tap({
          next: response => { this.bookingCustomerItem.set(response.bookingCustomerItems); }
        }),
        catchError(() => throwError(() => new Error('Unable to get customer list.')))
      )
  }
}