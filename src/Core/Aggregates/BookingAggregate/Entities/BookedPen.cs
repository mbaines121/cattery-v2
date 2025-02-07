namespace Domain.Aggregates.BookingAggregate.Entities;

public class BookedPen : Entity<PenId>
{
    public required string Name { get; set; }
    public required DateTime FromDate { get; set; }
    public required DateTime ToDate { get; set; }

    public ICollection<BoardedAnimal> BoardedAnimals { get; set; } = new HashSet<BoardedAnimal>();

    public Booking Booking { get; set; }

    public void AddBoardedAnimal(AnimalId animalId, string name)
    {
        BoardedAnimals.Add(new BoardedAnimal
        {
            Id = animalId,
            Name = name
        });
    }
}
