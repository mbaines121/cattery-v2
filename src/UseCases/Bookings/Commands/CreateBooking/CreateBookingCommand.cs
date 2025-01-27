namespace Application.Bookings.Commands.CreateBooking;

public record CreateBookingCommand(BookingDto Booking) : ICommand<CreateBookingResult>;

public record CreateBookingResult(Guid Id);
