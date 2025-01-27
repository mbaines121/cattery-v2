namespace Domain.Aggregates.BookingAggregate.Entities;

public class BoardedAnimal : Entity<AnimalId>
{
    public string Name { get; set; } = default!;
}
