using System.Collections.Generic;
using System.Threading.Tasks;
using Users.Api.Core.Entities;

namespace Users.Api.Core.Repositories;

public interface IUserRepository
{
    public Task<List<User>> GetAllAsync();
    public Task<User?> GetByIdAsync(int id);
    public Task<User> CreateAsync(User user);
    public Task UpdateAsync(User user);
    public Task DeleteAsync(User user);

}