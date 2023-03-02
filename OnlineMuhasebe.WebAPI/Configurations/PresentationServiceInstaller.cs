using Microsoft.OpenApi.Models;
using OnlineMuhasebe.WebAPI.Middleware;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace OnlineMuhasebe.WebAPI.Configurations;

public class PresentationServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection serviceDescriptors, IConfiguration configuration)
    {
        serviceDescriptors.AddScoped<ExceptionMiddleware>();

        serviceDescriptors.AddControllers().AddApplicationPart(typeof(OnlineMuhasebe.Presentation.AssemblyReference).Assembly);

        serviceDescriptors.AddEndpointsApiExplorer();

        serviceDescriptors.AddSwaggerGen(setup =>
        {
            var jwtSecurityScheme = new OpenApiSecurityScheme
            {
                BearerFormat = "JWT",
                Name = "JWT Authentication",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = JwtBearerDefaults.AuthenticationScheme,
                Description = "Put **_ONLY_** yourt JWT Bearer token on textbox below'",
                Reference = new OpenApiReference
                {
                    Id = JwtBearerDefaults.AuthenticationScheme,
                    Type = ReferenceType.SecurityScheme
                }
            };
            setup.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);
            setup.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    jwtSecurityScheme, Array.Empty<string>() }
                });
        });
    }
}
