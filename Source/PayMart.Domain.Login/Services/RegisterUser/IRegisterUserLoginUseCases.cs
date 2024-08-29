using static PayMart.Domain.Login.ModelView.ModelLogin;

namespace PayMart.Application.Login.UseCases.RegisterUser;

public interface IRegisterUserLoginUseCases
{
    Task<string?> Execute(RegisterLoginRequest request);
}
