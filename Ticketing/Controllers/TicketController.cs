using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ticketing.Models;
using Ticketing.Services;

namespace Ticketing.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketController : ControllerBase
    {
        private readonly ILogger<TicketController> _logger;

        public TicketController(ILogger<TicketController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<TicketInfo>> GetAvailable(string eventName)
        {
            var ticketService = new TicketingService();

            return await ticketService.GetAvailable(eventName);
        }

        [HttpPost]
        public IActionResult Book(BookTicket ticket)
        {
            // puts the ticket on the queue

            return Ok();
        }
    }
}
