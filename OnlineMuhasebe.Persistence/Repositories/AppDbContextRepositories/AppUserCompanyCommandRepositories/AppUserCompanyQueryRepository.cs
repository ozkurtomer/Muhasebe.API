using OnlineMuhasebe.Domain.AppEntities;
using OnlineMuhasebe.Persistence.Context;
using OnlineMuhasebe.Domain.Repositories.AppDbContext.AppUserCompanyRepositories;
using OnlineMuhasebe.Persistence.Repositories.GenericRepositories.AppDbContextRepositories;

namespace OnlineMuhasebe.Persistence.Repositories.AppDbContextRepositories.AppUserCompanyCommandRepositories;

public sealed class AppUserCompanyQueryRepository : AppQueryRepository<AppUserCompany>, IAppUserCompanyQueryRepository
{
    public AppUserCompanyQueryRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }
}
