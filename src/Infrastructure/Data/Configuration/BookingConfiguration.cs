namespace Infrastructure.Data.Configuration;

public class BookingConfiguration : IEntityTypeConfiguration<Booking>
{
    public void Configure(EntityTypeBuilder<Booking> builder)
    {
        builder.HasKey(m => m.Id);
        builder.Property(m => m.Id)
            .HasConversion(bookingId => bookingId.Value, dbId => BookingId.Of(dbId));
    }
}