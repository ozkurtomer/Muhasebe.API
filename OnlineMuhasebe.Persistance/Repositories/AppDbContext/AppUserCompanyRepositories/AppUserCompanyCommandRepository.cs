using OnlineMuhasebe.Domain.AppEntities;

namespace OnlineMuhasebe.Persistance.Repositories.AppDbContext.AppUserCompanyRepositories;

public class AppUserCompanyCommandRepository : AppCommandRepository<AppUserCompany>, IAppUserCompanyCommandRepository
{
    public AppUserCompanyCommandRepository(Persistance.Context.AppDbContext context) : base(context){ }
}
