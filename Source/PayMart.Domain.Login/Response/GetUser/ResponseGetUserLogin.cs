namespace PayMart.Domain.Login.Response.GetUser;

public class ResponseGetUserLogin
{
    public int Id { get; set; }
    public string Token { get; set; } = "";
    public string Email { get; set; } = "";
    public string Password { get; set; } = "";

}
