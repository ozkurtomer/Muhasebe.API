using OnlineMuhasebe.Application.Messaging;
using OnlineMuhasebe.Domain.CompanyEntities;
using OnlineMuhasebe.Application.Services.CompanyServices;

namespace OnlineMuhasebe.Application.Features.CompanyFeatures.UniformChartOfAccountFeatures.Commands.CreateUniformChartOfAccount;

public sealed class CreateUniformChartOfAccountCommandHandler : ICommandHandler<CreateUniformChartOfAccountCommand, CreateUniformChartOfAccountCommandResponse>
{
    private readonly IUniformChartOfAccountService UniformChartOfAccountService;

    public CreateUniformChartOfAccountCommandHandler(IUniformChartOfAccountService uniformChartOfAccountService)
    {
        UniformChartOfAccountService = uniformChartOfAccountService;
    }

    public async Task<CreateUniformChartOfAccountCommandResponse> Handle(CreateUniformChartOfAccountCommand request, CancellationToken cancellationToken)
    {
        UniformChartOfAccount uniformChartOfAccount = await UniformChartOfAccountService.GetByCodeAsync(request.Code);
        if (uniformChartOfAccount != null) throw new Exception("Bu hesap planı kodu daha önce tanımlanmıştır!");

        await UniformChartOfAccountService.CreateUniformChartOfAccountAsync(request, cancellationToken);
        return new();
    }
}
