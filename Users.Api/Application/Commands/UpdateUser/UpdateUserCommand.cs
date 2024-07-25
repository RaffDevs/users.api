using MediatR;
using Users.Api.Core.Entities;

namespace Users.Api.Application.Commands.UpdateUser;

public class UpdateUserCommand : IRequest
{
    public int Id { get; private set; }
    public User Model { get; private set; }

    public UpdateUserCommand(int id, User model)
    {
        Id = id;
        Model = model;
    }
}