using System.Threading;
using System.Threading.Tasks;
using Ticketing.CQRS.Commands;

namespace Ticketing.CQRS
{
    public interface ICommandDispatcher
    {
        Task Execute<TCommand>(TCommand command, CancellationToken cancellationToken = new CancellationToken())
            where TCommand : ICommand;
    }
}