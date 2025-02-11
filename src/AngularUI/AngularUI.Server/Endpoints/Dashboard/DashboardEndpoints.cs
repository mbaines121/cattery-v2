using Application.Bookings.Queries.Dashboard;
using Application.Dtos;
using Mapster;

namespace AngularUI.Server.Endpoints.Dashboard;

public record GetDashboardResponse(IEnumerable<DashboardItemDto> DashboardItems);

public class DashboardEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/dashboard", async (ISender sender) =>
        {
            var query = new GetDashboardQuery();
            var result = await sender.Send(query);

            if (result.Success)
            {
                var response = result.Adapt<GetDashboardResponse>();
                return Results.Ok(response);
            }
            else
            {
                return Results.BadRequest(result.Message);
            }
        })
        .WithName("GetDashboardItems")
        .WithSummary("Gets the dashboard items.")
        .WithDescription("Gets a list of dashboard items.")
        .Produces<GetDashboardResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .RequireAuthorization();
    }
}
