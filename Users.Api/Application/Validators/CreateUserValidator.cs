using FluentValidation;
using Users.Api.Application.Commands.CreateUser;
using Users.Api.Core.Entities;

namespace Users.Api.Application.Validators;

public class CreateUserValidator : AbstractValidator<User>
{
    public CreateUserValidator()
    {
        RuleFor(user => user.Email)
            .NotNull()
            .NotEmpty()
            .EmailAddress()
            .MinimumLength(10)
            .MaximumLength(100);

        RuleFor(user => user.Name)
            .NotNull()
            .NotEmpty()
            .MinimumLength(10)
            .MaximumLength(100);
    }
}