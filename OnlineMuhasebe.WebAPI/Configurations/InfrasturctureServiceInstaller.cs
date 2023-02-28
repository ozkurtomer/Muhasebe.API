using OnlineMuhasebe.Application.Abstractions;
using OnlineMuhasebe.Infrasturcture.Authentications;

namespace OnlineMuhasebe.WebAPI.Configurations;

public class InfrasturctureServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection serviceDescriptors, IConfiguration configuration)
    {
        serviceDescriptors.AddScoped<IJwtProvider, JwtProvider>();
    }
}
