using MediatR;

namespace OnlineMuhasebe.Application.Messaging;

public interface ICommand<out TResponse>: IRequest<TResponse>
{
}
