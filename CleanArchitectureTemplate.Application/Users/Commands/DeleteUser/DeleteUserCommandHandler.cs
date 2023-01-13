using CleanArchitectureTemplate.Application.Common.Interfaces.Persistence;
using CleanArchitecutreTemplate.Domain.Common.Errors;
using CleanArchitecutreTemplate.Domain.UserAggregate.Enums;
using ErrorOr;
using MediatR;

namespace CleanArchitectureTemplate.Application.Users.Commands.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, ErrorOr<Unit>>
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<Unit>> Handle(DeleteUserCommand command, CancellationToken cancellationToken)
        {
            if (await _userRepository.GetUserByIdAsync(command.Id) is not {} user)
                return Errors.User.NotFound;

            if (user.Role is Role.Admin)
                return Errors.User.AdminCannotBeDeleted;

            await _userRepository.DeleteUserAsync(user);
        
            return Unit.Value;
        }
    }
}