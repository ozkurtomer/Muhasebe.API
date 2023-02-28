using System.Linq.Expressions;
using OnlineMuhasebe.Domain.Abstractions;

namespace OnlineMuhasebe.Domain.Repositories;

public interface IQueryRepository<TEntity> : IRepository<TEntity> where TEntity : Entity
{
    IQueryable<TEntity> GetAll(bool isTracking = true);
    IQueryable<TEntity> GetWhere(Expression<Func<TEntity, bool>> expression, bool isTracking = true);
    Task<TEntity> GetById(string id, bool isTracking = true);
    Task<TEntity> GetFirstByExpression(Expression<Func<TEntity, bool>> expression, bool isTracking = true);
    Task<TEntity> GetFirst(bool isTracking = true);
}
