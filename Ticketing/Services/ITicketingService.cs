using System.Collections.Generic;
using Ticketing.Models;

namespace Ticketing.Services
{
    public interface ITicketingService
    {
        IEnumerable<TicketInfo> GetAvailable();
    }
}
