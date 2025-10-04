using Aspire.Hosting;

var builder = DistributedApplication.CreateBuilder(args);

// Postgres container
var pgVersion = builder.Configuration["Postgres:Version"] ?? "16";
var postgres = builder.AddPostgres("postgres") // name matters here
    .WithImageTag(pgVersion)
    .WithDataVolume("pgdata"); // reuse this named Docker volume
var pgDbName = builder.Configuration["Postgres:Database"] ?? "appdb";
var appDb = postgres.AddDatabase(pgDbName);

// API
builder.AddProject<Projects.App_Api>("App")
       .WithReference(appDb)
       .WaitFor(appDb)
       .WithHttpEndpoint(port: 5000, name: "api");

// --- Vue dev server (Vite) ---
builder.AddExecutable(
        name: "frontend",
        command: "npm",
        workingDirectory: "../frontend",
        args: ["run", "dev"]
    )
    .WithHttpEndpoint(port: 5173, name: "frontend", isProxied: false);

builder.Build().Run();
