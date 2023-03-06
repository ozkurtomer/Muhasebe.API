using OnlineMuhasebe.Domain.AppEntities;

namespace OnlineMuhasebe.Application.Features.AppFeatures.MainRoleFeatures.Queries.GetAllMainRole;

public sealed record GetAllMainRoleQueryResponse(
    IList<MainRole> MainRoles);