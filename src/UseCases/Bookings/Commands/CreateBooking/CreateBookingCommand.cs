using Domain.Aggregates.ValueObjects;

namespace Application.Bookings.Commands.CreateBooking;

public record CreateBookingCommand(BookingDto BookingDto) : ICommand<CreateBookingResult>;

public class CreateBookingResult() : ResultBase
{
    public BookingId? BookingId { get; set; }
};
