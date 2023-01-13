using CleanArchitecutreTemplate.Domain.UserAggregate.Enums;
using FluentValidation;

namespace CleanArchitectureTemplate.Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(user => user.FirstName).NotEmpty();
            RuleFor(user => user.LastName).NotEmpty()
                .Must((user, lastName) => lastName != user.FirstName);
            RuleFor(user => user.Email).NotEmpty().EmailAddress();
            RuleFor(user => user.Balance.Amount).NotEmpty().GreaterThanOrEqualTo(0);
            RuleFor(user => user.Balance.Currency)
                .IsEnumName(typeof(Currency), caseSensitive: false);
        }
    }
}