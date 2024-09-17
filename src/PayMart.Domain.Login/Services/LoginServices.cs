using AutoMapper;
using PayMart.Domain.Login.Entities;
using PayMart.Domain.Login.Interface.Repositories;
using PayMart.Domain.Login.ModelView;
using PayMart.Domain.Login.Security.Cryptography;
using PayMart.Domain.Login.Security.Token;

namespace PayMart.Domain.Login.Services;

public class LoginServices(ILoginRepository loginRepository,
    IEmailRepository emailRepository,
    IPasswordEncrypted encryptedPassword,
    IJwtTokenGenerator jwtTokenGenerator,
    IMapper mapper) : ILoginServices
{
    /// <summary>
    /// Realiza o registro de um novo usuário no banco de dados.
    /// Valida se o email fornecido é válido e se já existe no sistema. 
    /// Caso contrário, realiza o registro e retorna as informações do usuário cadastrado.
    /// </summary>
    /// <param name="request">Objeto contendo os dados de registro do usuário (email e senha).</param>
    /// <returns>
    /// Retorna um objeto "ModelLogin.RegisterLoginResponse" contendo o email e o ID do usuário registrado,
    /// ou null se o email for inválido ou já estiver cadastrado.
    /// </returns>
    public async Task<ModelLogin.RegisterLoginResponse?> RegisterUserLogin(ModelLogin.LoginRequest request)
    {
        if (request.Email.Contains("@") && !string.IsNullOrEmpty(request.Email))
        {
            var verifyEmail = await emailRepository.VerifyEmail(request.Email);
            if (verifyEmail == null)
            {
                var response = mapper.Map<LoginUser>(request);
                response.PasswordHash = encryptedPassword.Encrypt(response.PasswordHash);

                loginRepository.RegisterUser(response);

                await loginRepository.Commit();

                var userID = await loginRepository.GetUser(response.Email, response.PasswordHash);

                var mapResponse = new ModelLogin.RegisterLoginResponse
                {
                    ContactEmail = userID!.Email,
                    UserId = userID.Id,
                };

                return mapResponse;
            }
        }
        return default;
    }


    /// <summary>
    /// Realiza a autenticação de um usuário no sistema.
    /// Valida o email e a senha fornecidos, gerando um token JWT caso a autenticação seja bem-sucedida.
    /// </summary>
    /// <param name="request">Objeto contendo as credenciais de login do usuário (email e senha).</param>
    /// <returns>
    /// Retorna um objeto "ModelLogin.LoginResponse" contendo o token JWT gerado, 
    /// ou null se as credenciais forem inválidas.
    /// </returns>
    public async Task<ModelLogin.LoginResponse?> GetUserLogin(ModelLogin.LoginRequest request)
    {
        var verifyEmail = await emailRepository.VerifyEmail(request.Email);
        if (verifyEmail != null)
        {
            var verifyPassword = encryptedPassword.Verify(request.PasswordHash, verifyEmail.PasswordHash);
            if (verifyPassword == true)
            {
                var response = await loginRepository.GetUser(request.Email, verifyEmail.PasswordHash);
                var results = jwtTokenGenerator.Generator(response!);

                return mapper.Map<ModelLogin.LoginResponse>(results);

            }
        }
        return default;
    }


    /// <summary>
    /// Desabilita um usuário no sistema com base no seu ID.
    /// Define o usuário como desativado (IsEnabled = false) e realiza o commit no banco de dados.
    /// </summary>
    /// <param name="id">Identificador único do usuário a ser desativado.</param>
    /// <returns>
    /// Retorna a string "Deleted" se o usuário for encontrado e desabilitado com sucesso,
    /// ou null se o usuário não for encontrado.
    /// </returns>
    public async Task<string?> DeleteUserLogin(int id)
    {
        var verifyUser = await loginRepository.VerifyUserEnabled(id);

        if (verifyUser != null)
        {
            verifyUser!.IsEnabled = false;
            loginRepository.DeleteUser(verifyUser!);

            await loginRepository.Commit();

            return "Deleted";
        }

        return default;
    }
}
