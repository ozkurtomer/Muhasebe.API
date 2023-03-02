using OnlineMuhasebe.Application.Messaging;
using OnlineMuhasebe.Application.Services.AppServices;

namespace OnlineMuhasebe.Application.Features.AppFeatures.RoleFeatures.Commands.UpdateRole;

public sealed class UpdateRoleCommandHandler : ICommandHandler<UpdateRoleCommand, UpdateRoleCommandResponse>
{
    private readonly IRoleService RoleService;

    public UpdateRoleCommandHandler(IRoleService roleService)
    {
        RoleService = roleService;
    }

    public async Task<UpdateRoleCommandResponse> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
    {
        var role = await RoleService.GetByIdRoleAsync(request.Id);
        if (role == null) throw new Exception("Rol bulunamadı!");

        if (role.Code != request.Code)
        {
            var checkCode = await RoleService.GetByCodeRoleAsync(role.Code);
            if (checkCode != null) throw new Exception("Girdiğiniz kod daha önce kaydedilmiştir!");
        }

        role.Code = request.Code;
        role.Name = request.Name;
        await RoleService.UpdateAsync(role);

        return new();
    }
}
