namespace Application.Bookings.Queries.Dashboard;

public record GetDashboardQuery(string Sub) : IQuery<GetDashboardResult>;

public record GetDashboardResult(IEnumerable<DashboardItemDto>? DashboardItems);