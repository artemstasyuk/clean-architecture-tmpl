using CleanArchitecutreTemplate.Domain.UserAggregate;
using CleanArchitecutreTemplate.Domain.UserAggregate.ValueObjects;
using ErrorOr;
using MediatR;

namespace CleanArchitectureTemplate.Application.Users.Queries.GetUserById;

public record GetUserByIdQuery(UserId Id) : IRequest<ErrorOr<User>>;
