using OnlineMuhasebe.Domain.AppEntities;
using OnlineMuhasebe.Persistence.Context;
using OnlineMuhasebe.Domain.Repositories.AppDbContextRepositories.MainRoleRepositories;
using OnlineMuhasebe.Persistence.Repositories.GenericRepositories.AppDbContextRepositories;

namespace OnlineMuhasebe.Persistence.Repositories.AppDbContextRepositories.MainRoleRepositories;

public sealed class MainRoleQueryRepository : AppQueryRepository<MainRole>, IMainRoleQueryRepository
{
    public MainRoleQueryRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}
