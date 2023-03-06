using Microsoft.EntityFrameworkCore;
using OnlineMuhasebe.Application.Messaging;
using OnlineMuhasebe.Application.Services.AppServices;

namespace OnlineMuhasebe.Application.Features.AppFeatures.CompanyFeatures.Queries.GetAllCompany;

public sealed class GetAllCompanyQueryHandler : IQueryHandler<GetAllCompanyQuery, GetAllCompanyQueryResponse>
{
    private readonly ICompanyService CompanyService;

    public GetAllCompanyQueryHandler(ICompanyService companyService)
    {
        CompanyService = companyService;
    }

    public async Task<GetAllCompanyQueryResponse> Handle(GetAllCompanyQuery request, CancellationToken cancellationToken)
    {
        var result = CompanyService.GetAll();
        return new(await result.ToListAsync());
    }
}
