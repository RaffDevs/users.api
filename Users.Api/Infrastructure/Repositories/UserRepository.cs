using Microsoft.EntityFrameworkCore;
using Users.Api.Core.Entities;
using Users.Api.Core.Repositories;
using Users.Api.Infrastructure.Context;

namespace Users.Api.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly UsersDatabaseContext _context;

    public UserRepository(UsersDatabaseContext context)
    {
        _context = context;
    }

    public async Task<List<User>> GetAll()
    {
        var users = await _context.Users.ToListAsync();
        return users;
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