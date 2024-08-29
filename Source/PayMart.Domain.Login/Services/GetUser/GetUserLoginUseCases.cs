using AutoMapper;
using PayMart.Domain.Login.Interface.Repositories;
using PayMart.Domain.Login.ModelView;
using PayMart.Domain.Login.Security.Cryptography;
using PayMart.Domain.Login.Security.Token;

namespace PayMart.Application.Login.UseCases.GetUser;

public class GetUserLoginUseCases(IMapper mapper,
    ILoginRepository loginRepository,
    IEmailRepository emailRepository,
    IJwtTokenGenerator jwtTokenGenerator,
    IPasswordEncrypted passwordEncrypted) : IGetUserLoginUseCases
{

    public async Task<ModelLogin.LoginResponse?> Execute(ModelLogin.LoginRequest request)
    {
        var verifyEmail = await emailRepository.VerifyEmail(request.Email);
        if (verifyEmail != null)
        {
            var verifyPassword = passwordEncrypted.Verify(request.PasswordHash, verifyEmail.PasswordHash);
            if (verifyPassword == true)
            {
                var response = await loginRepository.GetUser(request.Email, verifyEmail.PasswordHash);
                var results = jwtTokenGenerator.Generator(response!);

                return mapper.Map<ModelLogin.LoginResponse>(results);

            }
        }
        return default;
    }
}
