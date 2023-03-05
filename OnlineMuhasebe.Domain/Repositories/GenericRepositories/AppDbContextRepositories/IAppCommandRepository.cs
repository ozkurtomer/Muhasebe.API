using OnlineMuhasebe.Domain.Abstractions;

namespace OnlineMuhasebe.Domain.Repositories.GenericRepositories.AppDbContextRepositories;

public interface IAppCommandRepository<TEntity> : ICommandGenericRepository<TEntity>, IRepository<TEntity> where TEntity : Entity
{
}
