namespace Domain.Aggregates.ValueObjects;

public record BookingId
{
    public Guid Value { get; }

    private BookingId(Guid value) => Value = value;

    public static BookingId Of(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new DomainException("BookingId cannot be empty.");
        }

        return new BookingId(value);
    }
}