using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Ticketing.CQRS.Commands;

namespace Ticketing.CQRS
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IMediator mediator;

        public CommandDispatcher(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task Execute<TCommand>(TCommand command, CancellationToken cancellationToken = new CancellationToken()) where TCommand : ICommand
        {
            await mediator.Send(command, cancellationToken);
        }
    }
}