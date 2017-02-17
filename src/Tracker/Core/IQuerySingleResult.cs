namespace Tracker.Core
{
    public interface IQuerySingleResult<TQuery, TResult> where TQuery : IQuery
    {
        TQuery Query { get; set; }
        TResult Result { get; set; }
    }
}