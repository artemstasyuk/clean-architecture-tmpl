using CleanArchitectureTemplate.Application.Common.Interfaces.Persistence;
using CleanArchitecutreTemplate.Domain.Common.Errors;
using CleanArchitecutreTemplate.Domain.UserAggregate;
using CleanArchitecutreTemplate.Domain.UserAggregate.Enums;
using CleanArchitecutreTemplate.Domain.UserAggregate.ValueObjects;
using ErrorOr;
using MediatR;

namespace CleanArchitectureTemplate.Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, ErrorOr<User>>
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<User>> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
        {
            if (await _userRepository.GetUserByIdAsync(command.Id) is not {} user)
                return Errors.User.NotFound;
        
            var updateUser = user.Update(command.FirstName, command.LastName, command.Email, 
                Balance.Create((Currency)Enum.Parse(typeof(Currency), command.Balance.Currency), 
                    command.Balance.Amount));
        
            await _userRepository.UpdateUserAsync(updateUser);
        
            return updateUser;
        }
    }
}