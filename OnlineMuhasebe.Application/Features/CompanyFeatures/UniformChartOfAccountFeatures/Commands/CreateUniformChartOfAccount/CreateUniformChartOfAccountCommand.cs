using OnlineMuhasebe.Application.Messaging;

namespace OnlineMuhasebe.Application.Features.CompanyFeatures.UniformChartOfAccountFeatures.Commands.CreateUniformChartOfAccount;

public sealed record CreateUniformChartOfAccountCommand(
    string CompanyId,
    string Code,
    string Name,
    string Type) : ICommand<CreateUniformChartOfAccountCommandResponse>;
