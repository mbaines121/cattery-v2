using Microsoft.EntityFrameworkCore;

namespace Application.Bookings.Queries.Dashboard;

internal class GetDashboardQueryHandler(IApplicationDbContext _context) : IQueryHandler<GetDashboardQuery, GetDashboardResult>
{
    public async Task<GetDashboardResult> Handle(GetDashboardQuery request, CancellationToken cancellationToken)
    {
        var currentlyBoardedAnimals = await _context.BoardedAnimals
            .Where(m => m.BookedPen.FromDate.Date < DateTime.UtcNow.Date && m.BookedPen.ToDate.Date > DateTime.UtcNow.Date)
            .ToListAsync();

        var arrivingToday = await _context.BoardedAnimals
            .Where(m => m.BookedPen.FromDate.Date == DateTime.UtcNow.Date)
            .ToListAsync();

        return new GetDashboardResult
        {
            DashboardItems = new List<DashboardItemDto>
            {
                new DashboardItemDto
                {
                    Title = "Currently boarded",
                    Value = currentlyBoardedAnimals.Count()
                },
                new DashboardItemDto
                {
                    Title = "Arriving today",
                    Value = arrivingToday.Count()
                }
            },
            Success = true
        };
    }
}
