using MediatR;
using OnlineMuhasebe.Presentation.Abstraction;

namespace OnlineMuhasebe.Presentation.Controller;

public class RoleMainRolesController : ApiController
{
    public RoleMainRolesController(IMediator mediator) : base(mediator)
    {
    }
}
