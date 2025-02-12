export class BookingModel {
  from: Date | null;
  to: Date | null;
  customer: string | null;

  constructor(from: Date | null, to: Date | null, customer: string | null) {
    this.from = from;
    this.to = to;
    this.customer = customer;
  }
}