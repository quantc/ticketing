using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Ticketing.Cqrs;
using Ticketing.CQRS;

namespace Ticketing.Controllers
{
    public class BaseController : ControllerBase
    {
        protected readonly ICommandDispatcher CommandDispatcher;
        protected readonly IQueryDispatcher QueryDispatcher;
        protected readonly ILogger Logger;

        public BaseController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher, ILogger logger)
        {
            CommandDispatcher = commandDispatcher;
            QueryDispatcher = queryDispatcher;
            Logger = logger;
        }

        public BaseController(ICommandDispatcher commandDispatcher, ILogger logger)
        {
            CommandDispatcher = commandDispatcher;
            Logger = logger;
        }
    }
}