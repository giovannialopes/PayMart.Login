using PayMart.Domain.Login.ModelView;
using static PayMart.Domain.Login.ModelView.ModelLogin;

namespace PayMart.Domain.Login.Services;

public interface ILoginServices
{
    Task<ModelLogin.RegisterLoginResponse?> RegisterUserLogin(LoginRequest request);

    Task<LoginResponse?> GetUserLogin(LoginRequest request);

    Task<string?> DeleteUserLogin(int id);

}
