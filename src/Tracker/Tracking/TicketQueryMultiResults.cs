using System.Collections.Generic;
using Tracker.Core;

namespace Tracker.Tracking
{
    public class TicketQueryMultiResults : IQueryMultiResults<TicketQueryByName, Tickets.Ticket>
    {
        public TicketQueryByName Query { get; set; }
        public List<Tickets.Ticket> Results { get; set; }
    }
}