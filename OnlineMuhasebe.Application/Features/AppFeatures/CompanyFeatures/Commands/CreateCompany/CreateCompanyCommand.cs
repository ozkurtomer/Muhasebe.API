using OnlineMuhasebe.Application.Messaging;

namespace OnlineMuhasebe.Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany;

public sealed record CreateCompanyCommand(
    string CompanyName,
    string CompanyServerName,
    string CompanyDatabaseName,
    string CompanyUserId,
    string CompanyPassword) : ICommand<CreateCompanyCommandResponse>;
