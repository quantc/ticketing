using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Ticketing.Cqrs.Queries;
using Ticketing.CQRS;
using Ticketing.Cqrs.Commands;
using Ticketing.Models;

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
        public async Task<IActionResult> GetAvailable(string eventName)
        {
            var result = await QueryDispatcher.Execute(new GetAvailableTicketsQuery {EventName = eventName});
            return Ok(result);
        }

        [HttpPost]
        [Route("book")]
        public async Task<IActionResult> Book(BookTicket ticket)
        {
            await CommandDispatcher.Execute(new BookTicketCommand(ticket.EventName, ticket.Category, ticket.Count));
            return Ok();
        }
    }
}
