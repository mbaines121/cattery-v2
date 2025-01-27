namespace Infrastructure.Data.Configuration;

public class BoardedAnimalConfiguration : IEntityTypeConfiguration<BoardedAnimal>
{
    public void Configure(EntityTypeBuilder<BoardedAnimal> builder)
    {
        builder.HasKey(m => m.Id);
        builder.Property(m => m.Id)
            .HasConversion(animalId => animalId.Value, dbId => AnimalId.Of(dbId));
    }
}