using OnlineMuhasebe.Domain.AppEntities;
using OnlineMuhasebe.Persistence.Context;
using OnlineMuhasebe.Domain.Repositories.AppDbContext.AppUserCompanyRepositories;
using OnlineMuhasebe.Persistence.Repositories.GenericRepositories.AppDbContextRepositories;

namespace OnlineMuhasebe.Persistence.Repositories.AppDbContextRepositories.AppUserCompanyCommandRepositories;

public sealed class AppUserCompanyCommandRepository : AppCommandRepository<AppUserCompany>, IAppUserCompanyCommandRepository
{
    public AppUserCompanyCommandRepository(AppDbContext appDbContext) : base(appDbContext)
    {

    }
}