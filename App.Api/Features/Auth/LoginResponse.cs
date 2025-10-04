namespace App.Api.Features.Auth;

public sealed record LoginResponse(string AccessToken, DateTime ExpiresAtUtc);
