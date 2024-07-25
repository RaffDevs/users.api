using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Users.Api.Application.Exceptions;
using Users.Api.Core.Repositories;

namespace Users.Api.Application.Commands.UpdateUser;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
{
    private readonly IUserRepository _repository;

    public UpdateUserCommandHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _repository.GetByIdAsync(request.Id);

        if (user is null)
        {
            throw new NotFoundException("No users found for this Id!");
        }

        user.Name = request.Model.Name;
        user.Email = request.Model.Email;

        await _repository.UpdateAsync(user);
    }
}