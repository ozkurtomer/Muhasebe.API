using MediatR;
using Microsoft.AspNetCore.Identity;
using OnlineMuhasebe.Domain.AppEntities.Identities;

namespace OnlineMuhasebe.Application.Features.AppFeatures.RoleFeatures.Commands.DeleteRole;

public sealed class DeleteRoleHandler : IRequestHandler<DeleteRoleRequest, DeleteRoleResponse>
{
    private readonly RoleManager<AppRole> RoleManager;

    public DeleteRoleHandler(RoleManager<AppRole> roleManager)
    {
        RoleManager = roleManager;
    }

    public async Task<DeleteRoleResponse> Handle(DeleteRoleRequest request, CancellationToken cancellationToken)
    {
        var role = await RoleManager.FindByIdAsync(request.Id);
        if (role == null) throw new Exception("Silmek istediğiniz rol bulunamadı");

        await RoleManager.DeleteAsync(role);
        return new();
    }
}
