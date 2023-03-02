using OnlineMuhasebe.Application.Messaging;

namespace OnlineMuhasebe.Application.Features.CompanyFeatures.UniformChartOfAccountFeatures.Commands.CreateUniformChartOfAccount;

public sealed record CreateUniformChartOfAccount(
    string CompanyId,
    string Code,
    string Name,
    char Type) : ICommand<CreateUniformChartOfAccountCommandResponse>;
