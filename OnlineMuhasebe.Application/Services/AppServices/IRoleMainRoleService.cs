
using OnlineMuhasebe.Domain.AppEntities;

namespace OnlineMuhasebe.Application.Services.AppServices;

public interface IRoleMainRoleService
{
    Task CreateAsync(RoleMainRole roleMainRole, CancellationToken cancellationToken);
    Task UpdateAsync(RoleMainRole roleMainRole, CancellationToken cancellationToken);
    Task DeleteByIdAsync(string id, CancellationToken cancellationToken);

    IQueryable<RoleMainRole> GetAll();
    Task<RoleMainRole> GetByIdAsync(string id);
}
