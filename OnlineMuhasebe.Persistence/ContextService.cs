using OnlineMuhasebe.Domain;
using Microsoft.EntityFrameworkCore;
using OnlineMuhasebe.Domain.AppEntities;
using OnlineMuhasebe.Persistence.Context;

namespace OnlineMuhasebe.Persistence;

public sealed class ContextService : IContextService
{
	private readonly AppDbContext AppDbContext;
	public ContextService(AppDbContext appDbContext)
	{
        AppDbContext = appDbContext;

    }

    public DbContext CreateDbContextInstance(string companyId)
    {
        Company company = AppDbContext.Set<Company>().Find(companyId);
        return new CompanyDbContext(company);
    }
}
