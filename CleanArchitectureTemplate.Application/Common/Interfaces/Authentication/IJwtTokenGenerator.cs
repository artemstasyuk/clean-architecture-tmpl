using CleanArchitecutreTemplate.Domain.UserAggregate;

namespace CleanArchitectureTemplate.Application.Common.Interfaces.Authentication
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
    }
}