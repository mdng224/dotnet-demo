using Microsoft.Extensions.Configuration;

var builder = DistributedApplication.CreateBuilder(args);

// 1) Read from AppHost/appsettings.json
var connectionString = builder.Configuration.GetConnectionString("PostgresDb")
    ?? throw new InvalidOperationException("Missing ConnectionStrings:PostgresDb");

// 2) Inject straight into the API as an environment variable
builder.AddProject<Projects.dotnet_demo>("dotnet-demo")
       .WithEnvironment("ConnectionStrings__postgres", connectionString);

builder.Build().Run();
