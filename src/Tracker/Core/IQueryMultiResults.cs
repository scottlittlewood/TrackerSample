using System.Collections.Generic;

namespace Tracker.Core
{
    public interface IQueryMultiResults<TQuery, TResult> where TQuery : IQuery
    {
        TQuery Query { get; set; }
        List<TResult> Results { get; set; }
    }
}