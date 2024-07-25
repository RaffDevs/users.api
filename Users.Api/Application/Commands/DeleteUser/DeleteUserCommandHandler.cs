using MediatR;
using Users.Api.Application.Exceptions;
using Users.Api.Core.Repositories;

namespace Users.Api.Application.Commands.DeleteUser;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
{
    private readonly IUserRepository _repository;

    public DeleteUserCommandHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _repository.GetByIdAsync(request.Id);

        if (user is null)
        {
            throw new NotFoundException("No users found for this Id!");
        }

        await _repository.DeleteAsync(user);
    }
}