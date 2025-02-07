namespace Domain.Aggregates.CustomerAggregate.DomainEvents;

public class CustomerAddressUpdatedEvent : IDomainEvent
{
    public CustomerAddressUpdatedEvent(CustomerId customerId, Address newAddress)
    {
        CustomerId = customerId;
        NewAddress = newAddress;
    }

    public CustomerId CustomerId { get; set; }
    public Address NewAddress { get; set; }
}
