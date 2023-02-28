using OnlineMuhasebe.WebAPI.OptionsSetup;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace OnlineMuhasebe.WebAPI.Configurations;

public class AuthenticationAndAuthorizationServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection serviceDescriptors, IConfiguration configuration)
    {
        serviceDescriptors.ConfigureOptions<JwtOptionsSetup>();

        serviceDescriptors.ConfigureOptions<JwtBearerOptionsSetup>();

        serviceDescriptors.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer();

        serviceDescriptors.AddAuthorization();
    }
}
