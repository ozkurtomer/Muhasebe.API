using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineMuhasebe.Domain.AppEntities.Identities;

namespace OnlineMuhasebe.Application.Features.AppFeatures.RoleFeatures.Commands.UpdateRole;

public sealed class UpdateRoleHandler : IRequestHandler<UpdateRoleRequest, UpdateRoleResponse>
{
    private readonly RoleManager<AppRole> RoleManager;

    public UpdateRoleHandler(RoleManager<AppRole> roleManager)
    {
        RoleManager = roleManager;
    }

    public async Task<UpdateRoleResponse> Handle(UpdateRoleRequest request, CancellationToken cancellationToken)
    {
        var role = await RoleManager.FindByIdAsync(request.Id);
        if (role == null) throw new Exception("Rol bulunamadı!");

        if(role.Code != request.Code)
        {
            var checkCode = await RoleManager.Roles.FirstOrDefaultAsync(x=>x.Equals(role.Code));
            if (checkCode != null) throw new Exception("Girdiğiniz kod daha önce kaydedilmiştir!");
        }

        role.Code= request.Code;
        role.Name = request.Name;
        await RoleManager.UpdateAsync(role);

        return new();
    }
}
