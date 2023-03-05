using Microsoft.EntityFrameworkCore;

namespace OnlineMuhasebe.Domain.UnitOfWorks;

public interface ICompanyDbUnitOfWork : IUnitOfWork
{
    void SetDbContextInstance(DbContext dbContext);
}
