using Microsoft.AspNetCore.Mvc;
using Users.Api.Core.Repositories;

namespace Users.Api.Controllers;

[Route("api/Users")]
public class UsersController : ControllerBase
{
    private readonly IUserRepository _repository;

    public UsersController(IUserRepository repository)
    {
        _repository = repository;
    }

    [HttpGet("hello")]
    public IActionResult HelloWorld()
    {
        return Ok("Hello World!");
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var users = await _repository.GetAll();
        return Ok(users);
    }
    
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        return Ok(id);
    }

    [HttpPost]
    public IActionResult Post()
    {
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id)
    {
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        return NoContent();
    }
}