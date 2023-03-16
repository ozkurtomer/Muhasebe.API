using OnlineMuhasebe.Application.Messaging;

namespace OnlineMuhasebe.Application.Features.AppFeatures.RoleMainRoleFeatures.Commands.CreateRoleMainRole;

public sealed record CreateRoleMainRoleCommand(
    string RoleId,
    string MainRoleId) : ICommand<CreateRoleMainRoleCommandResponse>;
