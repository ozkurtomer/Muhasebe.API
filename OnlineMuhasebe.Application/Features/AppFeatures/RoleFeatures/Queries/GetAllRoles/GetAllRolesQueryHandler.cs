using OnlineMuhasebe.Application.Messaging;
using OnlineMuhasebe.Application.Services.AppServices;

namespace OnlineMuhasebe.Application.Features.AppFeatures.RoleFeatures.Queries.GetAllRoles;

public sealed class GetAllRolesQueryHandler : IQueryHandler<GetAllRolesQuery, GetAllRolesQueryResponse>
{
    private readonly IRoleService RoleService;

    public GetAllRolesQueryHandler(IRoleService roleService)
    {
        RoleService = roleService;
    }

    public async Task<GetAllRolesQueryResponse> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
    {
        var result = await RoleService.GetAllRolesAsync();
        return new GetAllRolesQueryResponse(result);
    }
}
