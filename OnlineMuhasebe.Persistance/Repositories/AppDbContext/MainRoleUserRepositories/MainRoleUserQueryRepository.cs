using OnlineMuhasebe.Domain.AppEntities;

namespace OnlineMuhasebe.Persistance.Repositories.AppDbContext.MainRoleUserRepositories;

public class MainRoleUserQueryRepository : AppQueryRepository<MainRoleUser>, IMainRoleUserQueryRepository
{
    public MainRoleUserQueryRepository(Persistance.Context.AppDbContext context) : base(context){ }
}
