namespace CleanArchitecutreTemplate.Domain.Common.Models
{
    public class AggregateRoot<TId> : Entity<TId>
        where TId : notnull
    {
        protected AggregateRoot(TId id) : base(id) {}
    }
}