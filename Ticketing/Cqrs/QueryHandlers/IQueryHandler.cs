using MediatR;

namespace Ticketing.CQRS.QueryHandlers
{
    public interface IQuery<out TResponse> : IRequest<TResponse>
    {

    }

  
}