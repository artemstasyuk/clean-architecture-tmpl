using CleanArchitecutreTemplate.Domain.UserAggregate;
using CleanArchitecutreTemplate.Domain.UserAggregate.ValueObjects;
using ErrorOr;
using MediatR;

namespace CleanArchitectureTemplate.Application.Users.Commands.UpdateUser
{
    public record UpdateUserCommand : IRequest<ErrorOr<User>>
    {
        public UserId Id { get; set; } = default!;
        public string FirstName { get; init; } = default!;
        public string LastName { get; init; } = default!;
        public string Email { get; init; } = default!;
        public BalanceCommand Balance { get; init; } = default!;
    }

    public record BalanceCommand(
        string Currency,
        decimal Amount);
}