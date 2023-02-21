using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using OnlineMuhasebe.Domain.AppEntities;

namespace OnlineMuhasebe.Persistence.Context;

public sealed class CompanyDbContext : DbContext
{
    private string ConnectionString = string.Empty;

    public CompanyDbContext(string companyId, Company company = null)
    {
        if (company != null)
        {
            if (string.IsNullOrEmpty(company.CompanyUserId))
            {
                ConnectionString = $@"Data Source={company.CompanyServerName};
                                  Initial Catalog={company.CompanyDatabaseName};
                                  Integrated Security=True;
                                  Connect Timeout=30;
                                  Encrypt=False;
                                  TrustServerCertificate=False;
                                  ApplicationIntent=ReadWrite;
                                  MultiSubnetFailover=False";
            }
            else
            {
                ConnectionString = $@"Data Source={company.CompanyServerName};
                                  Initial Catalog={company.CompanyDatabaseName};
                                  User Id={company.CompanyUserId};
                                  Password={company.CompanyPassword};
                                  Integrated Security=True;
                                  Connect Timeout=30;
                                  Encrypt=False;
                                  TrustServerCertificate=False;
                                  ApplicationIntent=ReadWrite;
                                  MultiSubnetFailover=False";
            }
        }
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(ConnectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) => modelBuilder.ApplyConfigurationsFromAssembly(typeof(AssemblyReference).Assembly);

    public class CompanyDbContextFactory : IDesignTimeDbContextFactory<CompanyDbContext>
    {
        private readonly AppDbContext AppDbContext;

        public CompanyDbContext CreateDbContext(string[] args)
        {
            return new CompanyDbContext("");
        }
    }
}
