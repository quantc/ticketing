using System.Collections.Generic;
using System.Threading.Tasks;
using Ticketing.Models;

namespace Ticketing.Services
{
    public interface ITicketingService
    {
        Task<IEnumerable<TicketInfo>> GetAvailable(string eventName);
    }
}
