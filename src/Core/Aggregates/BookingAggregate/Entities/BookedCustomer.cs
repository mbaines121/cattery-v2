namespace Domain.Aggregates.BookingAggregate.Entities;

public class BookedCustomer : Entity<CustomerId>
{
    public string Name { get; set; } = default!;
    public string Telephone { get; set; } = default!;
    public string Email { get; set; } = default!;
}
