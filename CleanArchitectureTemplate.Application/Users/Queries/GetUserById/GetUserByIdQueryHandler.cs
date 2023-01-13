using CleanArchitectureTemplate.Application.Common.Interfaces.Persistence;
using CleanArchitecutreTemplate.Domain.Common.Errors;
using CleanArchitecutreTemplate.Domain.UserAggregate;
using ErrorOr;
using MediatR;

namespace CleanArchitectureTemplate.Application.Users.Queries.GetUserById;

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, ErrorOr<User>>
{
    private readonly IUserRepository _userRepository;

    public GetUserByIdQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<User>> Handle(GetUserByIdQuery query, CancellationToken cancellationToken)
    {
        if (await _userRepository.GetUserByIdAsync(query.Id) is not {} user)
            return Errors.User.NotFound;

        return user;
    }
        

}