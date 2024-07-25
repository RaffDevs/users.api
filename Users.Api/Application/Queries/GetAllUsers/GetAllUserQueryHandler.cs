using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Users.Api.Core.Entities;
using Users.Api.Core.Repositories;

namespace Users.Api.Application.Queries.GetAllUsers;

public class GetAllUserQueryHandler : IRequestHandler<GetAllUsersQuery, List<User>>
{
    private readonly IUserRepository _repository;

    public GetAllUserQueryHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<User>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await _repository.GetAllAsync();
        return users;
    }
}