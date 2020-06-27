using Ticketing.CQRS.Commands;
using Ticketing.Enums;

namespace Ticketing.Cqrs.Commands
{
    public class BookTicketCommand : ICommand
    {
        public string EventName { get; }
        public TicketCategory Category { get; }
        public int Count { get; }

        public BookTicketCommand(string eventName, TicketCategory category, int count)
        {
            EventName = eventName;
            Category = category;
            Count = count;
        }
    }
}