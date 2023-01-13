using CleanArchitecutreTemplate.Domain.UserAggregate;

namespace CleanArchitectureTemplate.Application.Authentication.Common
{
    public record AuthenticationResult(
        User User,
        string Token);
}
