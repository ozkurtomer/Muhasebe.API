using Microsoft.EntityFrameworkCore;
using OnlineMuhasebe.Domain.Abstractions;
using OnlineMuhasebe.Persistence.Context;
using OnlineMuhasebe.Domain.Repositories.GenericRepositories.CompanyDbContextRepositories;

namespace OnlineMuhasebe.Persistence.Repositories.GenericRepositories.CompanyDbContextRepositories;

public class CompanyDbCommandRepository<TEntity> : ICompanyDbCommandRepository<TEntity> where TEntity : Entity
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

    public async Task AddAsync(TEntity entity, CancellationToken token)
    {
        await Entity.AddAsync(entity, token);
    }

    public async Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken token)
    {
        await Entity.AddRangeAsync(entities, token);
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
