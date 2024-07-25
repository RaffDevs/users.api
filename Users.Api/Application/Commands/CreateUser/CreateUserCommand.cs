using MediatR;
using Users.Api.Core.Entities;

namespace Users.Api.Application.Commands.CreateUser;

public class CreateUserCommand : IRequest<User>
{
    public User Model { get; private set; }

    public CreateUserCommand(User model)
    {
        this.Model = model;
    }
}