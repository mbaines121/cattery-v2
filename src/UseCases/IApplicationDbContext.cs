using Domain.Aggregates.BookingAggregate.Entities;
using Domain.Aggregates.CustomerAggregate.Entities;
using Domain.Aggregates.PenAggregate.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application;

public interface IApplicationDbContext
{
    DbSet<Booking> Bookings { get; }
    DbSet<BookedCustomer> BookedCustomers { get; }
    DbSet<BookedPen> BookedPens { get; }
    DbSet<BoardedAnimal> BoardedAnimals { get; }

    DbSet<Customer> Customers { get; }
    DbSet<OwnedAnimal> OwnedAnimals { get; }

    DbSet<Pen> Pens { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
