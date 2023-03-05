using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using OnlineMuhasebe.Domain.Abstractions;
using OnlineMuhasebe.Domain.Repositories;
using OnlineMuhasebe.Persistence.Context;

namespace OnlineMuhasebe.Persistence.Repositories.GenericRepositories.CompanyDbContextRepositories;

public class CompanyDbQueryRepository<TEntity> : ICompanyDbQueryRepository<TEntity> where TEntity : Entity
{
    private static readonly Func<CompanyDbContext, string, bool, Task<TEntity>> GetByIdComplied = EF.CompileAsyncQuery((CompanyDbContext context, string id, bool isTracking) =>
        isTracking ? context.Set<TEntity>().FirstOrDefault(x => x.Id == id)
                   : context.Set<TEntity>().AsNoTracking().FirstOrDefault(x => x.Id == id)
    );

    private static readonly Func<CompanyDbContext, bool, Task<TEntity>> GetFirstComplied = EF.CompileAsyncQuery((CompanyDbContext context, bool isTracking) =>
        isTracking ? context.Set<TEntity>().FirstOrDefault()
                   : context.Set<TEntity>().AsNoTracking().FirstOrDefault()
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
        TEntity entity = null;
        if (!isTracking)
            entity = await Entity.AsNoTracking().FirstOrDefaultAsync(expression);
        else
            entity = await Entity.FirstOrDefaultAsync(expression);

        return entity;
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
