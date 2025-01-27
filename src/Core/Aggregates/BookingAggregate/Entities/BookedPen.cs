namespace Domain.Aggregates.BookingAggregate.Entities;

public class BookedPen : Entity<PenId>
{
    public string Name { get; set; } = default!;
    public DateTime FromDate { get; set; }
    public DateTime ToDate { get; set; }

    public ICollection<BoardedAnimal> BoardedAnimals { get; set; } = new HashSet<BoardedAnimal>();
}
