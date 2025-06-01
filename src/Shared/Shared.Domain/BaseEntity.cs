namespace Shared;

public class BaseEntity
{
    public int Id { get; init; }
    public Guid Guid { get; init; } = Guid.NewGuid();
    public DateTimeOffset CreatedAt { get; init; }
    public DateTimeOffset UpdatedAt { get; set; }
}