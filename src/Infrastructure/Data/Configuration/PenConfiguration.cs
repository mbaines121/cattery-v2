namespace Infrastructure.Data.Configuration;

public class PenConfiguration : IEntityTypeConfiguration<Pen>
{
    public void Configure(EntityTypeBuilder<Pen> builder)
    {
        builder.HasKey(m => m.Id);
        builder.Property(m => m.Id)
            .HasConversion(penId => penId.Value, dbId => PenId.Of(dbId));

        builder.Property(m => m.CostPerNight).HasColumnType("money");
    }
}