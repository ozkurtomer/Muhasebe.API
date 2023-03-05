using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using OnlineMuhasebe.Domain.Abstractions;
using OnlineMuhasebe.Persistence.Context;
using OnlineMuhasebe.Domain.Repositories.GenericRepositories.AppDbContextRepositories;

namespace OnlineMuhasebe.Persistence.Repositories.GenericRepositories.AppDbContextRepositories;

public class AppQueryRepository<TEntity> : IAppQueryRepository<TEntity> where TEntity : Entity
{
    private static readonly Func<AppDbContext, string, bool, Task<TEntity>> GetByIdComplied = EF.CompileAsyncQuery((AppDbContext context, string id, bool isTracking) =>
        isTracking ? context.Set<TEntity>().FirstOrDefault(x => x.Id == id)
                   : context.Set<TEntity>().AsNoTracking().FirstOrDefault(x => x.Id == id)
    );

    private static readonly Func<AppDbContext, bool, Task<TEntity>> GetFirstComplied = EF.CompileAsyncQuery((AppDbContext context, bool isTracking) =>
        isTracking ? context.Set<TEntity>().FirstOrDefault()
                   : context.Set<TEntity>().AsNoTracking().FirstOrDefault()
    );

    public AppQueryRepository(AppDbContext dbContext)
    {
        DbContext = dbContext;
        Entity = DbContext.Set<TEntity>();
    }

    private AppDbContext DbContext;
    public DbSet<TEntity> Entity { get; set; }

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
