namespace Application.Bookings.Queries.Booking;

public record GetBookingCustomersQuery() : IQuery<GetBookingCustomersResult>;

public record GetBookingCustomersResult(IEnumerable<BookingCustomerItemDto> BookingCustomerItems);