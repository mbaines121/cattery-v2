namespace Domain.Aggregates.PenAggregate.Entities;

public class Pen : AggregateRoot<PenId>
{
    public string Name { get; set; } = default!;
    public int MaxOccupancy { get; set; }
    public decimal CostPerNight { get; set; }

    public static Pen Create(PenId penId, string name)
    {
        var pen = new Pen
        {
            Id = penId,
            Name = name
        };

        pen.AddDomainEvent(new PenCreatedEvent(pen));

        return pen;
    }
}
