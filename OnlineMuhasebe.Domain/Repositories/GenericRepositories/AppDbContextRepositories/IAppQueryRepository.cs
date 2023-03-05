using OnlineMuhasebe.Domain.Abstractions;

namespace OnlineMuhasebe.Domain.Repositories.GenericRepositories.AppDbContextRepositories;

public interface IAppQueryRepository<TEntity> : IRepository<TEntity>, IQueryGenericRepository<TEntity> where TEntity : Entity
{
}
