var builder = DistributedApplication.CreateBuilder(args);

var sql = builder.AddSqlServer("sql")
                 .WithLifetime(ContainerLifetime.Persistent)
                 .WithEndpoint(1433, 1433, name:"ssms")
                 .WithDataVolume();

var db = sql.AddDatabase("CatteryV2");

/*builder.AddProject<Projects.WebUI>("webui")
    .WithReference(db)
    .WaitFor(db);*/

builder.AddProject<Projects.AngularUI_Server>("angularui-server")
    .WithReference(db)
    .WaitFor(db); ;

builder.Build().Run();
