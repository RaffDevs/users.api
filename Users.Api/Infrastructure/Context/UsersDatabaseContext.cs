using Microsoft.EntityFrameworkCore;
using Users.Api.Core.Entities;

namespace Users.Api.Infrastructure.Context;

public class UsersDatabaseContext : DbContext
{
    public UsersDatabaseContext(DbContextOptions<UsersDatabaseContext> options) : base(options) {}
    
    public DbSet<User> Users { get; set; }
}