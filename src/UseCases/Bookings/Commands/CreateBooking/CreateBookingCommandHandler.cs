using Domain.Aggregates.ValueObjects;

namespace Application.Bookings.Commands.CreateBooking;

public class CreateBookingCommandHandler(IApplicationDbContext _context) : ICommandHandler<CreateBookingCommand, CreateBookingResult>
{
    public async Task<CreateBookingResult> Handle(CreateBookingCommand command, CancellationToken cancellationToken)
    {
        var booking = CreateNewBooking(command.Booking);

        _context.Bookings.Add(booking);

        // TODO: DELETE THIS!
        booking.BookedCustomer = BookedCustomer.Create(CustomerId.Of(Guid.NewGuid()), "Name");

        var results = await _context.SaveChangesAsync(cancellationToken);

        return new CreateBookingResult(booking.Id.Value);
    }

    private Booking CreateNewBooking(BookingDto bookingDto)
    {
        var booking = Booking.Create(BookingId.Of(Guid.NewGuid()));

        return booking;
    }
}
