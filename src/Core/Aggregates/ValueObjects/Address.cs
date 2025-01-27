namespace Domain.Aggregates.ValueObjects;

public record Address
{
    public string AddressLine1 { get; set; } = default!;
    public string AddressLine2 { get; set; } = default!;
    public string TownCity { get; set; } = default!;
    public string County { get; set; } = default!;
    public string Postcode { get; set; } = default!;
}
