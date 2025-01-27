namespace Domain.Aggregates.BookingAggregate.DomainEvents;

public record BookingCreatedEvent(Booking booking) : IDomainEvent;