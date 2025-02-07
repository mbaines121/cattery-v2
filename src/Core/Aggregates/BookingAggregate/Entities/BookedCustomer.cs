namespace Domain.Aggregates.BookingAggregate.Entities;

public class BookedCustomer : Entity<CustomerId>
{
    public required string Name { get; set; } = default!;
    public string? Telephone { get; set; }
    public string? Email { get; set; }

    public ICollection<Booking> Bookings { get; set; } = new HashSet<Booking>();

    private BookedCustomer() { }

    public static BookedCustomer Create(CustomerId id, string name)
    {
        return new BookedCustomer
        {
            Id = id,
            Name = name
        };
    }
}
