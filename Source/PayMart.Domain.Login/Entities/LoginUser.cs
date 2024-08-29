namespace PayMart.Domain.Login.Entities;

public class LoginUser
{
    public int Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public bool IsEnabled { get; set; } = true;
    public DateTime CreatedDate { get; set; } = DateTime.Now;
}
