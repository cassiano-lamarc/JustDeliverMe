using JustDeliverMe.Domain.Interfaces.Persistence;
using JustDeliverMe.Infra.Context;
using Microsoft.EntityFrameworkCore.Storage;

namespace JustDeliverMe.Infra.Persistence;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    private IDbContextTransaction? _transaction;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public async Task BeginTransactionAsync()
    {
        if (_transaction != null) return;

        _transaction = await _context.Database.BeginTransactionAsync();
    }

    public async Task CommitAsync()
    {
        try
        {
            await _context.SaveChangesAsync();

            if (_transaction != null)
                await _transaction.CommitAsync();
        }
        catch
        {
            await RollbackAsync();
            throw;
        }
    }

    public async Task RollbackAsync()
    {
        if (_transaction != null)
            await _transaction.RollbackAsync();
    }
}
