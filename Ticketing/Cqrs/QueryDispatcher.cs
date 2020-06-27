using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Ticketing.CQRS.Queries;

namespace Ticketing.Cqrs
{
    public class QueryDispatcher : IQueryDispatcher
    {
        private readonly IMediator mediator;

        public QueryDispatcher(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public Task<TResponse> Execute<TResponse>(IQuery<TResponse> query,
            CancellationToken cancellationToken = new CancellationToken())
        {
            return mediator.Send(query, cancellationToken);
        }
    }
}