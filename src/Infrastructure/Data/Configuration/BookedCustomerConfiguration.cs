namespace Infrastructure.Data.Configuration;

public class BookedCustomerConfiguration : IEntityTypeConfiguration<BookedCustomer>
{
    public void Configure(EntityTypeBuilder<BookedCustomer> builder)
    {
        builder.HasKey(m => m.Id);
        builder.Property(m => m.Id)
            .HasConversion(customerId => customerId.Value, dbId => CustomerId.Of(dbId));
    }
}
