using MediatR;
using Microsoft.AspNetCore.Mvc;
using Users.Api.Application.Commands.CreateUser;
using Users.Api.Application.Commands.DeleteUser;
using Users.Api.Application.Commands.UpdateUser;
using Users.Api.Application.Queries.GetAllUsers;
using Users.Api.Application.Queries.GetUserById;
using Users.Api.Core.Entities;

namespace Users.Api.Api.Controllers;

[Route("api/Users")]
public class UsersController : ControllerBase
{

    private readonly IMediator _mediator;

    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("hello")]
    public IActionResult HelloWorld()
    {
        return Ok("Hello World!");
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var query = new GetAllUsersQuery();
        var users = await _mediator.Send(query);
        return Ok(users);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var query = new GetUserByIdQuery(id);
        var user = await _mediator.Send(query);
        return Ok(user);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] User data)
    {
        var command = new CreateUserCommand(data);
        var user = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] User data)
    {
        var command = new UpdateUserCommand(id, data);
        await _mediator.Send(command);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteUserCommand(id);
        await _mediator.Send(command);
        return Ok();
    }
}