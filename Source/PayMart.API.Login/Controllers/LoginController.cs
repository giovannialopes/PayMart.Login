using Microsoft.AspNetCore.Mvc;
using PayMart.Application.Login.UseCases.Delete;
using PayMart.Application.Login.UseCases.GetUser;
using PayMart.Application.Login.UseCases.RegisterUser;
using PayMart.Domain.Login.ModelView;

namespace PayMart.API.Login.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LoginController : ControllerBase
{
    [HttpPost]
    [Route("getUser")]
    public async Task<IActionResult> GetUser(
        [FromServices] IGetUserLoginUseCases services,
        [FromBody] ModelLogin.LoginRequest request)
    {
        var response = await services.Execute(request);
        if (response == null)
            return Ok("");

        return Ok(response);
    }

    [HttpPost]
    [Route("registerUser")]
    public async Task<IActionResult> RegisterUser(
        [FromServices] IRegisterUserLoginUseCases services,
        [FromBody] ModelLogin.RegisterLoginRequest request)
    {
        var response = await services.Execute(request);
        if (response == null)
            return Ok("");

        return Ok(response);
    }

    [HttpDelete]
    [Route("delete/{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id,
        [FromServices] IDeleteLoginUseCases services)
    {
        var response = await services.Execute(id);
        if (response == null)
            return Ok("");

        return Ok(response);
    }
}
