using MediatR;
using Users.Api.Core.Entities;
using Users.Api.Core.Repositories;

namespace Users.Api.Application.Queries.GetUserById;

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, User>
{
    private readonly IUserRepository _repository;

    public GetUserByIdQueryHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _repository.GetByIdAsync(request.Id);

        if (user is null)
        {
            throw new NotImplementedException();
        }

        return user;
    }
}