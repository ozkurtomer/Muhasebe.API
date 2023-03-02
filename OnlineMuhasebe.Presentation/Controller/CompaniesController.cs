using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineMuhasebe.Presentation.Abstraction;
using OnlineMuhasebe.Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany;
using OnlineMuhasebe.Application.Features.AppFeatures.CompanyFeatures.Commands.MigrateCompanyDb;

namespace OnlineMuhasebe.Presentation.Controller;

public class CompaniesController : ApiController
{
    public CompaniesController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> CreateCompany(CreateCompanyCommand createCompanyRequest)
    {
        var result = await Mediator.Send(createCompanyRequest);
        return Ok(result.Message);
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> MigrateCompanyDbs()
    {
        MigrateCompanyDbCommand migrateCompanyDbRequest = new();
        var result = await Mediator.Send(migrateCompanyDbRequest);
        return Ok(result);
    }
}
