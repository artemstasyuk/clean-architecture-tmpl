using CleanArchitectureTemplate.Application.Authentication.Common;
using ErrorOr;
using MediatR;

namespace CleanArchitectureTemplate.Application.Authentication.Queries.Login
{
    public record LoginQuery(
        string Email,
        string Password) : IRequest<ErrorOr<AuthenticationResult>>;
}
