using AutoMapper;
using PayMart.Domain.Login.Entities;
using PayMart.Domain.Login.Interface.Repositories;
using PayMart.Domain.Login.ModelView;
using PayMart.Domain.Login.Security.Cryptography;

namespace PayMart.Application.Login.UseCases.RegisterUser;

public class RegisterUserLogin(IMapper mapper,
    ILoginRepository loginRepository,
    IEmailRepository emailRepository,
    IPasswordEncrypted encryptedPassword) : IRegisterUserLogin

{
    public async Task<string?> Execute(ModelLogin.RegisterLoginRequest request)
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
}
