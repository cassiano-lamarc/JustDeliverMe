using JustDeliverMe.Domain.Interfaces.Persistence;
using MediatR;

namespace JustDeliverMe.Infra.Persistence;

public class UnitOfWorkBehavior<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public UnitOfWorkBehavior(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        await _unitOfWork.BeginTransactionAsync();

        var response = await next();

        await _unitOfWork.CommitAsync();

        return response;
    }
}
