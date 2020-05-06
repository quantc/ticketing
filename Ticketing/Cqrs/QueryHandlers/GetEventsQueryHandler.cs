using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Ticketing.Cqrs;
using Ticketing.Cqrs.Queries;
using Ticketing.Models;
using Ticketing.Repositories;

namespace Ticketing.CQRS.QueryHandlers
{
    public class GetEventsQueryHandler : QueryHandler<GetEventsQuery, IEnumerable<TicketsPool>>
    {
        public override async Task<IEnumerable<TicketsPool>> Handle(GetEventsQuery request, CancellationToken cancellationToken)
        {
            var repo = new TableRepository<TicketsPool>(); //use ioc

            var allEvents = await repo.GetAll();
            var events = allEvents.OrderBy(ev => ev.EventName);

            return events;
        }
    }
}
