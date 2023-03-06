using MediatR;
using OnlineMuhasebe.Presentation.Abstraction;

namespace OnlineMuhasebe.Presentation.Controller;

public sealed class MainRoleController : ApiController
{
    public MainRoleController(IMediator mediator) : base(mediator)
    {
    }
}
