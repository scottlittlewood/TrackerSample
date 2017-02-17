using System.Linq;
using Nancy;
using Nancy.ModelBinding;
using Nancy.Responses;
using Tracker.Tracking;

namespace Tracker.Modules
{
    public class TrackingModule : NancyModule
    {
        public TrackingModule()
        {
            Get["/gif/{id}"] = _ =>
            {
                var query = this.Bind<TicketQueryById>();

                Tickets.LogAccess(query.Id, Request.UserHostAddress);

                var filename = @"Content\transparent_1x1.gif";
                var response = new GenericFileResponse(filename)
                {
                    ContentType = MimeTypes.GetMimeType(filename)
                };

                return response;
            };

            Get["/gif/search/{name}"] = _ =>
            {
                var query = this.Bind<TicketQueryByName>();

                var result = new TicketQueryMultiResults
                {
                    Query = query,
                    Results = Tickets.Find(query.Name).ToList()
                };

                return result;
            };

            Get["/gif/{id}/details"] = _ =>
            {
                var query = this.Bind<TicketQueryById>();

                object result;

                var ticket = Tickets.Find(query.Id);

                if (ticket == null)
                {
                    result = HttpStatusCode.NotFound;
                }
                else
                {
                    result = new TicketQuerySingleResult
                    {
                        Query = query,
                        Result = ticket
                    };
                }


                return result;
            };

            Post["/gif/generate"] = _ =>
            {
                var input = this.Bind<GenerateTicketInputModel>();

                var ticket = Tickets.CreateTicket(input.Name);

                return Response.AsRedirect($"/gif/{ticket.Id}/details");
            };
        }
    }
}