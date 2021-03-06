using Microsoft.AspNetCore.Mvc;
using ToDoAPI.Models;
using ToDoAPI.Services;

namespace ToDoAPI.Controllers;

[ApiController]
[Route("api/account")]
public class AccountController : ControllerBase
{
    private readonly IAccountService _service;

    public AccountController(IAccountService service)
    {
        _service = service;
    }

    [HttpPost("register")]
    public ActionResult RegisterUser([FromBody] RegisterUserDto dto)
    {
        _service.RegisterUser(dto);
        return Ok();
    }

    [HttpPost("login")]
    public ActionResult LoginUser([FromBody] LoginUserDto dto)
    {
        var token = _service.LoginUser(dto);
        return Ok(token);
    }
}