namespace PayMart.Domain.Login.ModelView;

public class ModelLogin
{
    public class LoginRequest
    {
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
    }

    /// <summary>
    /// -------
    /// </summary>

    public class LoginResponse
    {
        public string Token { get; set; } = string.Empty;
        public string Exception { get; set; } = string.Empty;

    }

    public class RegisterLoginResponse
    {
        public string ContactEmail { get; set; } = string.Empty;
        public int UserId { get; set; }
        public string Exception { get; set; } = string.Empty;
    }


}
