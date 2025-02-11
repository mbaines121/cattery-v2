namespace Application.Bookings.Commands.CreateBooking;

public record CreateBookingCommand(BookingDto BookingDto) : ICommand<CreateBookingResult>;

public record CreateBookingResult(BookingId BookingId);
