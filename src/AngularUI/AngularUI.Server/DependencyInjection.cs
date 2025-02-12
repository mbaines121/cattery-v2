using BuildingBlocks.Exceptions.Handler;

namespace AngularUI.Server;

public static class DependencyInjection
{
    public static IServiceCollection AddWebServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddExceptionHandler<CustomExceptionHandler>();

        return services;
    }

    public static IApplicationBuilder UseWebServices(this IApplicationBuilder app)
    {
        app.UseExceptionHandler(options => { });

        return app;
    }
}