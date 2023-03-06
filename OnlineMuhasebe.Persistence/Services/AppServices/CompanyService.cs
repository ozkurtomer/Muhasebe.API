using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineMuhasebe.Domain.AppEntities;
using OnlineMuhasebe.Domain.UnitOfWorks;
using OnlineMuhasebe.Persistence.Context;
using OnlineMuhasebe.Application.Services.AppServices;
using OnlineMuhasebe.Domain.Repositories.AppDbContextRepositories.CompanyRepositories;
using OnlineMuhasebe.Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany;
using OnlineMuhasebe.Application.Features.AppFeatures.CompanyFeatures.Commands.MigrateCompanyDb;

namespace OnlineMuhasebe.Persistence.Services.AppServices;

public sealed class CompanyService : ICompanyService
{
    private readonly IMapper Mapper;
    private readonly IAppUnitOfWork AppUnitOfWork;
    private readonly ICompanyQueryRepository CompanyQueryRepository;
    private readonly ICompanyCommandRepository CompanyCommandRepository;

    public CompanyService(IMapper mapper, IAppUnitOfWork appUnitOfWork, ICompanyQueryRepository companyQueryRepository, ICompanyCommandRepository companyCommandRepository)
    {
        Mapper = mapper;
        AppUnitOfWork = appUnitOfWork;
        CompanyQueryRepository = companyQueryRepository;
        CompanyCommandRepository = companyCommandRepository;
    }

    public async Task CreateCompany(CreateCompanyCommand createCompanyRequest, CancellationToken token)
    {
        Company company = Mapper.Map<Company>(createCompanyRequest);
        company.Id = Guid.NewGuid().ToString();
        await CompanyCommandRepository.AddAsync(company, token);
        await AppUnitOfWork.SaveChangesAsync(token);
    }

    public async Task<Company?> GetCompanyByName(string companyName)
    {
        return await CompanyQueryRepository.GetFirstByExpression(x => x.CompanyName == companyName, default);
    }

    public async Task MigrateCompanyDbs(MigrateCompanyDbCommand migrateCompanyDbRequest)
    {
        var companies = await CompanyQueryRepository.GetAll().ToListAsync();
        foreach (var company in companies)
        {
            var db = new CompanyDbContext(company);
            db.Database.Migrate();
        }
    }
}
