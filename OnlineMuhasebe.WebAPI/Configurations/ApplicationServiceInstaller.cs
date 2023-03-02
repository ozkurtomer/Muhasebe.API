using MediatR;
using FluentValidation;
using OnlineMuhasebe.Application;
using OnlineMuhasebe.Application.Behavior;

namespace OnlineMuhasebe.WebAPI.Configurations;

public class ApplicationServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection serviceDescriptors, IConfiguration configuration)
    {
        serviceDescriptors.AddMediatR(typeof(AssemblyReference).Assembly);

        serviceDescriptors.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        serviceDescriptors.AddValidatorsFromAssembly(typeof(AssemblyReference).Assembly);
    }
}
