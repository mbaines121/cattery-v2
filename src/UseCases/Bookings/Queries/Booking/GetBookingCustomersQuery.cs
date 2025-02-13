namespace Application.Bookings.Queries.Booking;

public record GetBookingCustomersQuery(string Sub) : IQuery<GetBookingCustomersResult>;

public record GetBookingCustomersResult(IEnumerable<BookingCustomerItemDto> BookingCustomerItems);