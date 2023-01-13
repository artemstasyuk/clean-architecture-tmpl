using CleanArchitecutreTemplate.Domain.UserAggregate;
using CleanArchitecutreTemplate.Domain.UserAggregate.ValueObjects;
using ErrorOr;
using MediatR;

namespace CleanArchitectureTemplate.Application.Users.Commands.AddBalanceToUser
{
    public record AddBalanceToUserCommand(
        UserId UserId,
        decimal Amount) : IRequest<ErrorOr<User>>;
}