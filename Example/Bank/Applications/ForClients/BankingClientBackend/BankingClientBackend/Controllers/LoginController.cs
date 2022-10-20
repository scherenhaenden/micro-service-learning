using BankingClientBackend.Services.Middlewares.JWT;
using Microsoft.AspNetCore.Mvc;

namespace SaladBarBackEnd.Controllers;

[ApiController]
[Route("[controller]")]
public class LoginController : Controller
{
    private IUserService _userService;

    public LoginController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("authenticate")]
    public IActionResult Authenticate(AuthenticateRequest model)
    {
        var response = _userService.Authenticate(model);

        if (response == null)
            return BadRequest(new { message = "Username or password is incorrect" });

        return Ok(response);
    }

    [Authorize]
    [HttpGet]
    public IActionResult GetAll()
    {
        var users = _userService.GetAll();
        return Ok(users);
    }
}