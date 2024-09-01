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
    public async Task<string?> RegisterUserLogin(ModelLogin.RegisterLoginRequest request)
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
                return mapper.Map<string>("Usuário Criado");
            }
        }
        return default;
    }

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
