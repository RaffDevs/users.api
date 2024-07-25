using Microsoft.EntityFrameworkCore;
using Users.Api.Infrastructure.Context;

namespace Users.Api;

public class Startup
{
    public IConfiguration Configuration { get; }
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        string? server = Environment.GetEnvironmentVariable("DB_SERVER") ??
                         throw new NotImplementedException(); 
        string? port = Environment.GetEnvironmentVariable("DB_PORT") ??
                       throw new NotImplementedException(); 
        string? database = Environment.GetEnvironmentVariable("DB_DATABASE") ??
                           throw new NotImplementedException(); 
        string? user = Environment.GetEnvironmentVariable("DB_USER") ??
                       throw new NotImplementedException(); 
        string? password = Environment.GetEnvironmentVariable("DB_PASSWORD") ??
                           throw new NotImplementedException(); 
        
        string connectionString = $"Host={server};" +
                                  $"Port={port};" +
                                  $"Pooling=true;" +
                                  $"Database={database};" +
                                  $"User Id={user};" +
                                  $"Password={password};";

        services.AddDbContext<UsersDatabaseContext>(options =>
        {
            options.UseNpgsql(connectionString);
        });
        

        services.AddControllers();
        
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        // Configure the HTTP request pipeline.
        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseRouting();
        
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}