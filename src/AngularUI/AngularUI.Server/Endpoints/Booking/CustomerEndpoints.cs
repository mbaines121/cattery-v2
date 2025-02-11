using Application.Bookings.Queries.Booking;
using Application.Dtos;
using Mapster;

namespace AngularUI.Server.Endpoints.Dashboard;

public record GetBookingCustomersResponse(IEnumerable<BookingCustomerItemDto> BookingCustomerItems);

public class CustomerEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/booking/customers", async (ISender sender) =>
        {
            var query = new GetBookingCustomersQuery();
            var result = await sender.Send(query);
            var response = result.Adapt<GetBookingCustomersResponse>();

            return Results.Ok(response);
        })
        .WithName("GetBookingCustomerItems")
        .WithSummary("Gets the booking customer items.")
        .WithDescription("Gets a list of customers that can be used on the booking form.")
        .Produces<GetBookingCustomersResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .RequireAuthorization();
    }
}
