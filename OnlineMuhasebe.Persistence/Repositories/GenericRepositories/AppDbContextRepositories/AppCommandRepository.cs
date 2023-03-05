using Microsoft.EntityFrameworkCore;
using OnlineMuhasebe.Domain.Abstractions;
using OnlineMuhasebe.Persistence.Context;
using OnlineMuhasebe.Domain.Repositories.GenericRepositories.AppDbContextRepositories;

namespace OnlineMuhasebe.Persistence.Repositories.GenericRepositories.AppDbContextRepositories;

public class AppCommandRepository<TEntity> : IAppCommandRepository<TEntity> where TEntity : Entity
{
    private static readonly Func<AppDbContext, string, Task<TEntity>> GetByIdCompile = EF.CompileAsyncQuery((AppDbContext context, string id) =>
        context.Set<TEntity>().FirstOrDefault(x => x.Id == id)
    );

    private readonly AppDbContext Context;
    public DbSet<TEntity> Entity { get; set; }

    public AppCommandRepository(AppDbContext context)
    {
        Context = context;
        Entity = Context.Set<TEntity>();
    }

    public async Task AddAsync(TEntity entity, CancellationToken token)
    {
        await Entity.AddAsync(entity, token);
    }

    public async Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken token)
    {
        await Entity.AddRangeAsync(entities, token);
    }

    public void Update(TEntity entity)
    {
        Entity.Update(entity);
    }

    public void UpdateRange(IEnumerable<TEntity> entities)
    {
        Entity.UpdateRange(entities);
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
}
