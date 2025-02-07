using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Data.Extensions;

public static class DatabaseExtension
{
    public static async Task InitialiseDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        await context.Database.MigrateAsync();

        await SeedAsync(context);
    }

    private static async Task SeedAsync(ApplicationDbContext context)
    {
        await SeedPensAsync(context);
        await SeedCustomersAsync(context);
        await SeedBookingsAsync(context);
    }

    private static async Task SeedPensAsync(ApplicationDbContext context)
    {
        if (!await context.Pens.AnyAsync())
        {
            await context.Pens.AddRangeAsync(InitialData.Pens);

            await context.SaveChangesAsync();
        }
    }

    private static async Task SeedCustomersAsync(ApplicationDbContext context)
    {
        if (!await context.Customers.AnyAsync())
        {
            await context.Customers.AddRangeAsync(InitialData.Customers);

            await context.SaveChangesAsync();
        }
    }

    private static async Task SeedBookingsAsync(ApplicationDbContext context)
    {
        if (!await context.Bookings.AnyAsync())
        {
            await context.Bookings.AddRangeAsync(InitialData.Bookings);

            await context.SaveChangesAsync();
        }
    }
}
