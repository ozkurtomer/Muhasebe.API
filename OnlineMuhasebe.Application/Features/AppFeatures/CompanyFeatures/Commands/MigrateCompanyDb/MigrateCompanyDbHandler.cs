using MediatR;
using OnlineMuhasebe.Application.Services.AppServices;

namespace OnlineMuhasebe.Application.Features.AppFeatures.CompanyFeatures.Commands.MigrateCompanyDb;

public class MigrateCompanyDbHandler : IRequestHandler<MigrateCompanyDbRequest, MigrateCompanyDbResponse>
{
    private readonly ICompanyService CompanyService;

    public MigrateCompanyDbHandler(ICompanyService companyService)
    {
        CompanyService = companyService;
    }

    public async Task<MigrateCompanyDbResponse> Handle(MigrateCompanyDbRequest request, CancellationToken cancellationToken)
    {
        await CompanyService.MigrateCompanyDbs(request);
        return new();
    }
}
