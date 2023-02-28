using OnlineMuhasebe.Domain.AppEntities.Identities;

namespace OnlineMuhasebe.Application.Features.AppFeatures.RoleFeatures.Queries.GetAllRoles;

public sealed class GetAllRolesResponse
{
    public IList<AppRole> Roles { get; set; }
}
