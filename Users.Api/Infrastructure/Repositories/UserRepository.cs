using Users.Api.Core.Entities;
using Users.Api.Core.Repositories;

namespace Users.Api.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    public Task<User> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<User> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<User> Create(User user)
    {
        throw new NotImplementedException();
    }

    public Task Update(User user)
    {
        throw new NotImplementedException();
    }

    public Task Delete(int id)
    {
        throw new NotImplementedException();
    }
}