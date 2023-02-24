using MediatR;

namespace OnlineMuhasebe.Application.Features.CompanyFeatures.UniformChartOfAccountFeatures.Commands.CreateUniformChartOfAccount;

public sealed class CreateUniformChartOfAccountRequest : IRequest<CreateUniformChartOfAccountResponse>
{
    public string CompanyId { get; set; }

    public string Code { get; set; }

    public string Name { get; set; }

    public char Type { get; set; }
}
