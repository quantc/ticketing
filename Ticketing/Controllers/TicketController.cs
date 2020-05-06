using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ticketing.CQRS;
using Ticketing.Models;
using Ticketing.Services;

namespace Ticketing.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : BaseController
    {
        public TicketController(ICommandDispatcher commandDispatcher, ILogger logger) : base(commandDispatcher, logger)
        {
        }   

        [HttpGet]
        [Route("getAvailable")]
        public async Task<IEnumerable<TicketInfo>> GetAvailable(string eventName)
        {
            var ticketService = new TicketingService();
            Logger.LogError("sssss");

            return await ticketService.GetAvailable(eventName);
        }

        [HttpPost]
        [Route("book")]
        public async Task<IActionResult> Book(BookTicket ticket)
        {
            var ticketService = new TicketingService();

            await ticketService.BookTicket(ticket);

            return Ok();
        }
    }
}
