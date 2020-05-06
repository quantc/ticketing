using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Ticketing.CQRS.QueryHandlers;

namespace Ticketing.Cqrs
{
    public abstract class QueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, TResponse> where TQuery : IQuery<TResponse>
    {
        public abstract Task<TResponse> Handle(TQuery request, CancellationToken cancellationToken);
    }
}
