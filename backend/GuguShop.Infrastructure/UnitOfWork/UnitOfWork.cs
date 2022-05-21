using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using GuguShop.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace GuguShop.Infrastructure.UnitOfWork;

public class UnitOfWork: IUnitOfWork
{
    private readonly GuguDbContext _context;
    private IServiceProvider _services;
    private IDbContextTransaction _currentTransaction;

    public UnitOfWork(GuguDbContext context, IServiceProvider services)
    {
        _context = context;
        _services = services;
    }

    public virtual async Task<IDisposable> BeginTransactionAsync(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
    {
        var source = await _context.Database.BeginTransactionAsync();
        _currentTransaction = source;
        return source;
    }

    public async Task DisposeAsync()
    {
        await _context.DisposeAsync();
    }

    public void ReleaseTrackEntity<TEntity>(TEntity entity)
    {
        _context.Entry(entity).State = EntityState.Detached;
    }

    public void Attach<TEntity>(TEntity entity, CancellationToken cancellationToken) where TEntity : class
    {
        _context.Attach(entity);
    }

    public void ReloadEntity<TEntity>(TEntity entity, CancellationToken cancellationToken) where TEntity : class
    {
        _context.Entry(entity).ReloadAsync(cancellationToken);
    }
        
    public void AttachRange<TEntity>(
        IEnumerable<TEntity> entities,
        CancellationToken cancellationToken = default) where  TEntity : class
    {
        _context.AttachRange(entities);
    }

    public async Task CommitTransactionAsync()
    {
        await _currentTransaction.CommitAsync();
    }

    public async Task RollBackTransactionAsync()
    {
        await _currentTransaction.RollbackAsync();
    }

    public virtual async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}