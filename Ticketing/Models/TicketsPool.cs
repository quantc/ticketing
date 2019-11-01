using System;
using Ticketing.Attributes;

namespace Ticketing.Models
{
    [TableName("ticketsPool")]
    public class TicketsPool : BaseEntity
    {
        private string eventName;
        private string ticketCategory;

        public string EventName
        {
            get => eventName;
            set
            {
                eventName = value;
                PartitionKey = eventName;
            }
        }
        public TicketCategory Category
        {
            get => (TicketCategory)Enum.Parse(typeof(TicketCategory), ticketCategory, true);
            set
            {
                ticketCategory = value.ToString();
                RowKey = ticketCategory;
            }
        }

        public int CountAvailable { get; set; }
        public decimal Price { get; set; }
    }
}
