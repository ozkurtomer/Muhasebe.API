using MediatR;
using OnlineMuhasebe.Application.Services.AppServices;

namespace OnlineMuhasebe.Application.Features.AppFeatures.RoleFeatures.Commands.CreateRole;

public class CreateRoleHandler : IRequestHandler<CreateRoleRequest, CreateRoleResponse>
{
    private readonly IRoleService RoleService;

    public CreateRoleHandler(IRoleService roleService)
    {
        RoleService = roleService;
    }

    public async Task<CreateRoleResponse> Handle(CreateRoleRequest request, CancellationToken cancellationToken)
    {
        var role = await RoleService.GetByCodeRoleAsync(request.Code);
        if (role != null) throw new Exception("Rol daha önce kayıt edilmiştir!");

        await RoleService.AddAsync(request);
        return new();
    }
}
