using OnlineMuhasebe.Domain.AppEntities;
using OnlineMuhasebe.Persistance.Repositories.GenericRepositories.AppDbContext;
using OnlineMuhasebe.Domain.Repositories.AppDbContext.AppUserCompanyRepositories;

namespace OnlineMuhasebe.Persistance.Repositories.AppDbContext.AppUserCompanyRepositories;

public class AppUserCompanyQueryRepository : AppQueryRepository<AppUserCompany>, IAppUserCompanyQueryRepository
{
    public AppUserCompanyQueryRepository(Persistance.Context.AppDbContext context) : base(context){ }
}
