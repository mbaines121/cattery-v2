using AngularUI.Server;
using AngularUI.Server.Auth;
using Application;
using Infrastructure;
using Infrastructure.Data.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.AddSqlServerDbContext<ApplicationDbContext>(connectionName: "CatteryV2");

builder.AddServiceDefaults();

builder.Services
    .AddWebServices(builder.Configuration)
    .AddApplicationServices(builder.Configuration)
    .AddInfrastructureServices(builder.Configuration);

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services
    .AddAuthentication(builder.Configuration)
    .AddAuthorisation();

builder.Services.AddCarter();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.MapCarter();

app.UseDefaultFiles();
app.MapStaticAssets();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    using (var scope = app.Services.CreateScope())
    {
        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        //context.Database.EnsureCreated();

        await context.Database.EnsureDeletedAsync();
    }

    await app.InitialiseDatabaseAsync();
}

app.UseHttpsRedirection();

app.MapFallbackToFile("/index.html");

app.Run();

// set the default project to Infrastructure
// add-migration UpdatedForeignKeys -OutputDir Data/Migrations -StartupProject AngularUI.Server