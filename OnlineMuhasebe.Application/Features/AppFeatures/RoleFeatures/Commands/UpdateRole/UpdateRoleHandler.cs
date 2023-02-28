using MediatR;
using OnlineMuhasebe.Application.Services.AppServices;

namespace OnlineMuhasebe.Application.Features.AppFeatures.RoleFeatures.Commands.UpdateRole;

public sealed class UpdateRoleHandler : IRequestHandler<UpdateRoleRequest, UpdateRoleResponse>
{
    private readonly IRoleService RoleService;

    public UpdateRoleHandler(IRoleService roleService)
    {
        RoleService = roleService;
    }

    public async Task<UpdateRoleResponse> Handle(UpdateRoleRequest request, CancellationToken cancellationToken)
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
