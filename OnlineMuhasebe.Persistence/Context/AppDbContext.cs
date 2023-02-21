using Microsoft.EntityFrameworkCore;
using OnlineMuhasebe.Domain.AppEntities;
using OnlineMuhasebe.Domain.AppEntities.Identities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace OnlineMuhasebe.Persistence.Context;

public sealed class AppDbContext : IdentityDbContext<AppUser, AppRole, string>
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Company> Companies { get; set; }
    public DbSet<AppUserCompany> AppUserCompanies { get; set; }

}
