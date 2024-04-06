namespace Library.Domain.Entities.Core;

public abstract class BaseEntity
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
