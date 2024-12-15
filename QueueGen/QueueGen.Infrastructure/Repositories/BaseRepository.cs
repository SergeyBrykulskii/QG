using QueueGen.Infrastructure.ApplicationDbContext;
using QueueGen.Infrastructure.Repositories.Abstractions;

namespace QueueGen.Infrastructure.Repositories;

public class BaseRepository<TEntity>(AppDbContext dbContext) : IBaseRepository<TEntity>
    where TEntity : class
{
    public async Task<TEntity> CreateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(entity);

        await dbContext.AddAsync(entity, cancellationToken);
        
        return entity;
    }

    public void Remove(TEntity entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        dbContext.Remove(entity);
    }

    public IQueryable<TEntity> GetAll()
    {
        return dbContext.Set<TEntity>();
    }

    public TEntity Update(TEntity entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        dbContext.Update(entity);

        return entity;
    }

    public async Task<int> SaveChangesAsync()
    {
        return await dbContext.SaveChangesAsync();
    }
}
