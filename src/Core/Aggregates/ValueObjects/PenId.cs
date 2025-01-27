namespace Domain.Aggregates.ValueObjects;

public record PenId
{
    public Guid Value { get; }

    private PenId(Guid value) => Value = value;

    public static PenId Of(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new DomainException("PenId cannot be empty.");
        }

        return new PenId(value);
    }
}
