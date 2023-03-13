using MediatR;
using OnlineMuhasebe.Presentation.Abstraction;

namespace OnlineMuhasebe.Presentation.Controller;

public class MainRoleUsersController : ApiController
{
    public MainRoleUsersController(IMediator mediator) : base(mediator)
    {
    }
}
