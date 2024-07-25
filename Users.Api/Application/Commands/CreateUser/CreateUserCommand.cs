using MediatR;
using Users.Api.Core.Entities;

namespace Users.Api.Application.Commands.CreateUser;

public class CreateUserCommand : IRequest<User>
{
    public User model { get; private set; }

    public CreateUserCommand(User model)
    {
        this.model = model;
    }
}