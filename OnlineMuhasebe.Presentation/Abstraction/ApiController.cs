using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace OnlineMuhasebe.Presentation.Abstraction;

[ApiController]
[Route("api/[controller]")]
public abstract class ApiController : ControllerBase
{
    protected readonly IMediator Mediator;
	public ApiController(IMediator mediator)
	{
		Mediator= mediator;
	}
}
