namespace PayMart.Domain.Login.ModelView;

public class ModelLogin
{
    public class LoginRequest
    {
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
    }

    public class RegisterLoginRequest
    {
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
    }



    public class LoginResponse
    {
        public string Token { get; set; } = string.Empty;
    }


}
