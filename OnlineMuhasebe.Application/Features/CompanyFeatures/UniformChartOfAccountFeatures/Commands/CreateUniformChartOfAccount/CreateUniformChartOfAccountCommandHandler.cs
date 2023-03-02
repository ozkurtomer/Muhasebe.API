using OnlineMuhasebe.Application.Messaging;
using OnlineMuhasebe.Application.Services.CompanyServices;

namespace OnlineMuhasebe.Application.Features.CompanyFeatures.UniformChartOfAccountFeatures.Commands.CreateUniformChartOfAccount;

public sealed class CreateUniformChartOfAccountCommandHandler : ICommandHandler<CreateUniformChartOfAccountCommand, CreateUniformChartOfAccountCommandResponse>
{
    private readonly IUniformChartOfAccountService Service;

    public CreateUniformChartOfAccountCommandHandler(IUniformChartOfAccountService service)
    {
        Service = service;
    }

    public async Task<CreateUniformChartOfAccountCommandResponse> Handle(CreateUniformChartOfAccountCommand request, CancellationToken cancellationToken)
    {
        await Service.CreateUniformChartOfAccountAsync(request, cancellationToken);
        return new();
    }
}
