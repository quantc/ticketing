using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ticketing.Models;
using Ticketing.Respositories;

namespace Ticketing.Services
{
    public class TicketingService : ITicketingService
    {
        public async Task<IEnumerable<TicketInfo>> GetAvailable(string eventName)
        {
            var repo = new TableRepository<TicketsPool>(); //use ioc

            var allTickets = await repo.GetAll(nameof(TicketsPool.EventName), new List<string> { eventName });

            var result = allTickets
                .GroupBy(ticket => ticket.Category)
                .Select(group => new TicketInfo { TicketCategory = group.Key.ToString(), Count = group.Count() });

            return result;
        }

        private IEnumerable<Ticket> GetAll()
        {
            var standingStage = Enumerable.Range(1, 60).Select(x => new Ticket { Category = TicketCategory.StandingStage, Price = 10 });
            var sittingStage = Enumerable.Range(1, 40).Select(x => new Ticket { Category = TicketCategory.SittingStage, Price = 20 });

            return standingStage.Concat(sittingStage);
        }

        private IEnumerable<Ticket> GetBooked()
        {
            var standingStage = Enumerable.Range(1, 10).Select(x => new Ticket { Category = TicketCategory.StandingStage });
            var sittingStage = Enumerable.Range(1, 10).Select(x => new Ticket { Category = TicketCategory.SittingStage });

            return standingStage.Concat(sittingStage);
        }
    }
}
