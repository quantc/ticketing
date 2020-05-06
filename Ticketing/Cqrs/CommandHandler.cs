using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Ticketing.CQRS.Commands;

namespace Ticketing.Cqrs
{
    public abstract class CommandHandler<TCommand> : AsyncRequestHandler<TCommand> where TCommand : ICommand
    {
        protected abstract override Task Handle(TCommand request, CancellationToken cancellationToken);
    }
}