using Microsoft.EntityFrameworkCore;
using OnlineMuhasebe.Domain.Abstractions;

namespace OnlineMuhasebe.Domain.Repositories;

public interface ICommandRepository<TEntity> : IRepository<TEntity> where TEntity : Entity
{
    Task AddAsync(TEntity entity);
    Task AddRangeAsync(IEnumerable<TEntity> entities);

    void Update(TEntity entity);
    void UpdateRange(IEnumerable<TEntity> entities);

    Task RemoveById(string id);
    void Remove(TEntity entity);
    void RemoveRange(IEnumerable<TEntity> entities);
}

