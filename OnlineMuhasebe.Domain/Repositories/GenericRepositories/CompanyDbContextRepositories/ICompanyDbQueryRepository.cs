using OnlineMuhasebe.Domain.Abstractions;
using OnlineMuhasebe.Domain.Repositories.GenericRepositories;

namespace OnlineMuhasebe.Domain.Repositories;

public interface ICompanyDbQueryRepository<TEntity> : IQueryGenericRepository<TEntity>, ICompanyDbRepository<TEntity> where TEntity : Entity
{
}
