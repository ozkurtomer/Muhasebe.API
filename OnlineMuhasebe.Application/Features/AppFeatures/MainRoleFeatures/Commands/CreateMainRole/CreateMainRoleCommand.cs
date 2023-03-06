using OnlineMuhasebe.Application.Messaging;
using OnlineMuhasebe.Application.Features.AppFeatures.MainRoleFeatures.Commands.CreateMainRole;

namespace OnlineMuhasebe.Application.Features.AppFeatures.MainRoleFeatures.Commands.CreateRole;

public sealed record CreateMainRoleCommand(
    string Title,
    bool IsRoleCreatedByAdmin = false,
    string CompanyId = null) : ICommand<CreateMainRoleResponse>;
