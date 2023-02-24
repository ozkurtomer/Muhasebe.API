using Microsoft.EntityFrameworkCore;

namespace OnlineMuhasebe.Domain;

public interface IContextService
{
    DbContext CreateDbContextInstance(string companyId);
}
