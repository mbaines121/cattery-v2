namespace Domain.Aggregates.PenAggregate.Entities;

public class Pen : AggregateRoot<PenId>
{
    public string Name { get; set; } = default!;
    public int MaxOccupancy { get; set; }
    public decimal CostPerNight { get; set; }
    public required string Sub { get; set; }

    public static Pen Create(PenId penId, string name, string sub)
    {
        var pen = new Pen
        {
            Id = penId,
            Name = name,
            Sub = sub
        };

        pen.AddDomainEvent(new PenCreatedEvent(pen));

        return pen;
    }
}
