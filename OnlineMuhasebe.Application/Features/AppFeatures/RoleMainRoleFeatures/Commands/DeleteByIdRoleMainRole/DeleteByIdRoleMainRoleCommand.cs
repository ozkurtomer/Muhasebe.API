using OnlineMuhasebe.Application.Messaging;

namespace OnlineMuhasebe.Application.Features.AppFeatures.RoleMainRoleFeatures.Commands.DeleteByIdRoleMainRole;

public sealed record DeleteByIdRoleMainRoleCommand(
    string id) : ICommand<DeleteByIdRoleMainRoleCommandResponse>;
