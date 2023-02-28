using MediatR;
using OnlineMuhasebe.Application.Services.AppServices;

namespace OnlineMuhasebe.Application.Features.AppFeatures.RoleFeatures.Commands.DeleteRole;

public sealed class DeleteRoleHandler : IRequestHandler<DeleteRoleRequest, DeleteRoleResponse>
{
    private readonly IRoleService RoleService;

    public DeleteRoleHandler(IRoleService roleService)
    {
        RoleService = roleService;
    }

    public async Task<DeleteRoleResponse> Handle(DeleteRoleRequest request, CancellationToken cancellationToken)
    {
        var role = await RoleService.GetByIdRoleAsync(request.Id);
        if (role == null) throw new Exception("Silmek istediğiniz rol bulunamadı");

        await RoleService.DeleteAsync(request);
        return new();
    }
}
