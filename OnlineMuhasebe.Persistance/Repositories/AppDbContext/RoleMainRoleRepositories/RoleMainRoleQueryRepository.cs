using OnlineMuhasebe.Domain.AppEntities;
using OnlineMuhasebe.Persistance.Repositories.GenericRepositories.AppDbContext;
using OnlineMuhasebe.Domain.Repositories.AppDbContext.RoleMainRoleRepositories;

namespace OnlineMuhasebe.Persistance.Repositories.AppDbContext.RoleMainRoleRepositories;

public class RoleMainRoleQueryRepository : AppQueryRepository<RoleMainRole>, IRoleMainRoleQueryRepository
{
    public RoleMainRoleQueryRepository(Persistance.Context.AppDbContext context) : base(context){ }
}
