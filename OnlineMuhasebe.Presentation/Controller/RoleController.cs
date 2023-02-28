﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineMuhasebe.Presentation.Abstraction;
using OnlineMuhasebe.Application.Features.AppFeatures.RoleFeatures.Commands.CreateRole;
using OnlineMuhasebe.Application.Features.AppFeatures.RoleFeatures.Queries.GetAllRoles;
using OnlineMuhasebe.Application.Features.AppFeatures.RoleFeatures.Commands.UpdateRole;
using OnlineMuhasebe.Application.Features.AppFeatures.RoleFeatures.Commands.DeleteRole;

namespace OnlineMuhasebe.Presentation.Controller;

public class RoleController : ApiController
{
    public RoleController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> CreateRole(CreateRoleRequest createRoleRequest)
    {
        var result = await Mediator.Send(createRoleRequest);
        return Ok(result);
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetAllRoles()
    {
        var request = new GetAllRolesRequest();
        var result = await Mediator.Send(request);
        return Ok(result);
    }
    
    [HttpPost("[action]")]
    public async Task<IActionResult> UpdateRole(UpdateRoleRequest updateRoleRequest)
    {
        var result = await Mediator.Send(updateRoleRequest);
        return Ok(result);
    }
    
    [HttpPost("[action]")]
    public async Task<IActionResult> DeleteRole(DeleteRoleRequest deleteRoleRequest)
    {
        var result = await Mediator.Send(deleteRoleRequest);
        return Ok(result);
    }
}
