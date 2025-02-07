namespace Domain.Aggregates.ValueObjects;

public record Address
{
    public required string AddressLine1 { get; set; }
    public string? AddressLine2 { get; set; }
    public string? TownCity { get; set; }
    public string? County { get; set; }
    public required string Postcode { get; set; }

    private Address()
    {

    }

    public static Address Of(string addressLine1, string addressLine2, string townCity, string county, string postCode)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(addressLine1, nameof(addressLine1));
        ArgumentException.ThrowIfNullOrWhiteSpace(postCode, nameof(postCode));

        return new Address
        {
            AddressLine1 = addressLine1,
            AddressLine2 = addressLine2,
            TownCity = townCity,
            County = county,
            Postcode = postCode
        };
    }
}
