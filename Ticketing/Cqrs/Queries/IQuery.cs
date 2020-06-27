using MediatR;

namespace Ticketing.CQRS.Queries
{
    public interface IQuery<out TResponse> : IRequest<TResponse>
    {
    }
}