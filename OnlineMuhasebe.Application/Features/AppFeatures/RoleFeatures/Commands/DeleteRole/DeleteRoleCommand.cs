using OnlineMuhasebe.Application.Messaging;

namespace OnlineMuhasebe.Application.Features.AppFeatures.RoleFeatures.Commands.DeleteRole;

public sealed record DeleteRoleCommand(
    string Id) : ICommand<DeleteRoleCommandResponse>;
