using Tracker.Core;

namespace Tracker.Tracking
{
    public class TicketQuerySingleResult : IQuerySingleResult<TicketQueryById, Tickets.Ticket>
    {
        public TicketQueryById Query { get; set; }
        public Tickets.Ticket Result { get; set; }
    }
}