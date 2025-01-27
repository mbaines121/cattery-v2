namespace Domain.Aggregates.BookingAggregate.Entities;

public class Booking : AggregateRoot<BookingId>
{
    public BookedCustomer Customer { get; set; }
    public ICollection<BookedPen> Pens { get; set; } = new HashSet<BookedPen>();

    public static Booking Create(BookingId bookingId)
    {
        var booking = new Booking
        {
            Id = bookingId
        };

        booking.AddDomainEvent(new BookingCreatedEvent(booking));

        return booking;
    }


    // TODO: Implement other business rules here.

    // Change Date/Time
    // Change pets
    // Change Pens
    // etc.
}
