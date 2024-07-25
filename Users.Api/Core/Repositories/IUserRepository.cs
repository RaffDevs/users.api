using Users.Api.Core.Entities;

namespace Users.Api.Core.Repositories;

public interface IUserRepository
{
    public Task<User> GetAll();
    public Task<User> GetById(int id);
    public Task<User> Create(User user);
    public Task Update(User user);
    public Task Delete(int id);

}