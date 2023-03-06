using OnlineMuhasebe.Domain.Abstractions;
using System.Linq.Expressions;

namespace OnlineMuhasebe.Domain.Repositories.GenericRepositories;

public interface IQueryGenericRepository<TEntity> where TEntity : Entity
{
    IQueryable<TEntity> GetAll(bool isTracking = true);
    IQueryable<TEntity> GetWhere(Expression<Func<TEntity, bool>> expression, bool isTracking = true);
    Task<TEntity> GetById(string id, bool isTracking = true);
    Task<TEntity> GetFirstByExpression(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken, bool isTracking = true);
    Task<TEntity> GetFirst(bool isTracking = true);
}
