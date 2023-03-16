using Microsoft.EntityFrameworkCore;
using OnlineMuhasebe.Application.Messaging;
using OnlineMuhasebe.Application.Services.AppServices;

namespace OnlineMuhasebe.Application.Features.AppFeatures.RoleMainRoleFeatures.Queries.GetAllRoleMainRole;

public sealed class GetAllRoleMainRoleQueryHandler : IQueryHandler<GetAllRoleMainRoleQuery, GetAllRoleMainRoleQueryResponse>
{
    private readonly IRoleMainRoleService RoleMainRoleService;

    public GetAllRoleMainRoleQueryHandler(IRoleMainRoleService roleMainRoleService)
    {
        RoleMainRoleService = roleMainRoleService;
    }

    public async Task<GetAllRoleMainRoleQueryResponse> Handle(GetAllRoleMainRoleQuery request, CancellationToken cancellationToken)
    {
        var result = await RoleMainRoleService.GetAll().Include(x => x.MainRole).Include(x => x.AppRole).ToListAsync();
        return new(result);
    }
}
