using Microsoft.EntityFrameworkCore;
using OnlineMuhasebe.Domain.AppEntities;
using OnlineMuhasebe.Domain.Abstractions;
using OnlineMuhasebe.Domain.AppEntities.Identities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace OnlineMuhasebe.Persistence.Context;

public sealed class AppDbContext : IdentityDbContext<AppUser, AppRole, string>
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Company> Companies { get; set; }
    public DbSet<AppUserCompany> AppUserCompanies { get; set; }

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

    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        private readonly AppDbContext AppDbContext;

        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder();
            var conStr = "Data Source=DESKTOP-4T5T21M;Initial Catalog=MuhasebeMasterDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            optionsBuilder.UseSqlServer(conStr);
            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
