using OnlineMuhasebe.Domain.AppEntities;
using OnlineMuhasebe.Persistence.Context;
using OnlineMuhasebe.Domain.Repositories.AppDbContext.RoleMainRoleRepositories;
using OnlineMuhasebe.Persistence.Repositories.GenericRepositories.AppDbContextRepositories;

namespace OnlineMuhasebe.Persistence.Repositories.AppDbContextRepositories.RoleMainRoleRepositories;

public sealed class RoleMainRoleQueryRepository : AppQueryRepository<RoleMainRole>, IRoleMainRoleQueryRepository
{
    public RoleMainRoleQueryRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}
