var builder = DistributedApplication.CreateBuilder(args);

// optional: pin version + keep data in a named Docker volume
var pgVersion = builder.Configuration["Postgres:Version"] ?? "16";

var postgres = builder.AddPostgres("postgres") // name matters here
    .WithImageTag("16")
    .WithDataVolume("pgdata"); // reuse this named Docker volume


// create a logical database; this name becomes your ConnectionStrings key
var pgDbName = builder.Configuration["Postgres:Database"] ?? "appdb";
var appDb = postgres.AddDatabase(pgDbName);

builder.AddProject<Projects.dotnet_demo>("dotnet-demo")
       .WithReference(appDb)     // injects ConnectionStrings:{pgDbName}
       .WaitFor(appDb);          // API waits for DB health

builder.Build().Run();
