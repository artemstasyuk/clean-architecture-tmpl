using CleanArchitecutreTemplate.Domain.Common.Models;
using CleanArchitecutreTemplate.Domain.UserAggregate.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CleanArchitecutreTemplate.Domain.UserAggregate.ValueObjects
{
    public class Balance : ValueObject
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public Currency Currency { get; private set; }
    
        public decimal Amount { get; private set; }

        [JsonConstructor]
        public Balance(Currency currency, decimal amount)
        {
            Currency = currency;
            Amount = amount;
        }

        public static Balance Create(Currency currency, decimal amount) => 
            new(currency, amount);
    
        public void Replenishment(decimal balance) => Amount += balance;

        public void Debit(decimal balance) => Amount -= balance;
    
        public override string ToString()
            => (Currency == Currency.Dollar ? "$" : "€") + Amount;
    
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Currency;
            yield return Amount;
        }
    }
}