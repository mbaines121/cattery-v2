using Domain.Aggregates.ValueObjects;

namespace Application.Bookings.Commands.CreateBooking;

public class CreateBookingCommandHandler(IApplicationDbContext _context) : ICommandHandler<CreateBookingCommand, CreateBookingResult>
{
    public async Task<CreateBookingResult> Handle(CreateBookingCommand command, CancellationToken cancellationToken)
    {
        var booking = CreateNewBooking(command.Booking);

        _context.Bookings.Add(booking);

        // TODO: DELETE THIS!
        booking.Customer = new BookedCustomer
        {
            Id = CustomerId.Of(Guid.NewGuid()),
            Email = "someone@customer.com",
            Name = "Name",
            Telephone = "07854123654"
        };

        //

        var results = await _context.SaveChangesAsync(cancellationToken);

        return new CreateBookingResult(booking.Id.Value);
    }

    private Booking CreateNewBooking(BookingDto boookingDto)
    {
        var booking = Booking.Create(BookingId.Of(Guid.NewGuid()));

        return booking;
    }
}
