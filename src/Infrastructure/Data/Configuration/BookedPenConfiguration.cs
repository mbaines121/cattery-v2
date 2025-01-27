namespace Infrastructure.Data.Configuration;

public class BookedPenConfiguration : IEntityTypeConfiguration<BookedPen>
{
    public void Configure(EntityTypeBuilder<BookedPen> builder)
    {
        builder.HasKey(m => m.Id);
        builder.Property(m => m.Id)
            .HasConversion(penId => penId.Value, dbId => PenId.Of(dbId));
    }
}