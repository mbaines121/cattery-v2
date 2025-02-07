
namespace AngularUI.Server.Endpoints.Auth0;

public class WebhookEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        // This webhook is called by Auth0 after a new user has been registered.
        /*app.MapPost("/users", () => {
            // Store the user Id and a new user record in the db. (not customer)
        });*/
    }
}
