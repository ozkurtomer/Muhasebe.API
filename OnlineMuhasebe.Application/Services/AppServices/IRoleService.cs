using OnlineMuhasebe.Domain.AppEntities.Identities;
using OnlineMuhasebe.Application.Features.AppFeatures.RoleFeatures.Commands.DeleteRole;
using OnlineMuhasebe.Application.Features.AppFeatures.RoleFeatures.Commands.CreateRole;

namespace OnlineMuhasebe.Application.Services.AppServices;

public interface IRoleService
{
    Task AddAsync(CreateRoleCommand request);
    Task AddRangeAsync(IEnumerable<AppRole> roleList);
    Task UpdateAsync(AppRole role);
    Task DeleteAsync(DeleteRoleCommand request);
    Task<IList<AppRole>> GetAllRolesAsync();
    Task<AppRole> GetByIdRoleAsync(string id);
    Task<AppRole> GetByCodeRoleAsync(string code);
}
