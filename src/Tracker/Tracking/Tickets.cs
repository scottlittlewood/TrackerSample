using System;
using System.Collections.Generic;
using System.Linq;

namespace Tracker.Tracking
{
    public class Tickets
    {
        private static readonly List<Ticket> ActiveTickets = new List<Ticket>();

        public enum TicketState
        {
            New,
            Accessed
        }

        public class Ticket
        {
            public Guid Id { get; set; }
            public DateTime GeneratedAt { get; set; }
            public string GeneratedBy { get; set; }
            public TicketState State { get; set; }

            public List<AccessEntry> AccessedAt = new List<AccessEntry>();

            private Ticket(Guid guid, DateTime utcNow, string requestedBy)
            {
                Id = guid;
                GeneratedAt = utcNow;
                GeneratedBy = requestedBy;
                State = TicketState.New;
            }

            public void LogAcccess(string ipAddress)
            {
                State = TicketState.Accessed;
                AccessedAt.Add(new AccessEntry
                {
                    IPAddress = ipAddress,
                    OccurredAt = DateTime.UtcNow
                });
            }

            public static Ticket Create(string requestedBy)
            {
                var ticket = new Ticket(Guid.NewGuid(), DateTime.UtcNow, requestedBy);
                return ticket;
            }
        }

        public static Ticket Find(Guid id)
        {
            return ActiveTickets.SingleOrDefault(t => t.Id == id);
        }

        public static IEnumerable<Ticket> Find(string name)
        {
            return ActiveTickets.Where(t => t.GeneratedBy == name);
        }

        public static void LogAccess(Guid id, string ipAddress)
        {
            var ticket = Find(id);
            if (ticket != null)
                ticket.LogAcccess(ipAddress);
        }

        public static Ticket CreateTicket(string requestedBy)
        {
            var ticket = Ticket.Create(requestedBy);
            ActiveTickets.Add(ticket);
            return ticket;
        }
    }
}