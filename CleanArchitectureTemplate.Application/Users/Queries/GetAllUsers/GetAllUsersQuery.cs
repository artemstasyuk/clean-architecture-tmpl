using CleanArchitecutreTemplate.Domain.UserAggregate;
using ErrorOr;
using MediatR;

namespace CleanArchitectureTemplate.Application.Users.Queries.GetAllUsers;

public record GetAllUsersQuery() : IRequest<ErrorOr<List<User>>>;