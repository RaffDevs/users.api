using MediatR;
using Users.Api.Core.Entities;
using Users.Api.Core.Repositories;

namespace Users.Api.Application.Commands.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, User>
{
    private readonly IUserRepository _repository;

    public CreateUserCommandHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _repository.CreateAsync(request.Model);
        return user;
    }
}