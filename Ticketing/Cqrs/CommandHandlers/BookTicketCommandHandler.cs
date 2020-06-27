using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Ticketing.Cqrs.Commands;
using Ticketing.Enums;
using Ticketing.Repositories;
using Ticketing.Services;

namespace Ticketing.Cqrs.CommandHandlers
{
    public class BookTicketCommandHandler : CommandHandler<BookTicketCommand>
    {
        protected override async Task Handle(BookTicketCommand request, CancellationToken cancellationToken)
        {
            var queue = new QueueRepository(QueueName.RequestedToBook);
            var serializer = new QueueMessageSerializer(); // lifecycle na single?

            await queue.Add(serializer.Serialize(request));
        }
    }
}
