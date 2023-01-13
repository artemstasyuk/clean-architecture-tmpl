namespace CleanArchitecutreTemplate.Domain.Common.Models
{
    public abstract class Entity<TId> : IEquatable<Entity<TId>>
        where TId : notnull
    {
        public TId Id { get;}

        protected Entity(TId id)
        {
            Id = id;
        }
    
        public bool Equals(Entity<TId>? other) =>
            Equals((object?)other);

        public override bool Equals(object? obj) =>
            obj is Entity<TId> entity && Id.Equals(entity.Id);

        public override int GetHashCode() =>
            Id.GetHashCode();

        public static bool operator ==(Entity<TId> left, Entity<TId> right) =>
            Equals(left, right);
    
        public static bool operator !=(Entity<TId> left, Entity<TId>? right) =>
            !Equals(left, right);
    }
}