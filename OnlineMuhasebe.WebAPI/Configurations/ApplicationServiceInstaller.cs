using MediatR;
using OnlineMuhasebe.Application;

namespace OnlineMuhasebe.WebAPI.Configurations;

public class ApplicationServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection serviceDescriptors, IConfiguration configuration)
    {
        serviceDescriptors.AddMediatR(typeof(AssemblyReference).Assembly);
    }
}
