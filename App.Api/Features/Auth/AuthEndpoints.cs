using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity.Data;

namespace App.Api.Features.Auth;

public static class AuthEndpoints
{
    public static void MapAuthEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/auth")
            .WithTags("Auth")
            .WithOpenApi();

        group.MapPost("/login", Login)
            .AllowAnonymous()
            .WithName("Auth_Login")
            .WithSummary("Login to the application")
            .WithDescription("Login with email and password to receive an access token.")
            .Produces<Ok<LoginResponse>>(StatusCodes.Status200OK)
            .Produces<ProblemHttpResult>(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status401Unauthorized);

        group.MapPost("/register", Register)
            .AllowAnonymous()
            .WithName("Auth_Register")
            .WithSummary("Register a new user")
            .WithDescription("Create a new user account with email and password.")
            .Produces<Created<string>>(StatusCodes.Status201Created)
            .Produces<ProblemHttpResult>(StatusCodes.Status400BadRequest);
    }

    private static Results<Ok<LoginResponse>, ProblemHttpResult, UnauthorizedHttpResult>
        Login(LoginRequest loginRequest, CancellationToken ct)
    {
        // TODO: validate credentials; if invalid:
        // return TypedResults.Unauthorized();

        // TODO: if bad input (e.g., missing email), return ValidationProblem:
        // return TypedResults.Problem(title: "Invalid request", statusCode: 400);

        // On success:
        var loginResponse = new LoginResponse("fake.jwt.token", DateTime.UtcNow.AddHours(1));
        return TypedResults.Ok(loginResponse);
    }

    private static Results<Created<string>, ProblemHttpResult>
        Register(RegisterRequest registerRequest, CancellationToken ct)
    {
        // TODO: create user; if validation fails:
        // return TypedResults.Problem(title: "Validation failed", statusCode: 400);

        var userId = "new-user-id"; // from your user store
        var location = $"/auth/users/{userId}";
        return TypedResults.Created(location, userId);
    }
}
