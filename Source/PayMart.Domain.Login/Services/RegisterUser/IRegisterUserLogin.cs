using static PayMart.Domain.Login.ModelView.ModelLogin;

namespace PayMart.Application.Login.UseCases.RegisterUser;

public interface IRegisterUserLogin
{
    Task<string?> Execute(RegisterLoginRequest request);
}
