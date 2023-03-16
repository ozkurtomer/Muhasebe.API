
using OnlineMuhasebe.Domain.AppEntities;

namespace OnlineMuhasebe.Application.Features.AppFeatures.RoleMainRoleFeatures.Queries.GetAllRoleMainRole;

public sealed record GetAllRoleMainRoleQueryResponse(
    List<RoleMainRole> RoleMainRoles);
