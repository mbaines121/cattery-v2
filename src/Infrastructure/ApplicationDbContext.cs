using Application;
using System.Reflection;

namespace Infrastructure;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Booking> Bookings => Set<Booking>();
    public DbSet<BookedCustomer> BookedCustomers => Set<BookedCustomer>();
    public DbSet<BookedPen> BookedPens => Set<BookedPen>();
    public DbSet<BoardedAnimal> BoardedAnimals => Set<BoardedAnimal>();

    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<OwnedAnimal> OwnedAnimals => Set<OwnedAnimal>();

    public DbSet<Pen> Pens => Set<Pen>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}
