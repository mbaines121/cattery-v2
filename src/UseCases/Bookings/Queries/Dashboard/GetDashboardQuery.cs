namespace Application.Bookings.Queries.Dashboard;

public record GetDashboardQuery() : IQuery<GetDashboardResult>;

public class GetDashboardResult() : ResultBase
{
    public IEnumerable<DashboardItemDto>? DashboardItems { get; set; }
};