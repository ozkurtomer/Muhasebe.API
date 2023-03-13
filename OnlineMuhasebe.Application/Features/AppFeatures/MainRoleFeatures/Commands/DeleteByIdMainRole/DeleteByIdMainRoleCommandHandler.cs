using OnlineMuhasebe.Application.Messaging;
using OnlineMuhasebe.Application.Services.AppServices;

namespace OnlineMuhasebe.Application.Features.AppFeatures.MainRoleFeatures.Commands.DeleteByIdMainRole;

public sealed class DeleteByIdMainRoleCommandHandler : ICommandHandler<DeleteByIdMainRoleCommand, DeleteByIdMainRoleCommandResponse>
{
    private readonly IMainRoleService MainRoleService;

    public DeleteByIdMainRoleCommandHandler(IMainRoleService mainRoleService)
    {
        MainRoleService = mainRoleService;
    }

    public async Task<DeleteByIdMainRoleCommandResponse> Handle(DeleteByIdMainRoleCommand request, CancellationToken cancellationToken)
    {
        await MainRoleService.DeleteByIdAsync(request.Id);
        return new();
    }
}
