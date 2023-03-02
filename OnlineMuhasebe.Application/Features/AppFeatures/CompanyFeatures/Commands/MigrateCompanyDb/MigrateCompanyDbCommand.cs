using OnlineMuhasebe.Application.Messaging;

namespace OnlineMuhasebe.Application.Features.AppFeatures.CompanyFeatures.Commands.MigrateCompanyDb;

public sealed record MigrateCompanyDbCommand() : ICommand<MigrateCompanyDbCommandResponse>;
