# App 🟦

A modern .NET 9 project structured with **Vertical Slice Architecture**, **Entity Framework Core**, and **ASP.NET Aspire** for orchestration.  

This solution demonstrates clean separation of concerns with four core projects:  

- **App.Api** – Minimal API host (endpoints, features, vertical slices)  
- **App.Application** – Application layer (interfaces, DTOs, validators, business rules)  
- **App.Domain** – Domain layer (pure entities, enums, value objects)  
- **App.Infrastructure** – Infrastructure layer (EF Core, ASP.NET Identity, JWT, persistence)  
- **App.AppHost** – Aspire orchestration project (runs services like Postgres + Api together)  
- **App.ServiceDefaults** – Default Aspire configuration (health checks, observability, etc.)

---

## 🏗️ Project Layout

```text
src/
├─ App.Api/              # Minimal API entry point
│   └─ Features/         # Vertical slices (Auth, Weather, Health, etc.)
│
├─ App.Application/      # Contracts, validators, interfaces
│
├─ App.Domain/           # Entities, value objects, domain events
│
├─ App.Infrastructure/   # EF Core, Identity, repositories, JWT services
│
├─ App.AppHost/          # Aspire host orchestrating API + Postgres
│
└─ App.ServiceDefaults/  # Aspire defaults (logging, tracing, health)
```

---

## 🚀 Getting Started

### Prerequisites
- [.NET 9 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)  
- [Docker](https://www.docker.com/) (Aspire orchestrates Postgres inside Docker)  

### Run with Aspire
The `AppHost` project launches **Postgres** and the **Api** service:

```bash
dotnet run --project App.AppHost
```

This will:

- Spin up a PostgreSQL container
- Inject connection strings into App.Api
- Wait for database health before starting the API

### Run API directly
If you want to run just the API (assuming Postgres is already available):
```bash
dotnet run --project App.Api
```

## 🔑 Authentication

- Uses ASP.NET Identity + EF Core for user management
- JWT tokens are generated in App.Infrastructure and used in App.Api
- Endpoints are grouped by feature under Features/* (vertical slice style)

Example feature folder (Features/Auth/):
```
Register.cs
Login.cs
Me.cs
```

## EF Core & Database

- App.Infrastructure.AppDbContext extends IdentityDbContext<AppUser, ...>
- Migrations live in App.Infrastructure/Migrations
- Connection strings are managed via Aspire (appdb) or via dotnet user-secrets

Create migrations:
```bash
dotnet ef migrations add InitialIdentity \
  --startup-project App.Api \
  --project App.Infrastructure
```

Apply migrations:
```
dotnet ef database update \
  --startup-project App.Api \
  --project App.Infrastructure
```

## 🧱 Vertical Slice Architecture

Each feature is self-contained:

```csharp
// Example: Features/Auth/Register.cs
public static class Register
{
    public record Request(string Email, string Password, string DisplayName);
    public record Response(Guid Id, string Email, string Token);

    public static async Task<IResult> Handle(Request req, UserManager<AppUser> users, IJwtTokenService jwt)
    {
        var user = new AppUser { UserName = req.Email, Email = req.Email, DisplayName = req.DisplayName };
        var result = await users.CreateAsync(user, req.Password);
        if (!result.Succeeded) return Results.ValidationProblem(...);

        var token = jwt.CreateAccessToken(user, []);
        return Results.Ok(new Response(user.Id, user.Email!, token));
    }
}
```
This keeps request/response types, handler logic, and endpoint mapping in one place.

##  🛠️ Development

- dotnet build – build all projects
- dotnet test – run tests (add a tests/ project if desired)
- dotnet run --project App.AppHost – run full stack with Aspire

## 🌐 Endpoints

- GET /health/db – check DB connectivity
- POST /auth/register – register a new user
- POST /auth/login – login and receive JWT
- GET /auth/me – get current user info (requires JWT)

## 📖 Notes

- Use dotnet user-secrets for sensitive values like JWT keys and DB passwords when not running under Aspire.
- The solution is designed to evolve: just add new features under App.Api/Features/{FeatureName}.

