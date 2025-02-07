

namespace Domain.Aggregates.CustomerAggregate.Entities;

public class Customer : AggregateRoot<CustomerId>
{
    public required string Name { get; set; }
    public required string EmailAddress { get; set; }
    public Address Address { get; set; } = default!;

    public ICollection<OwnedAnimal> OwnedAnimals { get; set; } = new HashSet<OwnedAnimal>();

    public static Customer Create(CustomerId customerId, string name, string emailAddress)
    {
        var customer = new Customer
        {
            Id = customerId,
            Name = name,
            EmailAddress = emailAddress
        };

        customer.AddDomainEvent(new CustomerCreatedEvent(customer));

        return customer;
    }

    public OwnedAnimal AddAnimal(AnimalId animalId, string name)
    {
        var ownedAnimal = OwnedAnimal.Create(animalId, name);

        OwnedAnimals.Add(ownedAnimal);

        return ownedAnimal;
    }

    public void SetAddress(Address address)
    {
        Address = address;

        AddDomainEvent(new CustomerAddressUpdatedEvent(Id, address));
    }
}
