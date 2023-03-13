using OnlineMuhasebe.Application.Messaging;
using OnlineMuhasebe.Application.Services.AppServices;

namespace OnlineMuhasebe.Application.Features.AppFeatures.MainRoleFeatures.Commands.UpdateMainRole;

public sealed class UpdateMainRoleCommandHandler : ICommandHandler<UpdateMainRoleCommand, UpdateMainRoleCommandResponse>
{
    private readonly IMainRoleService MainRoleService;

    public UpdateMainRoleCommandHandler(IMainRoleService mainRoleService)
    {
        MainRoleService = mainRoleService;
    }

    public async Task<UpdateMainRoleCommandResponse> Handle(UpdateMainRoleCommand request, CancellationToken cancellationToken)
    {
        var mainRole = await MainRoleService.GetByIdAsync(request.Id);
        if (mainRole == null) throw new Exception("Ana rol bulunamadı!");

        if (mainRole.Title == request.Title) throw new Exception("Yeni rol adı eski rol adlarından farklı olmalıdır!");

        if (mainRole.Title == request.Title)
        {
            var mainRoleTitle = await MainRoleService.GetByTitleAndCompanyId(request.Title, mainRole.CompanyId);
            if (mainRoleTitle != null) throw new Exception("Bu rol adı daha önce kullanılmıştır!");
        }

        mainRole.Title = request.Title;
        await MainRoleService.UpdateAsync(mainRole, cancellationToken);
        return new();
    }
}
