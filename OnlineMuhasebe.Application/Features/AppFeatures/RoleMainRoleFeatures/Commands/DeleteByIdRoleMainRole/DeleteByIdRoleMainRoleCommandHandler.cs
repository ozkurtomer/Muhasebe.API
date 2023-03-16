using OnlineMuhasebe.Application.Messaging;
using OnlineMuhasebe.Application.Services.AppServices;

namespace OnlineMuhasebe.Application.Features.AppFeatures.RoleMainRoleFeatures.Commands.DeleteByIdRoleMainRole;

public sealed class DeleteByIdRoleMainRoleCommandHandler : ICommandHandler<DeleteByIdRoleMainRoleCommand, DeleteByIdRoleMainRoleCommandResponse>
{
    private readonly IRoleMainRoleService RoleMainRoleService;

    public DeleteByIdRoleMainRoleCommandHandler(IRoleMainRoleService roleMainRoleService)
    {
        RoleMainRoleService = roleMainRoleService;
    }

    public async Task<DeleteByIdRoleMainRoleCommandResponse> Handle(DeleteByIdRoleMainRoleCommand request, CancellationToken cancellationToken)
    {
        var checkRoleMainRole = await RoleMainRoleService.GetByIdAsync(request.id);
        if (checkRoleMainRole != null) throw new Exception("Silmek istediğiniz rol ilişkisi bulunmamaktadır!");

        await RoleMainRoleService.DeleteByIdAsync(request.id, cancellationToken);
        return new();
    }
}
