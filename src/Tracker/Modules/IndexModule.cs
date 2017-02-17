using Nancy;

namespace Tracker.Modules
{
    public class IndexModule : NancyModule
    {
        public IndexModule()
        {
            Get["/"] = _ => View["index"];

            
        }
    }
}