namespace JustDeliverMe.Domain.Entities;

public class Points
{
    protected Points()
    {
    }

    public required Guid Id { get; init; }
    public required string Description { get; init; }
    public required string Code { get; init; }

    public static Points Create(string description)
    {
        var random = new Random();
        var code = random.Next(100000, 999999).ToString();
        return new Points() { Id = Guid.NewGuid(), Description = description, Code = code };
    }
}
