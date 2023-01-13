using CleanArchitecutreTemplate.Domain.UserAggregate.ValueObjects;
using ErrorOr;
using MediatR;

namespace CleanArchitectureTemplate.Application.Users.Commands.DeleteUser
{
    public record DeleteUserCommand(UserId Id) : IRequest<ErrorOr<Unit>>;
}