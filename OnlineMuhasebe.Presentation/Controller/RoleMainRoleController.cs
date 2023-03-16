using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineMuhasebe.Presentation.Abstraction;
using OnlineMuhasebe.Application.Features.AppFeatures.RoleMainRoleFeatures.Queries.GetAllRoleMainRole;
using OnlineMuhasebe.Application.Features.AppFeatures.RoleMainRoleFeatures.Commands.CreateRoleMainRole;
using OnlineMuhasebe.Application.Features.AppFeatures.RoleMainRoleFeatures.Commands.DeleteByIdRoleMainRole;

namespace OnlineMuhasebe.Presentation.Controller;

public class RoleMainRoleController : ApiController
{
    public RoleMainRoleController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> CreateRoleMainRole(CreateRoleMainRoleCommand createRoleMainRoleCommand, CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(createRoleMainRoleCommand, cancellationToken);
        return Ok(result);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> DeleteByIdRoleMainRole(DeleteByIdRoleMainRoleCommand deleteByIdRoleMainRoleCommand, CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(deleteByIdRoleMainRoleCommand, cancellationToken);
        return Ok(result);
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetRoleMainRoleList()
    {
        var command = new GetAllRoleMainRoleQuery();
        var result = await Mediator.Send(command);
        return Ok(result);
    }
}
