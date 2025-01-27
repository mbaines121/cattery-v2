namespace Infrastructure.Data.Configuration;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasKey(m => m.Id);
        builder.Property(m => m.Id)
            .HasConversion(customerId => customerId.Value, dbId => CustomerId.Of(dbId));

        builder.HasIndex(m => m.EmailAddress)
            .IsUnique();

        builder.ComplexProperty(m => m.Address, addressBuilder =>
        {
            addressBuilder.Property(p => p.AddressLine1)
                .HasColumnName(nameof(Address.AddressLine1))
                .HasMaxLength(100);

            addressBuilder.Property(p => p.AddressLine2)
                .HasColumnName(nameof(Address.AddressLine2))
                .HasMaxLength(100);

            addressBuilder.Property(p => p.TownCity)
                .HasColumnName(nameof(Address.TownCity))
                .HasMaxLength(100);

            addressBuilder.Property(p => p.County)
                .HasColumnName(nameof(Address.County))
                .HasMaxLength(100);

            addressBuilder.Property(p => p.Postcode)
                .HasColumnName(nameof(Address.Postcode))
                .HasMaxLength(100);
        });
    }
}