using MediatR;

namespace OnlineMuhasebe.Application.Messaging;

public interface IQuery<out TResponse>:IRequest<TResponse>
{
}
