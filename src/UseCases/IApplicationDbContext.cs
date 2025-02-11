using Domain.Aggregates.CustomerAggregate.Entities;
using Domain.Aggregates.PenAggregate.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application;

public interface IApplicationDbContext
{
    // Booking aggregate.
    DbSet<Booking> Bookings { get; }
    DbSet<BookedCustomer> BookedCustomers { get; }
    DbSet<BookedPen> BookedPens { get; }
    DbSet<BoardedAnimal> BoardedAnimals { get; }

    // Customer aggregate.
    DbSet<Customer> Customers { get; }
    DbSet<OwnedAnimal> OwnedAnimals { get; }

    // Pen aggregate.
    DbSet<Pen> Pens { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
