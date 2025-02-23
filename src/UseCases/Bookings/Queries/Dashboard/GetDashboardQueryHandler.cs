namespace Application.Bookings.Queries.Dashboard;

internal class GetDashboardQueryHandler(IApplicationDbContext _context) : IQueryHandler<GetDashboardQuery, GetDashboardResult>
{
    public async Task<GetDashboardResult> Handle(GetDashboardQuery request, CancellationToken cancellationToken)
    {
        var currentlyBoardedAnimals = await _context.BoardedAnimals
            .Where(m => m.BookedPen.Booking.Sub == request.Sub)
            .Where(m => m.BookedPen.FromDate.Date < DateTime.UtcNow.Date && m.BookedPen.ToDate.Date > DateTime.UtcNow.Date)
            .AsNoTracking()
            .CountAsync();

        var arrivingToday = await _context.BoardedAnimals
            .Where(m => m.BookedPen.Booking.Sub == request.Sub)
            .Where(m => m.BookedPen.FromDate.Date == DateTime.UtcNow.Date)
            .AsNoTracking()
            .CountAsync();

        return new GetDashboardResult(new List<DashboardItemDto>
        {
            new DashboardItemDto
            {
                Title = "Currently boarded",
                Value = currentlyBoardedAnimals
            },
            new DashboardItemDto
            {
                Title = "Arriving today",
                Value = arrivingToday
            }
        });
    }
}
