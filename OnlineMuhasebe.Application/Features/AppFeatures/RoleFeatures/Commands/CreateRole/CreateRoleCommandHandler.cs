using OnlineMuhasebe.Application.Messaging;
using OnlineMuhasebe.Application.Services.AppServices;

namespace OnlineMuhasebe.Application.Features.AppFeatures.RoleFeatures.Commands.CreateRole;

public class CreateRoleCommandHandler : ICommandHandler<CreateRoleCommand, CreateRoleCompanyResponse>
{
    private readonly IRoleService RoleService;

    public CreateRoleCommandHandler(IRoleService roleService)
    {
        RoleService = roleService;
    }

    public async Task<CreateRoleCompanyResponse> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        var role = await RoleService.GetByCodeRoleAsync(request.Code);
        if (role != null) throw new Exception("Rol daha önce kayıt edilmiştir!");

        await RoleService.AddAsync(request);
        return new();
    }
}
