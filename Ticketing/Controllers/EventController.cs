using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Ticketing.Cqrs;
using Ticketing.Cqrs.Queries;
using Ticketing.CQRS;
using Ticketing.CQRS.Commands;
using Ticketing.Models;

namespace Ticketing.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : BaseController
    {
        public EventController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher, ILogger logger) : base(commandDispatcher, queryDispatcher, logger)
        {
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create(Event model)
        {
            await CommandDispatcher.Execute(new CreateEventCommand(model.Name, model.SittingStage, model.StandingStage, model.StandingOpen));

            return Ok();
        }


        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> Get()
        {
            var result = await QueryDispatcher.Execute(new GetEventsQuery());
            return Ok(result);
        }

    }
}