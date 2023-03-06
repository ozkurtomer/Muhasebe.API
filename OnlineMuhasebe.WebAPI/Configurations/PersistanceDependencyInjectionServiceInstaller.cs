using OnlineMuhasebe.Domain;
using OnlineMuhasebe.Persistence;
using OnlineMuhasebe.Domain.UnitOfWorks;
using OnlineMuhasebe.Persistence.UnitOfWorks;
using OnlineMuhasebe.Application.Services.AppServices;
using OnlineMuhasebe.Persistence.Services.AppServices;
using OnlineMuhasebe.Application.Services.CompanyServices;
using OnlineMuhasebe.Persistence.Services.CompanyServices;
using OnlineMuhasebe.Domain.Repositories.AppDbContextRepositories.CompanyRepositories;
using OnlineMuhasebe.Domain.Repositories.AppDbContextRepositories.MainRoleRepositories;
using OnlineMuhasebe.Persistence.Repositories.AppDbContextRepositories.CompanyRepositories;
using OnlineMuhasebe.Persistence.Repositories.AppDbContextRepositories.MainRoleRepositories;
using OnlineMuhasebe.Domain.Repositories.CompanyDbContextRepositories.UniformChartOfAccountRepositories;
using OnlineMuhasebe.Persistence.Repositories.CompanyDbContextRepositories.UniformCharOfAccountRepositories;

namespace OnlineMuhasebe.WebAPI.Configurations;

public class PersistanceDependencyInjectionServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection serviceDescriptors, IConfiguration configuration)
    {
        #region UOF
        serviceDescriptors.AddScoped<ICompanyDbUnitOfWork, CompanyDbUnitOfWork>();
        serviceDescriptors.AddScoped<IAppUnitOfWork, AppUnitOfWork>();
        serviceDescriptors.AddScoped<IContextService, ContextService>();
        #endregion

        #region Services
        #region CompanyDbContext
        serviceDescriptors.AddScoped<IUniformChartOfAccountService, UniformChartOfAccountService>();
        #endregion

        #region AppDbContext
        serviceDescriptors.AddScoped<ICompanyService, CompanyService>();
        serviceDescriptors.AddScoped<IRoleService, RoleService>();
        serviceDescriptors.AddScoped<IMainRoleService, MainRoleService>();
        #endregion
        #endregion

        #region Repositories
        #region CompanyDbContext
        serviceDescriptors.AddScoped<IUniformChartOfAccountCommandRepository, UniformChartOfAccountCommandRepository>();
        serviceDescriptors.AddScoped<IUniformChartOfAccountQueryRepository, UniformChartOfAccountQueryRepository>();
        #endregion


        #region AppDbContext
        serviceDescriptors.AddScoped<ICompanyCommandRepository, CompanyCommandRepository>();
        serviceDescriptors.AddScoped<ICompanyQueryRepository, CompanyQueryRepository>();
        serviceDescriptors.AddScoped<IMainRoleCommandRepository, MainRoleCommandRepository>();
        serviceDescriptors.AddScoped<IMainRoleQueryRepository, MainRoleQueryRepository>();
        #endregion
        #endregion
    }
}
