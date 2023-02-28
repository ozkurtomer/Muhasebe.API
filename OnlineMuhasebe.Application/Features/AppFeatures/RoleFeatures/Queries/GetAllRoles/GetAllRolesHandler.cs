using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineMuhasebe.Domain.AppEntities.Identities;

namespace OnlineMuhasebe.Application.Features.AppFeatures.RoleFeatures.Queries.GetAllRoles;

public sealed class GetAllRolesHandler : IRequestHandler<GetAllRolesRequest, GetAllRolesResponse>
{
    private readonly RoleManager<AppRole> RoleManager;

    public GetAllRolesHandler(RoleManager<AppRole> roleManager)
    {
        RoleManager = roleManager;
    }

    public async Task<GetAllRolesResponse> Handle(GetAllRolesRequest request, CancellationToken cancellationToken)
    {
        var result = await RoleManager.Roles.ToListAsync();
        return new GetAllRolesResponse { Roles = result };
    }
}
