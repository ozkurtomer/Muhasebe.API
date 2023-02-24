using OnlineMuhasebe.Persistence;
using Microsoft.EntityFrameworkCore;
using OnlineMuhasebe.Persistence.Context;
using OnlineMuhasebe.Domain.AppEntities.Identities;

namespace OnlineMuhasebe.WebAPI.Configurations;

public class PersitenceServiceInstaller : IServiceInstaller
{
    private const string SectionName = "SqlServer";

    public void Install(IServiceCollection serviceDescriptors, IConfiguration configuration)
    {
        serviceDescriptors.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString(SectionName));
        });
        serviceDescriptors.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<AppDbContext>();


        serviceDescriptors.AddAutoMapper(typeof(AssemblyReference).Assembly);
    }
}
