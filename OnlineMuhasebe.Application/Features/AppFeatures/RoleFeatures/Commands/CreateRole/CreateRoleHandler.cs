using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineMuhasebe.Domain.AppEntities.Identities;

namespace OnlineMuhasebe.Application.Features.AppFeatures.RoleFeatures.Commands.CreateRole;

public class CreateRoleHandler : IRequestHandler<CreateRoleRequest, CreateRoleResponse>
{
    private readonly RoleManager<AppRole> RoleManager;

    public CreateRoleHandler(RoleManager<AppRole> roleManager)
    {
        RoleManager = roleManager;
    }

    public async Task<CreateRoleResponse> Handle(CreateRoleRequest request, CancellationToken cancellationToken)
    {
        var role = await RoleManager.Roles.Where(x => x.Code == request.Code).FirstOrDefaultAsync();
        if (role != null) throw new Exception("Rol daha önce kayıt edilmiştir!");

        role = new AppRole()
        {
            Id = Guid.NewGuid().ToString(),
            Name = request.Name,
            Code = request.Code
        };

        await RoleManager.CreateAsync(role);
        return new();
    }
}
