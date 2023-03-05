using OnlineMuhasebe.Domain.Abstractions;
using OnlineMuhasebe.Domain.Repositories.GenericRepositories;

namespace OnlineMuhasebe.Domain.Repositories;

public interface ICompanyQueryRepository<TEntity> : IQueryGenericRepository<TEntity>, ICompanyRepository<TEntity> where TEntity : Entity
{
}
