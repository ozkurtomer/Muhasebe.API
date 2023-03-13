using MediatR;
using OnlineMuhasebe.Presentation.Abstraction;

namespace OnlineMuhasebe.Presentation.Controller;

public class AppUserCompaniesController : ApiController
{
    public AppUserCompaniesController(IMediator mediator) : base(mediator)
    {
    }
}
