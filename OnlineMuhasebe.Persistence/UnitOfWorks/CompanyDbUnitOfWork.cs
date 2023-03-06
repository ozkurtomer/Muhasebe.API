using Microsoft.EntityFrameworkCore;
using OnlineMuhasebe.Persistence.Context;
using OnlineMuhasebe.Domain.UnitOfWorks;

namespace OnlineMuhasebe.Persistence.UnitOfWorks;

public sealed class CompanyDbUnitOfWork : ICompanyDbUnitOfWork
{
    private CompanyDbContext DbContext;

    public void SetDbContextInstance(DbContext dbContext)
    {
        DbContext = (CompanyDbContext)dbContext;
    }

    public async Task<int> SaveChangesAsync(CancellationToken token = default)
    {
        return await DbContext.SaveChangesAsync(token);
    }
}
