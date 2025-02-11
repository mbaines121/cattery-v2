using Domain.Aggregates.ValueObjects;

namespace Application.Dtos;

public record BookingDto(BookingId BookingId, CustomerId CustomerId);