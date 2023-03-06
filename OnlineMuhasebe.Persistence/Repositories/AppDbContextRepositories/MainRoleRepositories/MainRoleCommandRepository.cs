using OnlineMuhasebe.Domain.AppEntities;
using OnlineMuhasebe.Domain.Repositories.AppDbContextRepositories.MainRoleRepositories;
using OnlineMuhasebe.Persistence.Context;
using OnlineMuhasebe.Persistence.Repositories.GenericRepositories.AppDbContextRepositories;

namespace OnlineMuhasebe.Persistence.Repositories.AppDbContextRepositories.MainRoleRepositories;

public sealed class MainRoleCommandRepository : AppCommandRepository<MainRole>, IMainRoleCommandRepository
{
    public MainRoleCommandRepository(AppDbContext context) : base(context)
    {
    }
}
