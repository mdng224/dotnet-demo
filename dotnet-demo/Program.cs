
namespace dotnet_demo;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.AddServiceDefaults();

        // Add services to the container.
        builder.Services.AddAuthorization();

        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();

        builder.AddNpgsqlDataSource("appdb");

        var app = builder.Build();

        app.MapGet("/health/db", async (Npgsql.NpgsqlDataSource ds) =>
        {
            await using var cmd = ds.CreateCommand("SELECT 1");
            var result = await cmd.ExecuteScalarAsync();
            return Results.Ok(new { db = result });
        });


        app.MapDefaultEndpoints();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.Run();
    }
}
