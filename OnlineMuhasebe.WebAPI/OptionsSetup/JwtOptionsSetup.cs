using Microsoft.Extensions.Options;
using OnlineMuhasebe.Infrasturcture.Authentications;

namespace OnlineMuhasebe.WebAPI.OptionsSetup;

public sealed class JwtOptionsSetup : IConfigureOptions<JwtOptions>
{
    public const string Jwt = nameof(Jwt);
    private readonly IConfiguration Configuration;
    public JwtOptionsSetup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void Configure(JwtOptions options)
    {
        Configuration.GetSection(Jwt).Bind(options);
    }
}
