using OnlineMuhasebe.Domain.AppEntities;
using OnlineMuhasebe.Persistence.Context;
using OnlineMuhasebe.Domain.Repositories.AppDbContextRepositories.CompanyRepositories;
using OnlineMuhasebe.Persistence.Repositories.GenericRepositories.AppDbContextRepositories;

namespace OnlineMuhasebe.Persistence.Repositories.AppDbContextRepositories.CompanyRepositories;

public sealed class CompanyCommandRepository : AppCommandRepository<Company>, ICompanyCommandRepository
{
    public CompanyCommandRepository(AppDbContext context) : base(context)
    {
    }
}
