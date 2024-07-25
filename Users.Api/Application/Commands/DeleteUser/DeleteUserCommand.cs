using MediatR;

namespace Users.Api.Application.Commands.DeleteUser;

public class DeleteUserCommand : IRequest
{
    public int Id { get; private set; }

    public DeleteUserCommand(int id)
    {
        Id = id;
    }
}