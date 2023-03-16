using OnlineMuhasebe.Domain.AppEntities;
using OnlineMuhasebe.Application.Messaging;
using OnlineMuhasebe.Application.Services.AppServices;

namespace OnlineMuhasebe.Application.Features.AppFeatures.RoleMainRoleFeatures.Commands.CreateRoleMainRole;

public sealed class CreateRoleMainRoleCommandHandler : ICommandHandler<CreateRoleMainRoleCommand, CreateRoleMainRoleCommandResponse>
{
    private readonly IRoleMainRoleService RoleMainRoleService;

    public CreateRoleMainRoleCommandHandler(IRoleMainRoleService roleMainRoleService)
    {
        RoleMainRoleService = roleMainRoleService;
    }

    public async Task<CreateRoleMainRoleCommandResponse> Handle(CreateRoleMainRoleCommand request, CancellationToken cancellationToken)
    {
        var checkRoleMainRole = await RoleMainRoleService.GetByRoleIdMainRoleId(request.RoleId, request.MainRoleId, cancellationToken);
        if (checkRoleMainRole != null) throw new Exception("Eklemek istediğiniz rol ilişkisi mevcuttur!");

        RoleMainRole roleMainRole = new(Guid.NewGuid().ToString(), request.RoleId, request.MainRoleId);
        await RoleMainRoleService.CreateAsync(roleMainRole, cancellationToken);
        return new();
    }
}
