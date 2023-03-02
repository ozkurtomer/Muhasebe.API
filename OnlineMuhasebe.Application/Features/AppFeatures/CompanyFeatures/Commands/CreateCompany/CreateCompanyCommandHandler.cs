using OnlineMuhasebe.Domain.AppEntities;
using OnlineMuhasebe.Application.Messaging;
using OnlineMuhasebe.Application.Services.AppServices;

namespace OnlineMuhasebe.Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany;

public sealed class CreateCompanyCommandHandler : ICommandHandler<CreateCompanyCommand, CreateCompanyCommandResponse>
{
    private readonly ICompanyService CompanyService;

    public CreateCompanyCommandHandler(ICompanyService companyService)
    {
        CompanyService = companyService;
    }

    public async Task<CreateCompanyCommandResponse> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
    {
        Company company = await CompanyService.GetCompanyByName(request.CompanyName);
        if (company != null) { throw new Exception("Girilen şirket adı daha önce kullanılmıştır!"); }

        await CompanyService.CreateCompany(request, cancellationToken);

        return new();
    }
}
