using OnlineMuhasebe.Domain.AppEntities;

namespace OnlineMuhasebe.Persistance.Repositories.AppDbContext.MainRoleUserRepositories;

public class MainRoleUserCommandRepository : AppCommandRepository<MainRoleUser>, IMainRoleUserCommandRepository
{
    public MainRoleUserCommandRepository(Persistance.Context.AppDbContext context) : base(context){ }
}
