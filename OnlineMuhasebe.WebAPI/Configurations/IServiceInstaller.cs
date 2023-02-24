namespace OnlineMuhasebe.WebAPI.Configurations;

public interface IServiceInstaller
{
    void Install(IServiceCollection serviceDescriptors, IConfiguration configuration);
}
