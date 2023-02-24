using Microsoft.EntityFrameworkCore;

namespace OnlineMuhasebe.Domain;

public interface IUnitOfWork
{
    void SetDbContextInstance(DbContext dbContext);
    Task<int> SaveChangesAsync();
}
