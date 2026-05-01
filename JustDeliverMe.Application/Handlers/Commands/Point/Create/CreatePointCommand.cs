using JustDeliverMe.Domain.Entities;
using MediatR;

namespace JustDeliverMe.Application.Handlers.Commands.Point.Create;

public record CreatePointCommand(string description) : IRequest<Points>;