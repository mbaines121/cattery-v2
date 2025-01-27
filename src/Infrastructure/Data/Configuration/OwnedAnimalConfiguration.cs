namespace Infrastructure.Data.Configuration;

public class OwnedAnimalConfiguration : IEntityTypeConfiguration<OwnedAnimal>
{
    public void Configure(EntityTypeBuilder<OwnedAnimal> builder)
    {
        builder.HasKey(m => m.Id);
        builder.Property(m => m.Id)
            .HasConversion(animalId => animalId.Value, dbId => AnimalId.Of(dbId));
    }
}