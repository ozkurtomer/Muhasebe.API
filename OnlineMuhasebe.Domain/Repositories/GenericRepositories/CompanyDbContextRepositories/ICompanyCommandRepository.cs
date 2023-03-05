using OnlineMuhasebe.Domain.Abstractions;

namespace OnlineMuhasebe.Domain.Repositories.GenericRepositories.CompanyDbContextRepositories;

public interface ICompanyCommandRepository<TEntity> : ICompanyRepository<TEntity>, ICommandGenericRepository<TEntity> where TEntity : Entity
{
}
