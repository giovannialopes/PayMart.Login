using static PayMart.Domain.Login.ModelView.ModelLogin;

namespace PayMart.Domain.Login.Services;

public interface ILoginServices
{
    Task<string?> RegisterUserLogin(RegisterLoginRequest request);

    Task<LoginResponse?> GetUserLogin(LoginRequest request);

    Task<string?> DeleteUserLogin(int id);

}
