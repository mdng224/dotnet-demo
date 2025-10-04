using App.Domain.Common;

namespace App.Domain.Users;

public class User : IAuditableEntity
{
    public Guid Id { get; private set; }
    public string Email { get; private set; } = null!;
    public string PasswordHash { get; private set; } = null!;
    public DateTimeOffset CreatedAtUtc { get; set; }
    public DateTimeOffset UpdatedAtUtc { get; set; }

    // EF needs a parameterless constructor
    private User() { }

    public User(string email, string passwordHash)
    {
        Id = Guid.NewGuid();
        Email = email;
        PasswordHash = passwordHash;

        var now = DateTimeOffset.UtcNow;
        CreatedAtUtc = now;
        UpdatedAtUtc = now;
    }
}
