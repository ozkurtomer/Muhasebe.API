using OnlineMuhasebe.Domain;
using Microsoft.EntityFrameworkCore;
using OnlineMuhasebe.Persistence.Context;

namespace OnlineMuhasebe.Persistence;

public sealed class UnitOfWork : IUnitOfWork
{
    private CompanyDbContext DbContext;

    public void SetDbContextInstance(DbContext dbContext)
    {
        DbContext = (CompanyDbContext)dbContext;
    }

    public async Task<int> SaveChangesAsync()
    {
        return await DbContext.SaveChangesAsync();
    }
}
