using MediatR;
using OnlineMuhasebe.Domain.AppEntities;
using OnlineMuhasebe.Application.Services.AppServices;

namespace OnlineMuhasebe.Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany;

public sealed class CreateCompanyHandler : IRequestHandler<CreateCompanyRequest, CreateCompanyResponse>
{
    private readonly ICompanyService CompanyService;

    public CreateCompanyHandler(ICompanyService companyService)
    {
        CompanyService = companyService;
    }

    public async Task<CreateCompanyResponse> Handle(CreateCompanyRequest request, CancellationToken cancellationToken)
    {
        Company company = await CompanyService.GetCompanyByName(request.CompanyName);
        if (company != null) { throw new Exception("Girilen şirket adı daha önce kullanılmıştır!"); }

        await CompanyService.CreateCompany(request);

        return new();
    }
}
