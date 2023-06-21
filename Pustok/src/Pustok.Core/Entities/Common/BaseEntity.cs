namespace Pustok.Core.Entities.Common;

public class BaseEntity
{
    public Guid Id { get; set; }
    public bool IsDeleted { get; set; }
}