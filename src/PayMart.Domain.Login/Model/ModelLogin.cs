namespace PayMart.Domain.Login.ModelView;

public class ModelLogin
{

    /// <summary>
    /// Request para registrar/logar na aplicação.
    /// </summary>
    public class LoginRequest
    {
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
    }


    /// <summary>
    /// Response que retorna o token da aplicação.
    /// </summary>
    public class LoginResponse
    {
        public string Token { get; set; } = string.Empty;
        public string Exception { get; set; } = string.Empty;

    }

    /// <summary>
    /// Response enviar as informações do usuario para o microserviço de Client.
    /// </summary>
    public class RegisterLoginResponse
    {
        public string ContactEmail { get; set; } = string.Empty;
        public int UserId { get; set; }
        public string Exception { get; set; } = string.Empty;
    }


}
