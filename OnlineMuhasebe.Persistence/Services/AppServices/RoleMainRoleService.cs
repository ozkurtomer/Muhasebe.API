using OnlineMuhasebe.Domain.AppEntities;
using OnlineMuhasebe.Application.Services.AppServices;
using OnlineMuhasebe.Domain.Repositories.AppDbContext.RoleMainRoleRepositories;
using OnlineMuhasebe.Domain.UnitOfWorks;
using System.Threading;

namespace OnlineMuhasebe.Persistence.Services.AppServices;

public sealed class RoleMainRoleService : IRoleMainRoleService
{
    private readonly IAppUnitOfWork AppUnitOfWork;
    private readonly IRoleMainRoleQueryRepository RoleMainRoleQueryRepository;
    private readonly IRoleMainRoleCommandRepository RoleMainRoleCommandRepository;

    public RoleMainRoleService(IRoleMainRoleCommandRepository roleMainRoleCommandRepository, IRoleMainRoleQueryRepository roleMainRoleQueryRepository, IAppUnitOfWork appUnitOfWork)
    {
        AppUnitOfWork = appUnitOfWork;
        RoleMainRoleQueryRepository = roleMainRoleQueryRepository;
        RoleMainRoleCommandRepository = roleMainRoleCommandRepository;
    }

    public async Task CreateAsync(RoleMainRole roleMainRole, CancellationToken cancellationToken)
    {
        await RoleMainRoleCommandRepository.AddAsync(roleMainRole, cancellationToken);
        await AppUnitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(RoleMainRole roleMainRole, CancellationToken cancellationToken)
    {
        RoleMainRoleCommandRepository.Update(roleMainRole);
        await AppUnitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteByIdAsync(string id, CancellationToken cancellationToken)
    {
        await RoleMainRoleCommandRepository.RemoveById(id);
        await AppUnitOfWork.SaveChangesAsync(cancellationToken);
    }

    public IQueryable<RoleMainRole> GetAll()
    {
        return RoleMainRoleQueryRepository.GetAll();
    }

    public async Task<RoleMainRole> GetByIdAsync(string id)
    {
        return await RoleMainRoleQueryRepository.GetById(id);
    }
}
