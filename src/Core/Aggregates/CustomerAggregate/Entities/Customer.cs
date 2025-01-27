namespace Domain.Aggregates.CustomerAggregate.Entities;

public class Customer : AggregateRoot<CustomerId>
{
    public string Name { get; set; } = default!;
    public string EmailAddress { get; set; } = default!;
    public Address Address { get; set; } = default!;

    public ICollection<OwnedAnimal> OwnedAnimals { get; set; } = new HashSet<OwnedAnimal>();

    public static Customer Create(CustomerId customerId)
    {
        var customer = new Customer
        {
            Id = customerId
        };

        customer.AddDomainEvent(new CustomerCreatedEvent(customer));

        return customer;
    }
}
