namespace Domain.Aggregates.ValueObjects;

public record AnimalId
{
    public Guid Value { get; }

    private AnimalId(Guid value) => Value = value;

    public static AnimalId Of(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new DomainException("AnimalId cannot be empty.");
        }

        return new AnimalId(value);
    }
}