using PayMart.Domain.Login.ModelView;
using static PayMart.Domain.Login.ModelView.ModelLogin;

namespace PayMart.Domain.Login.Services;

public interface ILoginServices
{
    /// <summary>
    /// Registra um novo usuário no banco de dados.
    /// </summary>
    /// <param name="request">Objeto contendo as informações de registro do usuário, como email e senha.</param>
    /// <returns>
    /// Retorna um objeto do tipo `RegisterLoginResponse` com os dados do usuário criado,
    /// ou `null` se o registro falhar (exemplo: email já cadastrado).
    /// </returns>
    Task<ModelLogin.RegisterLoginResponse?> RegisterUserLogin(LoginRequest request);


    /// <summary>
    /// Recupera um usuário do banco de dados com base nas credenciais fornecidas.
    /// </summary>
    /// <param name="request">Objeto contendo as credenciais de login do usuário (email e senha).</param>
    /// <returns>
    /// Retorna um objeto do tipo `LoginResponse` contendo as informações do usuário,
    /// ou `null` se o usuário não for encontrado.
    /// </returns>
    Task<LoginResponse?> GetUserLogin(LoginRequest request);


    /// <summary>
    /// Desativa um usuário no banco de dados com base no seu ID.
    /// </summary>
    /// <param name="id">Identificador único do usuário a ser desativado.</param>
    /// <returns>
    /// Retorna uma string de confirmação se a desativação for bem-sucedida,
    /// ou `null` se o usuário não for encontrado.
    /// </returns>
    Task<string?> DeleteUserLogin(int id);

}
