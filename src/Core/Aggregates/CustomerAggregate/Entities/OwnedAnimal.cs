
namespace Domain.Aggregates.CustomerAggregate.Entities;

public class OwnedAnimal : Entity<AnimalId>
{
    public required string Name { get; set; }
    public string? Species { get; set; }
    public string? Breed { get; set; }
    public int? Age { get; set; }
    public string? DietaryRequirements { get; set; }
    public string? Notes { get; set; }

    public static OwnedAnimal Create(AnimalId animalId, string name)
    {
        var ownedAnimal = new OwnedAnimal
        {
            Id = animalId,
            Name = name
        };

        return ownedAnimal;
    }
}
