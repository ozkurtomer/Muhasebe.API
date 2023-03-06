using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineMuhasebe.Presentation.Abstraction;
using OnlineMuhasebe.Application.Features.AppFeatures.MainRoleFeatures.Commands.CreateRole;
using OnlineMuhasebe.Application.Features.AppFeatures.MainRoleFeatures.Commands.CreateStaticMainRoles;

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

    [HttpPost("[action]")]
    public async Task<IActionResult> CreateStaticMainRole(CreateStaticMainRolesCommand createStaticMainRolesCommand, CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(createStaticMainRolesCommand, cancellationToken);
        return Ok(result);
    }
}
