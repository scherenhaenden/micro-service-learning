using InternalUsers.BusinessLogic.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InternalUsers.Controllers;

[ApiController]
[Route("[controller]")]
public class LoginController : Controller
{
    private readonly ILogicBusinessLogic _logicBusinessLogic;

    public LoginController(ILogicBusinessLogic logicBusinessLogic)
    {
        _logicBusinessLogic = logicBusinessLogic;
    }
    


        // GET
    [AllowAnonymous]
    [HttpGet]
    [Route("login")]
    public IActionResult Login(string username, string password)
    {
        var user = _logicBusinessLogic.GetUserInformationByUserNameAndPassword(username, password);
        if (user == null)
        {
            return Unauthorized();
        }
        return Ok(user);
    }
}