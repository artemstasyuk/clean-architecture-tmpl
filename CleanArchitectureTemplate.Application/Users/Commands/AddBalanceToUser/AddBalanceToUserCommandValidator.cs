using FluentValidation;

namespace CleanArchitectureTemplate.Application.Users.Commands.AddBalanceToUser;

public class AddBalanceToUserCommandValidator : AbstractValidator<AddBalanceToUserCommand>
{
    public AddBalanceToUserCommandValidator()
    {
        RuleFor(b => b.Amount).GreaterThan(0);
    }
}