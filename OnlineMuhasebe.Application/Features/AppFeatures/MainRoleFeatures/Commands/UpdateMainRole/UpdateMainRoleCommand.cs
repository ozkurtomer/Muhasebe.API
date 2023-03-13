using OnlineMuhasebe.Application.Messaging;
using OnlineMuhasebe.Domain.AppEntities;

namespace OnlineMuhasebe.Application.Features.AppFeatures.MainRoleFeatures.Commands.UpdateMainRole;

public sealed record UpdateMainRoleCommand(
    string Id,
    string Title) : ICommand<UpdateMainRoleCommandResponse>;
