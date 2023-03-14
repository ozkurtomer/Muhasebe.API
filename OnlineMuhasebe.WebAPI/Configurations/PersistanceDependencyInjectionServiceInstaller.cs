using OnlineMuhasebe.Domain;
using OnlineMuhasebe.Persistence;
using OnlineMuhasebe.Domain.UnitOfWorks;
using OnlineMuhasebe.Persistence.UnitOfWorks;
using OnlineMuhasebe.Application.Services.AppServices;
using OnlineMuhasebe.Persistence.Services.AppServices;
using OnlineMuhasebe.Application.Services.CompanyServices;
using OnlineMuhasebe.Persistence.Services.CompanyServices;
using OnlineMuhasebe.Domain.Repositories.AppDbContext.AppUserCompanyRepositories;
using OnlineMuhasebe.Domain.Repositories.AppDbContextRepositories.CompanyRepositories;
using OnlineMuhasebe.Domain.Repositories.AppDbContextRepositories.MainRoleRepositories;
using OnlineMuhasebe.Persistence.Repositories.AppDbContextRepositories.CompanyRepositories;
using OnlineMuhasebe.Persistence.Repositories.AppDbContextRepositories.MainRoleRepositories;
using OnlineMuhasebe.Domain.Repositories.CompanyDbContextRepositories.UniformChartOfAccountRepositories;
using OnlineMuhasebe.Persistence.Repositories.AppDbContextRepositories.AppUserCompanyCommandRepositories;
using OnlineMuhasebe.Persistence.Repositories.CompanyDbContextRepositories.UniformCharOfAccountRepositories;
using OnlineMuhasebe.Domain.Repositories.AppDbContext.RoleMainRoleRepositories;
using OnlineMuhasebe.Persistance.Repositories.AppDbContext.RoleMainRoleRepositories;
//UsingSpot

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
        //CompanyServiceDISpot
        #endregion

        #region AppDbContext
        serviceDescriptors.AddScoped<ICompanyService, CompanyService>();
        serviceDescriptors.AddScoped<IRoleService, RoleService>();
        serviceDescriptors.AddScoped<IMainRoleService, MainRoleService>();

        serviceDescriptors.AddScoped<IAppUserCompanyService, AppUserCompanyService>();
                services.AddScoped<IRoleMainRoleService, RoleMainRoleService>();
        //AppServiceDISpot
        #endregion
        #endregion

        #region Repositories
        #region CompanyDbContext
        serviceDescriptors.AddScoped<IUniformChartOfAccountCommandRepository, UniformChartOfAccountCommandRepository>();
        serviceDescriptors.AddScoped<IUniformChartOfAccountQueryRepository, UniformChartOfAccountQueryRepository>();
        //CompanyRepositoryDISpot
        #endregion


        #region AppDbContext
        serviceDescriptors.AddScoped<ICompanyCommandRepository, CompanyCommandRepository>();
        serviceDescriptors.AddScoped<ICompanyQueryRepository, CompanyQueryRepository>();
        serviceDescriptors.AddScoped<IMainRoleCommandRepository, MainRoleCommandRepository>();
        serviceDescriptors.AddScoped<IMainRoleQueryRepository, MainRoleQueryRepository>();
        serviceDescriptors.AddScoped<IAppUserCompanyCommandRepository, AppUserCompanyCommandRepository>();
        serviceDescriptors.AddScoped<IAppUserCompanyQueryRepository, AppUserCompanyQueryRepository>();
                services.AddScoped<IRoleMainRoleCommandRepository, RoleMainRoleCommandRepository>();
                services.AddScoped<IRoleMainRoleQueryRepository, RoleMainRoleQueryRepository>();
        //AppRepositoryDISpot
        #endregion
        #endregion
    }
}
