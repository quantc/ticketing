﻿using System.Collections.Generic;
using Ticketing.CQRS.Queries;
using Ticketing.Models;

namespace Ticketing.Cqrs.Queries
{
    public class GetEventsQuery : IQuery<IEnumerable<TicketsPool>>
    {
    }
}