using Domain.IServices;
using Entities.Model;
using Entities.Response;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _service;

    public UserController(IUserService service)
    {
        _service = service;
    }

    [HttpPost("RegisterUser")]
    [Produces("application/json")]
    public async Task<ActionResult<WebResponse<User>>> RegisterUser(User user) 
        => await _service.RegisterUser(user);

    [HttpPost("LoginUser")]
    [Produces("application/json")]
    public async Task<ActionResult<WebResponse<object>>> LoginUser(LoginUser loginUser) 
        => await _service.LoginUser(loginUser.UserEmail, loginUser.UserPassword);
}
