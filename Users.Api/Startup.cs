using System;
using Microsoft.EntityFrameworkCore;
using Users.Api.Application.Commands.CreateUser;
using Users.Api.Core.Repositories;
using Users.Api.Infrastructure.Context;
using Users.Api.Infrastructure.Repositories;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Users.Api.Api.Filters;
using Users.Api.Application.Validators;

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
        string? server = Environment.GetEnvironmentVariable("DB_SERVER") ?? "localhost";
        string? port = Environment.GetEnvironmentVariable("DB_PORT") ?? "5202";
        string? database = Environment.GetEnvironmentVariable("DB_DATABASE") ?? "users";
        string? user = Environment.GetEnvironmentVariable("DB_USER") ?? "dev";
        string? password = Environment.GetEnvironmentVariable("DB_PASSWORD") ?? "senhaXPTO";
        
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
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddMediatR(
            config => config.RegisterServicesFromAssembly(typeof(CreateUserCommand).Assembly)
        );
        services.AddFluentValidationAutoValidation();
        services.AddFluentValidationClientsideAdapters();
        services.AddValidatorsFromAssembly(typeof(CreateUserValidator).Assembly);
        services.AddControllers(options =>
        {
            options.Filters.Add(typeof(ValidationFilter));
            options.Filters.Add(typeof(ApiExceptionFilter));
        });
        
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