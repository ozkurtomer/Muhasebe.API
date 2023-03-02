using MediatR;
using OnlineMuhasebe.Application.Messaging;
using OnlineMuhasebe.Application.Services.AppServices;

namespace OnlineMuhasebe.Application.Features.AppFeatures.CompanyFeatures.Commands.MigrateCompanyDb;

public sealed class MigrateCompanyDbCommandHandler : ICommandHandler<MigrateCompanyDbCommand, MigrateCompanyDbCommandResponse>
{
    private readonly ICompanyService CompanyService;

    public MigrateCompanyDbCommandHandler(ICompanyService companyService)
    {
        CompanyService = companyService;
    }

    public async Task<MigrateCompanyDbCommandResponse> Handle(MigrateCompanyDbCommand request, CancellationToken cancellationToken)
    {
        await CompanyService.MigrateCompanyDbs(request);
        return new();
    }
}
