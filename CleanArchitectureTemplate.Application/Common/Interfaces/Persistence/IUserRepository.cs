using CleanArchitecutreTemplate.Domain.UserAggregate;
using CleanArchitecutreTemplate.Domain.UserAggregate.ValueObjects;

namespace CleanArchitectureTemplate.Application.Common.Interfaces.Persistence
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsers();
        Task<User?> GetUserByIdAsync(UserId id);
        Task<User?> GetUserByEmailAsync(string email);
    
        Task AddUserAsync(User newUser);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(User user);
    }
}