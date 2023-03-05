using OnlineMuhasebe.Domain.Abstractions;

namespace OnlineMuhasebe.Domain.Repositories.GenericRepositories.CompanyDbContextRepositories;

public interface ICompanyDbCommandRepository<TEntity> : ICompanyDbRepository<TEntity>, ICommandGenericRepository<TEntity> where TEntity : Entity
{
}
