using OnlineMuhasebe.Domain.AppEntities;
using OnlineMuhasebe.Persistance.Repositories.GenericRepositories.AppDbContext;
using OnlineMuhasebe.Domain.Repositories.AppDbContext.RoleMainRoleRepositories;

namespace OnlineMuhasebe.Persistance.Repositories.AppDbContext.RoleMainRoleRepositories;

public class RoleMainRoleCommandRepository : AppCommandRepository<RoleMainRole>, IRoleMainRoleCommandRepository
{
    public RoleMainRoleCommandRepository(AppDbContext context) : base(context){ }
}
