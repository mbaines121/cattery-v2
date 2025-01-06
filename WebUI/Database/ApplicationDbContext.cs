using Database.Models;
using Microsoft.EntityFrameworkCore;

namespace WebUI.Database;

public class ApplicationDbContext : DbContext
{
    public DbSet<Animal> Animals { get; set; }
    public DbSet<Pen> Pens { get; set; }
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<PenBooking> PenBookings { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<AnimalPenBooking> AnimalPenBookings { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        //modelBuilder.Entity<Pen>().Property(m => m.CostPerNight).HasColumnType("money");
        modelBuilder.Entity<PenBooking>().HasKey(sc => new { sc.PenBookingId });
        modelBuilder.Entity<AnimalPenBooking>().HasKey(sc => new { sc.AnimalPenBookingId });

        foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        {
            relationship.DeleteBehavior = DeleteBehavior.NoAction;
        }

        modelBuilder.Entity<Booking>()
            .HasMany(m => m.PenBookings)
            .WithOne(m => m.Booking)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<PenBooking>()
            .HasMany(x => x.AnimalPenBookings)
            .WithOne(x => x.PenBooking)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Customer>()
            .HasQueryFilter(m => !m.Deleted);

        modelBuilder.Entity<Pen>()
            .HasQueryFilter(m => !m.Deleted);

        modelBuilder.Entity<Booking>()
            .HasQueryFilter(m => !m.Deleted);
    }
}
