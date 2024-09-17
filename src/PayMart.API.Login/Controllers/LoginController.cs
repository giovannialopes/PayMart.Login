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

    /// <summary>
    /// Método HTTP POST para buscar um usuário no sistema.
    /// </summary>
    /// <param name="services">Serviço responsável pela lógica de login do usuário.</param>
    /// <param name="request">Objeto que contém as credenciais do usuário (email e senha).</param>
    /// <returns>
    /// Retorna uma resposta de sucesso contendo os dados do usuário, ou uma mensagem de erro
    /// se o usuário não for encontrado.
    /// </returns>
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


    /// <summary>
    /// Método HTTP POST para registrar um novo usuário no sistema.
    /// </summary>
    /// <param name="services">Serviço responsável pela lógica de cadastro do usuário.</param>
    /// <param name="request">Objeto que contém os dados do usuário para registro (email e senha).</param>
    /// <returns>
    /// Retorna uma mensagem de sucesso após o registro do usuário ou uma mensagem de erro
    /// caso o email já esteja cadastrado no sistema.
    /// </returns>
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


    /// <summary>
    /// Método HTTP DELETE para desabilitar um usuário no sistema.
    /// </summary>
    /// <param name="services">Serviço responsável pela lógica de desativação do usuário.</param>
    /// <param name="id">Identificador único do usuário a ser desabilitado.</param>
    /// <returns>
    /// Retorna uma mensagem de sucesso após a desabilitação ou uma mensagem de erro
    /// caso o usuário não seja encontrado.
    /// </returns>
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
