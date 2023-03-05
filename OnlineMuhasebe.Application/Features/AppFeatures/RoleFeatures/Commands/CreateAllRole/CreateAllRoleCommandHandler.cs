using OnlineMuhasebe.Domain.Roles;
using OnlineMuhasebe.Application.Messaging;
using OnlineMuhasebe.Domain.AppEntities.Identities;
using OnlineMuhasebe.Application.Services.AppServices;

namespace OnlineMuhasebe.Application.Features.AppFeatures.RoleFeatures.Commands.CreateAllRole;

public sealed class CreateAllRoleCommandHandler : ICommandHandler<CreateAllRoleCommand, CreateAllRoleCommandResponse>
{
    private readonly IRoleService RoleService;

    public CreateAllRoleCommandHandler(IRoleService roleService)
    {
        RoleService = roleService;
    }

    public async Task<CreateAllRoleCommandResponse> Handle(CreateAllRoleCommand request, CancellationToken cancellationToken)
    {
        IList<AppRole> originalRoles = RoleList.GetStaticRoles();
        List<AppRole> currentRoles = new List<AppRole>();

        foreach (var item in originalRoles)
        {
            var role = await RoleService.GetByCodeRoleAsync(item.Code);
            if (role == null) currentRoles.Add(item);
        }
        await RoleService.AddRangeAsync(currentRoles);
        return new();
    }
}
