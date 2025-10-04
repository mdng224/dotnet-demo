﻿namespace App.Domain.Common;

public interface IAuditableEntity
{
    DateTimeOffset CreatedAtUtc { get; set; }
    DateTimeOffset UpdatedAtUtc { get; set; }
}
