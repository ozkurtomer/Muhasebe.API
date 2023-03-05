using OnlineMuhasebe.Domain.AppEntities;
using OnlineMuhasebe.Domain.Repositories.GenericRepositories.AppDbContextRepositories;

namespace OnlineMuhasebe.Domain.Repositories.AppDbContextRepositories.CompanyRepositories;

public interface ICompanyCommandRepository : IAppCommandRepository<Company>
{
}
