using OnlineMuhasebe.Domain.AppEntities.Identities;
using OnlineMuhasebe.Application.Features.AppFeatures.RoleFeatures.Commands.DeleteRole;
using OnlineMuhasebe.Application.Features.AppFeatures.RoleFeatures.Commands.CreateRole;

namespace OnlineMuhasebe.Application.Services.AppServices;

public interface IRoleService
{
    Task AddAsync(CreateRoleRequest request);
    Task UpdateAsync(AppRole role);
    Task DeleteAsync(DeleteRoleRequest request);
    Task<IList<AppRole>> GetAllRolesAsync();
    Task<AppRole> GetByIdRoleAsync(string id);
    Task<AppRole> GetByCodeRoleAsync(string code);
}
