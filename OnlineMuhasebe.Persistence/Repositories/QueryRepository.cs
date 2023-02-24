using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using OnlineMuhasebe.Domain.Abstractions;
using OnlineMuhasebe.Domain.AppEntities;
using OnlineMuhasebe.Domain.Repositories;
using OnlineMuhasebe.Persistence.Context;
using System.Linq.Expressions;

namespace OnlineMuhasebe.Persistence.Repositories;

public class QueryRepository<TEntity> : IQueryRepository<TEntity> where TEntity : Entity
{
    private static readonly Func<CompanyDbContext, string, Task<TEntity>> GetByIdComplied = EF.CompileAsyncQuery((CompanyDbContext context, string id) =>
        context.Set<TEntity>().FirstOrDefault(x => x.Id == id)
    );

    private static readonly Func<CompanyDbContext, Task<TEntity>> GetFirstComplied = EF.CompileAsyncQuery((CompanyDbContext context) =>
    context.Set<TEntity>().FirstOrDefault()
    );

    private static readonly Func<CompanyDbContext, Expression<Func<TEntity, bool>>, Task<TEntity>> GetFirstByExpressionComplied = EF.CompileAsyncQuery((CompanyDbContext context, Expression<Func<TEntity, bool>> expression) =>
        context.Set<TEntity>().FirstOrDefault(expression)
    );

    private CompanyDbContext DbContext;
    public DbSet<TEntity> Entity { get; set; }

    public void SetDbContextInstance(DbContext dbContext)
    {
        DbContext = (CompanyDbContext)dbContext;
        Entity = DbContext.Set<TEntity>();
    }

    public IQueryable<TEntity> GetAll()
    {
        return Entity.AsQueryable();
    }

    public async Task<TEntity> GetById(string id)
    {
        return await GetByIdComplied(DbContext, id);
    }

    public async Task<TEntity> GetFirst()
    {
        return await GetFirstComplied(DbContext);
    }

    public async Task<TEntity> GetFirstByExpression(Expression<Func<TEntity, bool>> expression)
    {
        return await GetFirstByExpressionComplied(DbContext, expression);
    }

    public IQueryable<TEntity> GetWhere(Expression<Func<TEntity, bool>> expression)
    {
        return Entity.AsQueryable().Where(expression);
    }
}
