using static PayMart.Domain.Login.ModelView.ModelLogin;

namespace PayMart.Application.Login.UseCases.GetUser;

public interface IGetUserLogin
{
    Task<LoginResponse?> Execute(LoginRequest request);
}
