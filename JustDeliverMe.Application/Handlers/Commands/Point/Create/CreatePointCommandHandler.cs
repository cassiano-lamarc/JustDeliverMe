using JustDeliverMe.Domain.Entities;
using JustDeliverMe.Infra.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace JustDeliverMe.Application.Handlers.Commands.Point.Create;

public class CreatePointCommandHandler : IRequestHandler<CreatePointCommand, Points>
{
    private readonly AppDbContext _context;

    public CreatePointCommandHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Points> Handle(CreatePointCommand request, CancellationToken cancellationToken = default)
    {
        var existingPoints = await _context.Points.AsNoTracking().Where(p => p.TenantId == request.tenantId).ToListAsync(cancellationToken);
        
        var code = request.code ?? GenerateCode(request.description);
        while (existingPoints.Any(x => x.Code == code))
        {
            code = GenerateCode(request.description);
        }

        var newPoint = Points.Create(request.tenantId, request.description, code);

        _context.Points.Add(newPoint);

        return newPoint;
    }

    public string GenerateCode(string description)
    {
        var prefix = description.Substring(0, 3).ToUpper();

        var number = Random.Shared.Next(1000, 9999);

        var letter = (char)Random.Shared.Next('A', 'Z' + 1);

        return $"{prefix}-{number}-{letter}";
    }
}
