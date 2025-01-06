var builder = DistributedApplication.CreateBuilder(args);

var sql = builder.AddSqlServer("sql")
                 .WithLifetime(ContainerLifetime.Persistent)
                 .WithDataVolume();

var db = sql.AddDatabase("CatteryV2");

builder.AddProject<Projects.WebUI>("webui")
    .WithReference(db);

builder.Build().Run();
