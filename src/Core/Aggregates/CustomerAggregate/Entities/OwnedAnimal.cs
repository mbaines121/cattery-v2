namespace Domain.Aggregates.CustomerAggregate.Entities;

public class OwnedAnimal : Entity<AnimalId>
{
    public string Name { get; set; } = default!;
    public string Species { get; set; } = default!;
    public string Breed { get; set; } = default!;
    public int Age { get; set; }
    public string DietaryRequirements { get; set; } = default!;
    public string Notes { get; set; } = default!;
}
