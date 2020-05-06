using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ticketing.Cqrs;
using Ticketing.CQRS.Commands;
using Ticketing.Models;
using Ticketing.Repositories;

namespace Ticketing.CQRS.CommandHandlers
{
    public class CreateEventCommandHandler : CommandHandler<CreateEventCommand>
    {
        protected override async Task Handle(CreateEventCommand command, CancellationToken cancellationToken)
        {
            var repo = new TableRepository<TicketsPool>(); 

            // instead of inserting a couple of rows as it was a real table, I could insert a e.g. JSON serialised object instead
            var eventData = new List<TicketsPool> {
                new TicketsPool {
                    EventName = command.Name, Category = nameof(command.SittingStage), CountAvailable = command.SittingStage },
                new TicketsPool {
                    EventName = command.Name, Category = nameof(command.StandingOpen), CountAvailable = command.StandingOpen },
                new TicketsPool {
                    EventName = command.Name, Category = nameof(command.StandingStage), CountAvailable = command.StandingStage }
            };

            await repo.CreateBatch(eventData);
        }
    }
}
