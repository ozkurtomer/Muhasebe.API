using OnlineMuhasebe.Domain.Abstractions;

namespace OnlineMuhasebe.Domain.Repositories;

public interface ICommandRepository<TEntity> : IRepository<TEntity> where TEntity : Entity
{
    Task AddAsync(TEntity entity, CancellationToken token);
    Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken token);

    void Update(TEntity entity);
    void UpdateRange(IEnumerable<TEntity> entities);

    Task RemoveById(string id);
    void Remove(TEntity entity);
    void RemoveRange(IEnumerable<TEntity> entities);
}

