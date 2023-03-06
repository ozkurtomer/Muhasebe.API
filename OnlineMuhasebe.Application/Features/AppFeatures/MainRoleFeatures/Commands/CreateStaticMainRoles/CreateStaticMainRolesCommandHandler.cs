using OnlineMuhasebe.Domain.Roles;
using OnlineMuhasebe.Domain.AppEntities;
using OnlineMuhasebe.Application.Messaging;
using OnlineMuhasebe.Application.Services.AppServices;

namespace OnlineMuhasebe.Application.Features.AppFeatures.MainRoleFeatures.Commands.CreateStaticMainRoles;

public sealed class CreateStaticMainRolesCommandHandler : ICommandHandler<CreateStaticMainRolesCommand, CreateStaticMainRolesCommandResponse>
{
    private readonly IMainRoleService MainRoleService;
    public async Task<CreateStaticMainRolesCommandResponse> Handle(CreateStaticMainRolesCommand request, CancellationToken cancellationToken)
    {
        List<MainRole> mainRoles = RoleList.GetStaticMainRoles();
        List<MainRole> createMainRoles = new List<MainRole>();
        foreach (var item in mainRoles)
        {
            MainRole checkMainRole = await MainRoleService.GetByTitleAndCompanyId(item.Title, item.CompanyId, cancellationToken);
            if (checkMainRole == null) createMainRoles.Add(item);
        }

        await MainRoleService.CreateRangeAsync(createMainRoles, cancellationToken);
        return new();
    }
}
