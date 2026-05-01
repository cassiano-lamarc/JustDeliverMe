namespace JustDeliverMe.Domain.Entities;

public class Points
{
    protected Points()
    {
    }

    public required Guid Id { get; init; }
    public required Guid TenantId { get; init; }
    public required string Description { get; init; }
    public required string Code { get; init; }

    public static Points Create(Guid tenantId, string description, string code)
        => new Points() { Id = Guid.NewGuid(), TenantId = tenantId, Description = description, Code = code };
}
