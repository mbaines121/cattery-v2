namespace Application.Bookings.Queries.Dashboard;

public record GetDashboardQuery() : IQuery<GetDashboardResult>;

public record GetDashboardResult(IEnumerable<DashboardItemDto>? DashboardItems);