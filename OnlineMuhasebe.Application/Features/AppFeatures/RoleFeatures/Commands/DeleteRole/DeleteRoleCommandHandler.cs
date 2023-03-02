using OnlineMuhasebe.Application.Messaging;
using OnlineMuhasebe.Application.Services.AppServices;

namespace OnlineMuhasebe.Application.Features.AppFeatures.RoleFeatures.Commands.DeleteRole;

public sealed class DeleteRoleCommandHandler : ICommandHandler<DeleteRoleCommand, DeleteRoleCommandResponse>
{
    private readonly IRoleService RoleService;

    public DeleteRoleCommandHandler(IRoleService roleService)
    {
        RoleService = roleService;
    }

    public async Task<DeleteRoleCommandResponse> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
    {
        var role = await RoleService.GetByIdRoleAsync(request.Id);
        if (role == null) throw new Exception("Silmek istediğiniz rol bulunamadı");

        await RoleService.DeleteAsync(request);
        return new();
    }
}
