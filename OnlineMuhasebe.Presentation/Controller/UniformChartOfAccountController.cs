﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineMuhasebe.Presentation.Abstraction;
using OnlineMuhasebe.Application.Features.CompanyFeatures.UniformChartOfAccountFeatures.Commands.CreateUniformChartOfAccount;

namespace OnlineMuhasebe.Presentation.Controller;

public class UniformChartOfAccountController : ApiController
{
    public UniformChartOfAccountController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> CreateUniformChartOfAccount(CreateUniformChartOfAccount request)
    {
        var result = await Mediator.Send(request);
        return Ok(result);
    }
}
