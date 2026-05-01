using JustDeliverMe.Domain.Entities;
using MediatR;

namespace JustDeliverMe.Application.Handlers.Commands.Point.Create;

public record CreatePointCommand(Guid tenantId, string description, string? code) : IRequest<Points>;