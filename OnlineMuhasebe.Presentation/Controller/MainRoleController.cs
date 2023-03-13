using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineMuhasebe.Presentation.Abstraction;
using OnlineMuhasebe.Application.Features.AppFeatures.MainRoleFeatures.Commands.CreateRole;
using OnlineMuhasebe.Application.Features.AppFeatures.MainRoleFeatures.Queries.GetAllMainRole;
using OnlineMuhasebe.Application.Features.AppFeatures.MainRoleFeatures.Commands.DeleteByIdMainRole;
using OnlineMuhasebe.Application.Features.AppFeatures.MainRoleFeatures.Commands.CreateStaticMainRoles;
using OnlineMuhasebe.Application.Features.AppFeatures.MainRoleFeatures.Commands.UpdateMainRole;

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
    public async Task<IActionResult> CreateStaticMainRole(CancellationToken cancellationToken)
    {
        var command = new CreateStaticMainRolesCommand(null);
        var result = await Mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetAllMainRoles()
    {
        var command = new GetAllMainRoleQuery();
        var result = await Mediator.Send(command);
        return Ok(result);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> DeleteMainRoleById(DeleteByIdMainRoleCommand request)
    {
        var result = await Mediator.Send(request);
        return Ok(result);
    }
    
    [HttpPost("[action]")]
    public async Task<IActionResult> UpdateMainRoleById(UpdateMainRoleCommand request)
    {
        var result = await Mediator.Send(request);
        return Ok(result);
    }
}
