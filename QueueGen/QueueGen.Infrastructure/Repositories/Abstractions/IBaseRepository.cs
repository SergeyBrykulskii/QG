namespace QueueGen.Infrastructure.Repositories.Abstractions;

public interface IBaseRepository<TEntity> where TEntity : class
{
    IQueryable<TEntity> GetAll();
    Task<TEntity> CreateAsync(TEntity entity, CancellationToken cancellationToken = default);
    TEntity Update(TEntity entity);
    void Remove(TEntity entity);
    Task<int> SaveChangesAsync();
}