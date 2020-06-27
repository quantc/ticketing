using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Ticketing.Cqrs.Queries;
using Ticketing.Models;
using Ticketing.Repositories;

namespace Ticketing.Cqrs.QueryHandlers
{
    public class GetAvailableTicketsQueryHandler : QueryHandler<GetAvailableTicketsQuery, IEnumerable<TicketInfo>> 
    {
        public override async Task<IEnumerable<TicketInfo>> Handle(GetAvailableTicketsQuery query, CancellationToken cancellationToken)
        {
            var repo = new TableRepository<TicketsPool>(); //use ioc

            var allTickets = await repo.GetAll(nameof(TicketsPool.EventName), new List<string> {query.EventName});

            var result = allTickets
                .GroupBy(ticket => ticket.Category)
                .Select(group => new TicketInfo { TicketCategory = group.Key.ToString(), Count = group.Count() });

            return result;
        }
    }
}