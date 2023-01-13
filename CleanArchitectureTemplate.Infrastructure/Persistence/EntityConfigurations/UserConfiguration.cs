using System.Security.Cryptography;
using System.Text;
using CleanArchitecutreTemplate.Domain.UserAggregate;
using CleanArchitecutreTemplate.Domain.UserAggregate.Enums;
using CleanArchitecutreTemplate.Domain.UserAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;

namespace CleanArchitectureTemplate.Infrastructure.Persistence.EntityConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {

        private List<User> Users => CreateTestUsers();
        
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");
        
            builder.Property(user => user.Id)
                .HasConversion(
                    id => id.Value,
                    value => new UserId(value))
                .IsRequired();

            builder.Property(e => e.Balance)
                .HasConversion(
                    v => JsonConvert.SerializeObject(v),
                    v => JsonConvert.DeserializeObject<Balance>(v));
            
            builder.Property(e => e.Role)
                .HasConversion(
                    v => v.ToString(),
                    v => (Role)Enum.Parse(typeof(Role), v));

            builder.Property(u => u.FirstName).IsRequired();
            builder.Property(u => u.LastName).IsRequired();
            builder.Property(u => u.Email).IsRequired();
            builder.Property(u => u.PasswordHash).IsRequired();
            builder.Property(u => u.PasswordSalt).IsRequired();
            builder.Property(u => u.Role).IsRequired();
            builder.Property(u => u.CreatedDateTime).IsRequired();
            builder.Property(u => u.UpdatedDateTime).IsRequired();

            builder.HasData(Users);
        }

        #region Create test data
        private static List<User> CreateTestUsers()
        {
            CreateTestPasswordHash("secret123", out byte[] adminPasswordHash, out byte[] adminPasswordSalt);
            CreateTestPasswordHash("simple", out byte[] passwordHash, out byte[] passwordSalt);
        
            var users = new List<User>()
            {
                User.Create("Jorge", "Admin", "admin123@gmail.com", adminPasswordHash, adminPasswordSalt,
                    Balance.Create(Currency.Dollar, 1000), Role.Admin), // Admin (password = secret123)

                User.Create("Don", "Test Customer", "1v2goog@gmail.com", passwordHash, passwordSalt,
                    Balance.Create(Currency.Dollar, 500), Role.Customer), // Test customer (password = simple)
            };
        
            void CreateTestPasswordHash(string password, out byte[] hash, out byte[] salt)
            {
                using var hmac = new HMACSHA512();
                salt = hmac.Key;
                hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }

            return users;
        }
        #endregion
    }
}