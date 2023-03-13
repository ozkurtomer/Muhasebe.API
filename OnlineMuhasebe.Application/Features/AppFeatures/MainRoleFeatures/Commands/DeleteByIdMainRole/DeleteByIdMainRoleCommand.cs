using OnlineMuhasebe.Application.Messaging;

namespace OnlineMuhasebe.Application.Features.AppFeatures.MainRoleFeatures.Commands.DeleteByIdMainRole;

public sealed record DeleteByIdMainRoleCommand(
    string Id) : ICommand<DeleteByIdMainRoleCommandResponse>;
