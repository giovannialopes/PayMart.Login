using Microsoft.AspNetCore.Mvc;
using PayMart.Application.Login.UseCases.Delete;
using PayMart.Application.Login.UseCases.GetUser;
using PayMart.Application.Login.UseCases.RegisterUser;
using PayMart.Domain.Login.Request.GetUser;
using PayMart.Domain.Login.Request.RegisterUser;

namespace PayMart.API.Login.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LoginController : ControllerBase
{
    [HttpPost]
    [Route("getUser")]
    public async Task<IActionResult> GetUser(
        [FromServices] IGetUserLoginUseCases useCases,
        [FromBody] RequestGetUserLogin request)
    {
        var response = await useCases.Execute(request);
        if (response == null)
            return Ok("");

        return Ok(response);
    }

    [HttpPost]
    [Route("registerUser")]
    public async Task<IActionResult> RegisterUser(
        [FromServices] IRegisterUserLoginUseCases useCases,
        [FromBody] RequestRegisterUserLogin request)
    {
        var response = await useCases.Execute(request);
        if (response == null)
            return Ok("");

        return Ok(response);
    }

    [HttpDelete]
    [Route("delete/{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id,
        [FromServices] IDeleteLoginUseCases useCase)
    {
        var response = await useCase.Execute(id);
        if (response == null)
            return Ok("");

        return Ok(response);
    }
}
