using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace GuguShop.Infrastructure.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync();

        Task<IDisposable>  BeginTransactionAsync(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);

        /// <summary>
        /// commit transaction database
        /// </summary>
        /// <returns></returns>
        Task CommitTransactionAsync();

        /// <summary>
        /// send instruction roll back transaction processing to database
        /// </summary>
        /// <returns></returns>
        Task RollBackTransactionAsync();

        /// <summary>
        /// release tracking from entity framework orm, and it will be ignore all change from entity
        /// when flush to database
        /// </summary>
        /// <param name="entity"></param>
        /// <typeparam name="TEntity"></typeparam>
        void ReleaseTrackEntity<TEntity>(TEntity entity);
        
        /// <summary>
        /// attach entity to change-tracker entity framework orm
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TEntity"></typeparam>
        void Attach<TEntity>(TEntity entity, CancellationToken cancellationToken) where TEntity : class;

        /// <summary>
        /// attach range entity to track ef core
        /// </summary>
        /// <param name="entities"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TEntity"></typeparam>
        void AttachRange<TEntity>(
            IEnumerable<TEntity> entities,
            CancellationToken cancellationToken = default) where TEntity : class;
        
        /// <summary>
        /// reload entity from database and override all value difference from database
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TEntity"></typeparam>
        void ReloadEntity<TEntity>(TEntity entity, CancellationToken cancellationToken) where TEntity : class;
    }
}