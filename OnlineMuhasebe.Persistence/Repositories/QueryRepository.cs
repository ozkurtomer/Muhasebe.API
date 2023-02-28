using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using OnlineMuhasebe.Domain.Abstractions;
using OnlineMuhasebe.Domain.Repositories;
using OnlineMuhasebe.Persistence.Context;

namespace OnlineMuhasebe.Persistence.Repositories;

public class QueryRepository<TEntity> : IQueryRepository<TEntity> where TEntity : Entity
{
    private static readonly Func<CompanyDbContext, string, bool, Task<TEntity>> GetByIdComplied = EF.CompileAsyncQuery((CompanyDbContext context, string id, bool isTracking) =>
        isTracking ? context.Set<TEntity>().FirstOrDefault(x => x.Id == id)
                   : context.Set<TEntity>().AsNoTracking().FirstOrDefault(x => x.Id == id)
    );

    private static readonly Func<CompanyDbContext, bool, Task<TEntity>> GetFirstComplied = EF.CompileAsyncQuery((CompanyDbContext context, bool isTracking) =>
        isTracking ? context.Set<TEntity>().FirstOrDefault()
                   : context.Set<TEntity>().AsNoTracking().FirstOrDefault()
    );

    private static readonly Func<CompanyDbContext, Expression<Func<TEntity, bool>>, bool, Task<TEntity>> GetFirstByExpressionComplied = EF.CompileAsyncQuery((CompanyDbContext context, Expression<Func<TEntity, bool>> expression, bool isTracking) =>
        isTracking ? context.Set<TEntity>().FirstOrDefault(expression)
                   : context.Set<TEntity>().AsNoTracking().FirstOrDefault(expression)
    );

    private CompanyDbContext DbContext;
    public DbSet<TEntity> Entity { get; set; }

    public void SetDbContextInstance(DbContext dbContext)
    {
        DbContext = (CompanyDbContext)dbContext;
        Entity = DbContext.Set<TEntity>();
    }

    public IQueryable<TEntity> GetAll(bool isTracking = true)
    {
        var result = Entity.AsQueryable();
        if (!isTracking)
        {
            result = result.AsNoTracking();
        }
        return result;
    }

    public async Task<TEntity> GetById(string id, bool isTracking = true)
    {
        return await GetByIdComplied(DbContext, id, isTracking);
    }

    public async Task<TEntity> GetFirst(bool isTracking = true)
    {
        return await GetFirstComplied(DbContext, isTracking);
    }

    public async Task<TEntity> GetFirstByExpression(Expression<Func<TEntity, bool>> expression, bool isTracking = true)
    {
        return await GetFirstByExpressionComplied(DbContext, expression, isTracking);
    }

    public IQueryable<TEntity> GetWhere(Expression<Func<TEntity, bool>> expression, bool isTracking = true)
    {
        var result = Entity.AsQueryable().Where(expression);
        if (!isTracking)
        {
            result = result.AsNoTracking();
        }
        return result;
    }
}
