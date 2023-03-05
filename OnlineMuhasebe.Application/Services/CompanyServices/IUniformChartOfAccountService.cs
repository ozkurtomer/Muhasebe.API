using OnlineMuhasebe.Domain.CompanyEntities;
using OnlineMuhasebe.Application.Features.CompanyFeatures.UniformChartOfAccountFeatures.Commands.CreateUniformChartOfAccount;

namespace OnlineMuhasebe.Application.Services.CompanyServices;

public interface IUniformChartOfAccountService
{
    Task<UniformChartOfAccount> GetByCodeAsync(string code);
    Task CreateUniformChartOfAccountAsync(CreateUniformChartOfAccountCommand request, CancellationToken token);
}
