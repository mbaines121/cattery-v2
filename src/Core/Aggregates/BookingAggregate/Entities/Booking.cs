namespace Domain.Aggregates.BookingAggregate.Entities;

public class Booking : AggregateRoot<BookingId>
{
    public BookedCustomer? BookedCustomer { get; set; }
    public ICollection<BookedPen> BookedPens { get; set; } = new HashSet<BookedPen>();
    public required string Sub { get; set; }

    public BookedCustomer AddBookedCustomer(CustomerId customerId, string name)
    {
        var bookedCustomer = BookedCustomer.Create(customerId, name);

        BookedCustomer = bookedCustomer;

        return bookedCustomer;
    }

    public static Booking Create(BookingId bookingId, string sub)
    {
        var booking = new Booking
        {
            Id = bookingId,
            Sub = sub
        };

        booking.AddDomainEvent(new BookingCreatedEvent(booking));

        return booking;
    }

    public BookedPen AddBookedPen(PenId penId, string name, DateTime fromDate, DateTime toDate)
    {
        var bookedPen = new BookedPen
        {
            Id = penId,
            Name = name,
            FromDate = fromDate,
            ToDate = toDate
        };

        BookedPens.Add(bookedPen);

        return bookedPen;
    }


    // TODO: Implement other business rules here.

    // Change Date/Time
    // Change pets
    // Change Pens
    // etc.
}
