using System.Linq.Expressions;
using OnlineMuhasebe.Domain.Abstractions;

namespace OnlineMuhasebe.Domain.Repositories;

public interface IQueryRepository<TEntity> : IRepository<TEntity> where TEntity : Entity
{
    IQueryable<TEntity> GetAll();
    IQueryable<TEntity> GetWhere(Expression<Func<TEntity, bool>> expression);
    Task<TEntity> GetById(string id);
    Task<TEntity> GetFirstByExpression(Expression<Func<TEntity, bool>> expression);
    Task<TEntity> GetFirst();
}
