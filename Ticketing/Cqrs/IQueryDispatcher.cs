using System.Threading;
using System.Threading.Tasks;
using Ticketing.CQRS.Queries;

namespace Ticketing.Cqrs
{
    public interface IQueryDispatcher
    {
        Task<TResponse> Execute<TResponse>(IQuery<TResponse> query,
            CancellationToken cancellationToken = new CancellationToken());
    }
}