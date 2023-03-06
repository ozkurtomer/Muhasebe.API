using OnlineMuhasebe.Domain.AppEntities;

namespace OnlineMuhasebe.Application.Features.AppFeatures.CompanyFeatures.Queries.GetAllCompany;

public sealed record GetAllCompanyQueryResponse(
    IList<Company> Companies);
