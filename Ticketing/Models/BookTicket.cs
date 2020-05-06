using Ticketing.Enums;

namespace Ticketing.Models
{
    public class BookTicket
    {
        public TicketCategory Category { get; set; }
        public int Count { get; set; }
    }
}
