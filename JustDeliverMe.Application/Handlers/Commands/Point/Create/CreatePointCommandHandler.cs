using JustDeliverMe.Domain.Entities;
using JustDeliverMe.Infra.Context;
using MediatR;

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
        var newPoint = Points.Create(request.description);

        _context.Points.Add(newPoint);

        return newPoint;
    }
}
