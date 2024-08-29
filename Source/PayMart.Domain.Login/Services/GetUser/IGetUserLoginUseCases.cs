using static PayMart.Domain.Login.ModelView.ModelLogin;

namespace PayMart.Application.Login.UseCases.GetUser;

public interface IGetUserLoginUseCases
{
    Task<LoginResponse?> Execute(LoginRequest request);
}
