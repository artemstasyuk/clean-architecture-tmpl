using CleanArchitectureTemplate.Application.Common.Interfaces.Persistence;
using CleanArchitecutreTemplate.Domain.UserAggregate;
using ErrorOr;
using MediatR;

namespace CleanArchitectureTemplate.Application.Users.Queries.GetAllUsers;

public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, ErrorOr<List<User>>>
{
    private readonly IUserRepository _userRepository;

    public GetAllUsersQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<List<User>>> Handle(GetAllUsersQuery query, CancellationToken cancellationToken) =>
        await _userRepository.GetAllUsers();
}