using CleanArchitecutreTemplate.Domain.Common.Models;
using CleanArchitecutreTemplate.Domain.UserAggregate.Enums;
using CleanArchitecutreTemplate.Domain.UserAggregate.ValueObjects;

namespace CleanArchitecutreTemplate.Domain.UserAggregate
{
    public sealed class User : AggregateRoot<UserId>
    {
        public string FirstName { get; private set; }

        public string LastName { get; private set;}

        public string Email { get; private set;}

        public byte[] PasswordHash { get;}
    
        public byte[] PasswordSalt { get;}
    
    
        public Role Role { get; private set;}

        public DateTime CreatedDateTime { get;}
    
        public DateTime UpdatedDateTime { get; private set;}

        public User(UserId id, string firstName, string lastName, string email, byte[] passwordHash, byte[] passwordSalt
            , Role role, DateTime createdDateTime, DateTime updatedDateTime) : base(id)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
            Role = role;
        }
    
        public static User Create(string firstName, string lastName, string email, byte[] passwordHash, byte[] passwordSalt,Role role) =>
            new(UserId.CreateUnique(), firstName, lastName, email, passwordHash, passwordSalt, role,
                DateTime.UtcNow, DateTime.UtcNow);

        public User Update(string firstName, string lastName, string email,
            Balance balance)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            UpdatedDateTime = DateTime.UtcNow;

            return this;
        }
    }
}