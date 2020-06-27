using System.Collections.Generic;
using Ticketing.CQRS.Queries;
using Ticketing.Models;

namespace Ticketing.Cqrs.Queries
{
    public class GetAvailableTicketsQuery : IQuery<IEnumerable<TicketInfo>>
    {
        public string EventName { get; set; }
    }
}
