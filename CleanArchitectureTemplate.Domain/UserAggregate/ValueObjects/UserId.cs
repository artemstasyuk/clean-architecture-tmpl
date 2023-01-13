using CleanArchitecutreTemplate.Domain.Common.Models;

namespace CleanArchitecutreTemplate.Domain.UserAggregate.ValueObjects
{
    public class UserId : ValueObject
    {
        public Guid Value { get;}

        public UserId(Guid value)
        {
            Value = value;
        }

        public static UserId CreateUnique() => new(Guid.NewGuid());
    
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public override string ToString() => Value.ToString();
    }
}