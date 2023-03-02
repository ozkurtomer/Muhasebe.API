using OnlineMuhasebe.Domain.AppEntities.Identities;

namespace OnlineMuhasebe.Application.Features.AppFeatures.RoleFeatures.Queries.GetAllRoles;

public sealed record GetAllRolesQueryResponse(
    IList<AppRole> Roles);
