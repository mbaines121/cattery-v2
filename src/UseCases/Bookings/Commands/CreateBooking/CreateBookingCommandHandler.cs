namespace Application.Bookings.Commands.CreateBooking;

public class CreateBookingCommandHandler(IApplicationDbContext _context) : ICommandHandler<CreateBookingCommand, CreateBookingResult>
{
    public async Task<CreateBookingResult> Handle(CreateBookingCommand command, CancellationToken cancellationToken)
    {
        var booking = Booking.Create(BookingId.Of(Guid.NewGuid()));

        var customer = await _context.Customers.FindAsync(command.BookingDto.CustomerId.Value, cancellationToken);
        if (customer is null)
        {
            throw new CustomerNotFoundException(command.BookingDto.CustomerId);
        }

        booking.AddBookedCustomer(command.BookingDto.CustomerId, customer.Name);

        await _context.Bookings.AddAsync(booking, cancellationToken);

        var results = await _context.SaveChangesAsync(cancellationToken);

        return new CreateBookingResult(booking.Id);
    }
}
