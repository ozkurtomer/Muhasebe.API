using OnlineMuhasebe.Domain.AppEntities;
using OnlineMuhasebe.Application.Messaging;
using OnlineMuhasebe.Application.Services.AppServices;
using OnlineMuhasebe.Application.Features.AppFeatures.MainRoleFeatures.Commands.CreateRole;

namespace OnlineMuhasebe.Application.Features.AppFeatures.MainRoleFeatures.Commands.CreateMainRole;

public sealed class CreateMainRoleCommandHandler : ICommandHandler<CreateMainRoleCommand, CreateMainRoleCommandResponse>
{
    private readonly IMainRoleService MainRoleService;

    public CreateMainRoleCommandHandler(IMainRoleService mainRoleService)
    {
        MainRoleService = mainRoleService;
    }

    public async Task<CreateMainRoleCommandResponse> Handle(CreateMainRoleCommand request, CancellationToken cancellationToken)
    {
        MainRole checkMainRole = await MainRoleService.GetByTitleAndCompanyId(request.Title, request.CompanyId, cancellationToken);
        if (checkMainRole != null) throw new Exception("Bu rol daha önce eklenmiştir!");

        MainRole mainRole = new(Guid.NewGuid().ToString(),
                                request.Title,
                                request.CompanyId,
                                request.IsRoleCreatedByAdmin);

        await MainRoleService.CreateAsync(mainRole, cancellationToken);
        return new();
    }
}
