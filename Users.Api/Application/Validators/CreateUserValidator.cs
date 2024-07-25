using FluentValidation;
using Users.Api.Application.Commands.CreateUser;
using Users.Api.Core.Entities;

namespace Users.Api.Application.Validators;

public class CreateUserValidator : AbstractValidator<User>
{
    public CreateUserValidator()
    {
        RuleFor(user => user.Email)
            .EmailAddress()
            .MinimumLength(10)
            .MaximumLength(100)
            .NotEmpty();

        RuleFor(user => user.Name)
            .MinimumLength(10)
            .MaximumLength(100)
            .NotEmpty();
    }
}