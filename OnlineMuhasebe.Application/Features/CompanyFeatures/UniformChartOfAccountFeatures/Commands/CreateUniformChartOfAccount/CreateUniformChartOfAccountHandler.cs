using MediatR;
using OnlineMuhasebe.Application.Services.CompanyServices;

namespace OnlineMuhasebe.Application.Features.CompanyFeatures.UniformChartOfAccountFeatures.Commands.CreateUniformChartOfAccount;

public sealed class CreateUniformChartOfAccountHandler : IRequestHandler<CreateUniformChartOfAccountRequest, CreateUniformChartOfAccountResponse>
{
    private readonly IUniformChartOfAccountService Service;

    public CreateUniformChartOfAccountHandler(IUniformChartOfAccountService service)
    {
        Service = service;
    }

    public async Task<CreateUniformChartOfAccountResponse> Handle(CreateUniformChartOfAccountRequest request, CancellationToken cancellationToken)
    {
        await Service.CreateUniformChartOfAccountAsync(request);
        return new();
    }
}
