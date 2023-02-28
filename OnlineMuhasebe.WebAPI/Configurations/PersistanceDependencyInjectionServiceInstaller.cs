using OnlineMuhasebe.Domain;
using OnlineMuhasebe.Persistence;
using OnlineMuhasebe.Application.Services.AppServices;
using OnlineMuhasebe.Persistence.Services.AppServices;
using OnlineMuhasebe.Application.Services.CompanyServices;
using OnlineMuhasebe.Persistence.Services.CompanyServices;
using OnlineMuhasebe.Domain.Repositories.UniformChartOfAccountRepositories;
using OnlineMuhasebe.Persistence.Repositories.UniformCharOfAccountRepositories;

namespace OnlineMuhasebe.WebAPI.Configurations;

public class PersistanceDependencyInjectionServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection serviceDescriptors, IConfiguration configuration)
    {
        #region UOF
        serviceDescriptors.AddScoped<IUnitOfWork, UnitOfWork>();
        serviceDescriptors.AddScoped<IContextService, ContextService>();
        #endregion

        #region Services
        serviceDescriptors.AddScoped<ICompanyService, CompanyService>();
        serviceDescriptors.AddScoped<IUniformChartOfAccountService, UniformChartOfAccountService>();
        serviceDescriptors.AddScoped<IRoleService, RoleService>();

        #endregion

        #region Repositories
        serviceDescriptors.AddScoped<IUniformChartOfAccountCommandRepository, UniformChartOfAccountCommandRepository>();
        serviceDescriptors.AddScoped<IUniformChartOfAccountQueryRepository, UniformChartOfAccountQueryRepository>();
        #endregion
    }
}
