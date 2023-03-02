using OnlineMuhasebe.Application.Features.CompanyFeatures.UniformChartOfAccountFeatures.Commands.CreateUniformChartOfAccount;

namespace OnlineMuhasebe.Application.Services.CompanyServices;

public interface IUniformChartOfAccountService
{
    Task CreateUniformChartOfAccountAsync(CreateUniformChartOfAccount request, CancellationToken token);
}
