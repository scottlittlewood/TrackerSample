using System;
using Tracker.Core;

namespace Tracker.Tracking
{
    public class TicketQueryById : IQuery
    {
        public Guid Id { get; set; }
    }
}