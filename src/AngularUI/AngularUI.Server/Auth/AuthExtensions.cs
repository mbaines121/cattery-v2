using AngularUI.Server.Auth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace AngularUI.Server.Auth;

public static class AuthExtensions
{
    public static IServiceCollection AddAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.Authority = $"https://{configuration["Auth0:Domain"]}/";
                options.Audience = configuration["Auth0:Audience"];
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    NameClaimType = ClaimTypes.NameIdentifier
                };
            });

        services.AddSingleton<IAuthorizationHandler, HasScopeHandler>();

        return services;
    }

    public static IServiceCollection AddAuthorisation(this IServiceCollection services)
    {
        services.AddAuthorization(options =>
         {
             options.AddPolicy("read:admin", policy => policy.Requirements.Add(new HasScopeRequirement("read:admin", "domain")));
         });

        return services;
    }
}
