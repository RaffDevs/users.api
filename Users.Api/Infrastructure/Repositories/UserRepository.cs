using System.Collections.Generic;
using System.Threading.Tasks;
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

    public async Task<List<User>> GetAllAsync()
    {
        var users = await _context.Users.ToListAsync();
        return users;
    }

    public async Task<User?> GetByIdAsync(int id)
    {
        var user = await _context.Users.FindAsync(id);
        return user;
    }

    public async Task<User> CreateAsync(User user)
    {
        var result = _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return result.Entity;
    }

    public async Task UpdateAsync(User user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(User user)
    {
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
    }
    
}