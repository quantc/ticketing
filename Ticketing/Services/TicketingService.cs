using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ticketing.Enums;
using Ticketing.Models;
using Ticketing.Repositories;

namespace Ticketing.Services
{
    public class TicketingService : ITicketingService
    {
        public async Task BookTicket(BookTicket ticket)
        {
            var repo = new QueueRepository(QueueName.RequestedToBook);
            var serializer = new QueueMessageSerializer(); // lifecycle na single 
            
            await repo.Add(serializer.Serialize(ticket));
        }

        public async Task<IEnumerable<TicketInfo>> GetAvailable(string eventName)
        {
            var repo = new TableRepository<TicketsPool>(); //use ioc

            var allTickets = await repo.GetAll(nameof(TicketsPool.EventName), new List<string> { eventName });

            var result = allTickets
                .GroupBy(ticket => ticket.Category)
                .Select(group => new TicketInfo { TicketCategory = group.Key.ToString(), Count = group.Count() });

            return result;
        }
    }
}
