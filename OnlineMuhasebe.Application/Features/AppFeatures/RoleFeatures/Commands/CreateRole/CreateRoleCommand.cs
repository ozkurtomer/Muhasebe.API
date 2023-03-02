using OnlineMuhasebe.Application.Messaging;

namespace OnlineMuhasebe.Application.Features.AppFeatures.RoleFeatures.Commands.CreateRole;

public sealed record CreateRoleCommand(
    string Code,
    string Name) : ICommand<CreateRoleCompanyResponse>;
