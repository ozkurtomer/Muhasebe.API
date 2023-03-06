using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineMuhasebe.Presentation.Abstraction;
using OnlineMuhasebe.Application.Features.AppFeatures.MainRoleFeatures.Commands.CreateRole;

namespace OnlineMuhasebe.Presentation.Controller;

public sealed class MainRoleController : ApiController
{
    public MainRoleController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> CreateMainRole(CreateMainRoleCommand createMainRoleCommand, CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(createMainRoleCommand, cancellationToken);
        return Ok(result);
    }
}
