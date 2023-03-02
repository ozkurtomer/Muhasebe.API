using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Design;
using OnlineMuhasebe.Domain.Abstractions;
using OnlineMuhasebe.Domain.AppEntities;

namespace OnlineMuhasebe.Persistence.Context;

public sealed class CompanyDbContext : DbContext
{
    private string ConnectionString = string.Empty;

    public CompanyDbContext(Company company = null)
    {
        if (company != null)
        {
            if (string.IsNullOrEmpty(company.CompanyServerId))
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
                                  User Id={company.CompanyServerId};
                                  Password={company.CompanyServerPassword};
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

    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker.Entries<Entity>();

        foreach (var entry in entries)
        {
            if (entry.State == EntityState.Added)
            {
                entry.Property(x => x.Id).CurrentValue = Guid.NewGuid().ToString();
                entry.Property(x => x.CreatedDate).CurrentValue = DateTime.Now;
            }
            if (entry.State == EntityState.Modified)
            {
                entry.Property(x => x.UpdatedDate).CurrentValue = DateTime.Now;
            }
        }
        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) => modelBuilder.ApplyConfigurationsFromAssembly(typeof(AssemblyReference).Assembly);

    public class CompanyDbContextFactory : IDesignTimeDbContextFactory<CompanyDbContext>
    {
        private readonly AppDbContext AppDbContext;

        public CompanyDbContext CreateDbContext(string[] args)
        {
            return new CompanyDbContext();
        }
    }
}
