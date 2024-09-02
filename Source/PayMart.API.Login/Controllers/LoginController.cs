using Microsoft.AspNetCore.Mvc;
using PayMart.Domain.Login.Exceptions;
using PayMart.Domain.Login.Http.Client;
using PayMart.Domain.Login.ModelView;
using PayMart.Domain.Login.Services;

namespace PayMart.API.Login.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LoginController : ControllerBase
{
    [HttpPost]
    [Route("getUser")]
    public async Task<IActionResult> GetUser(
        [FromServices] ILoginServices services,
        [FromBody] ModelLogin.LoginRequest request)
    {
        var response = await services.GetUserLogin(request);
        if (response == null)
            return Ok(ResourceException.ERRO_USUARIO_NAO_ENCONTRADO);

        return Ok(response);
    }

    [HttpPost]
    [Route("registerUser")]
    public async Task<IActionResult> RegisterUser(
        [FromServices] ILoginServices services,
        [FromBody] ModelLogin.LoginRequest request)
    {
        var response = await services.RegisterUserLogin(request);
        if (response == null)
            return Ok(ResourceException.ERRO_EMAIL_JA_CADASTRADO);

        await HttpClients.AddClient(response);

        return Ok("Usuário Criado");
    }

    [HttpDelete]
    [Route("delete/{id}")]
    public async Task<IActionResult> DeleteUser(
        [FromServices] ILoginServices services,
        [FromRoute] int id)
    {
        var response = await services.DeleteUserLogin(id);
        if (response == null)
            return Ok(ResourceException.ERRO_USUARIO_NAO_ENCONTRADO_DELETE);

        return Ok(response);
    }
}
