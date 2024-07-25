using MediatR;
using Microsoft.AspNetCore.Mvc;
using Users.Api.Application.Commands.CreateUser;
using Users.Api.Application.Commands.UpdateUser;
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
        return Ok();
    }
    
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        return Ok(id);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] User data)
    {
        var command = new CreateUserCommand(data);
        var user = await _mediator.Send(command);
        return Ok(user);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] User data)
    {
        var command = new UpdateUserCommand(id, data);
        await _mediator.Send(command);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        return NoContent();
    }
}