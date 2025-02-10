export class BookingModel {
  from: Date | null;
  to: Date | null;

  constructor(from: Date | null, to: Date | null) {
    this.from = from;
    this.to = to;
  }
}