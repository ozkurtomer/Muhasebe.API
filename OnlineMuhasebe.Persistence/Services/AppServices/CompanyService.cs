using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineMuhasebe.Domain.AppEntities;
using OnlineMuhasebe.Persistence.Context;
using OnlineMuhasebe.Application.Services.AppServices;
using OnlineMuhasebe.Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany;
using OnlineMuhasebe.Application.Features.AppFeatures.CompanyFeatures.Commands.MigrateCompanyDb;

namespace OnlineMuhasebe.Persistence.Services.AppServices;

public sealed class CompanyService : ICompanyService
{
    private static readonly Func<AppDbContext, string, Task<Company?>> GetCompanyByNameCompiled = EF.CompileAsyncQuery((AppDbContext context, string name) =>
        context.Set<Company>().FirstOrDefault(x => x.CompanyName == name)
    );

    private readonly AppDbContext AppDbContext;
    private readonly IMapper Mapper;

    public CompanyService(AppDbContext appDbContext, IMapper mapper)
    {
        AppDbContext = appDbContext;
        Mapper = mapper;
    }

    public async Task CreateCompany(CreateCompanyRequest createCompanyRequest)
    {
        Company company = Mapper.Map<Company>(createCompanyRequest);
        company.Id = Guid.NewGuid().ToString();
        await AppDbContext.Set<Company>().AddAsync(company);
        await AppDbContext.SaveChangesAsync();
    }

    public async Task<Company?> GetCompanyByName(string companyName)
    {
        return await GetCompanyByNameCompiled(AppDbContext, companyName);
    }

    public async Task MigrateCompanyDbs(MigrateCompanyDbRequest migrateCompanyDbRequest)
    {
        var companies = await AppDbContext.Companies.ToListAsync();
        foreach (var company in companies)
        {
            var db = new CompanyDbContext(company);
            db.Database.Migrate();
        }
    }
}
