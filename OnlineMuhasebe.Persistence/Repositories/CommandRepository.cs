using Microsoft.EntityFrameworkCore;
using OnlineMuhasebe.Domain.Abstractions;
using OnlineMuhasebe.Domain.Repositories;
using OnlineMuhasebe.Persistence.Context;

namespace OnlineMuhasebe.Persistence.Repositories;

public class CommandRepository<TEntity> : ICommandRepository<TEntity> where TEntity : Entity
{
    private static readonly Func<CompanyDbContext, string, Task<TEntity>> GetByIdCompile = EF.CompileAsyncQuery((CompanyDbContext context, string id) =>
        context.Set<TEntity>().FirstOrDefault(x => x.Id == id)
    );

    private CompanyDbContext Context;
    public DbSet<TEntity> Entity { get; set; }

    public void SetDbContextInstance(DbContext dbContext)
    {
        Context = (CompanyDbContext)dbContext;
        Entity = Context.Set<TEntity>();
    }

    public async Task AddAsync(TEntity entity)
    {
        await Entity.AddAsync(entity);
    }

    public async Task AddRangeAsync(IEnumerable<TEntity> entities)
    {
        await Entity.AddRangeAsync(entities);
    }

    public void Remove(TEntity entity)
    {
        Entity.Remove(entity);
    }

    public async Task RemoveById(string id)
    {
        var entity = await GetByIdCompile(Context, id);
        Remove(entity);
    }

    public void RemoveRange(IEnumerable<TEntity> entities)
    {
        Entity.RemoveRange(entities);
    }

    public void Update(TEntity entity)
    {
        Entity.Update(entity);
    }

    public void UpdateRange(IEnumerable<TEntity> entities)
    {
        Entity.UpdateRange(entities);
    }
}
