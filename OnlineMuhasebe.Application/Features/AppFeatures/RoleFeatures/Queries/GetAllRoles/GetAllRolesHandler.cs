using MediatR;
using OnlineMuhasebe.Application.Services.AppServices;

namespace OnlineMuhasebe.Application.Features.AppFeatures.RoleFeatures.Queries.GetAllRoles;

public sealed class GetAllRolesHandler : IRequestHandler<GetAllRolesRequest, GetAllRolesResponse>
{
    private readonly IRoleService RoleService;

    public GetAllRolesHandler(IRoleService roleService)
    {
        RoleService = roleService;
    }

    public async Task<GetAllRolesResponse> Handle(GetAllRolesRequest request, CancellationToken cancellationToken)
    {
        var result = await RoleService.GetAllRolesAsync();
        return new GetAllRolesResponse { Roles = result };
    }
}
