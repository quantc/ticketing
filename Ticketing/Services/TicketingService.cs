using System.Collections.Generic;
using System.Linq;
using Ticketing.Models;

namespace Ticketing.Services
{
    public class TicketingService : ITicketingService
    {
        public IEnumerable<TicketInfo> GetAvailable()
        {
            // let's say there is always 100 available tickets
            var allTickets = GetAll();

            //var repo = ticketsRepository.GetBookedTickets() etc...
            var bookedTickets = GetBooked();

            var remainingTickets = allTickets
                .GroupBy(ticket => ticket.Category)
                .Select(group => new TicketInfo { TicketCategory = group.Key.ToString(), Count = group.Count() });

            return remainingTickets;
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
