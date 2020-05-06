using System;
using Ticketing.Enums;

namespace Ticketing.Models
{
    public class TicketInfo
    {
        public string TicketCategory { get; set; }
        public int Count { get; set; }
    }
    public class Ticket
    {
        public TicketCategory Category { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        //public DateTime EventDate { get; set; } // both could be just replaces with Event object
        //public string EventName { get; set; }
    }   
}
