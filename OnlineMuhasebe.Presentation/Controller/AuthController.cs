using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineMuhasebe.Presentation.Abstraction;
using OnlineMuhasebe.Application.Features.AppFeatures.AppUserFeatures.Login;

namespace OnlineMuhasebe.Presentation.Controller;

public class AuthController : ApiController
{
    public AuthController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Login(LoginCommand loginRequest)
    {
        var result = await Mediator.Send(loginRequest);
        return Ok(result);
    }
}
