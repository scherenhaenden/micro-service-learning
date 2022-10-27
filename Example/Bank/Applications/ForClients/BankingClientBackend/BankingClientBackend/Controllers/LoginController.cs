using BankingClientBackend.Services.Middlewares.JWT;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BankingClientBackend.Controllers;

[ApiController]
[Route("[controller]")]
public class LoginController : Controller
{
    private IUserService _userService;

    public LoginController(IUserService userService)
    {
        _userService = userService;
    }

    [AllowAnonymous]
    [HttpPost("authenticate")]
    public IActionResult Authenticate(AuthenticateRequest model)
    {
        var response = _userService.Authenticate(model);

        if (response == null)
            return BadRequest(new { message = "Username or password is incorrect" });
        try
        {
            if (HttpContext != null)
            {
                HttpContext.Response.Headers.Add("Authorization", "Bearer " + response.Token);
            }
            
        }
        finally{}
       

        return Ok(response);
    }

    [BankingClientBackend.Services.Middlewares.JWT.Authorize]
    [HttpGet]
    public IActionResult GetAll()
    {
        var users = _userService.GetAll();
        return Ok(users);
    }
}