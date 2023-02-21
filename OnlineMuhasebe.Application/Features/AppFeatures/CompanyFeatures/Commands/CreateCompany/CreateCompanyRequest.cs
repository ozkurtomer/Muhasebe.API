using MediatR;

namespace OnlineMuhasebe.Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany;

public sealed class CreateCompanyRequest : IRequest<CreateCompanyResponse>
{
    public string CompanyName { get; set; }

    public string CompanyServerName { get; set; }

    public string CompanyDatabaseName { get; set; }

    public string CompanyUserId { get; set; }

    public string CompanyPassword { get; set; }
}
