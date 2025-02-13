namespace Domain.Aggregates.ValueObjects;

public record UserId
{
    public string Value { get; }

    private UserId(string value) => Value = value;

    public static UserId Of(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            throw new DomainException("UserId cannot be empty.");
        }

        return new UserId(value);
    }
}