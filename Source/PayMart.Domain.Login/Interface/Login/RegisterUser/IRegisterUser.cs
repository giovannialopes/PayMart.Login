using PayMart.Domain.Login.Entities;

namespace PayMart.Domain.Login.Interface.Login.RegisterUser;

public interface IRegisterUser
{
    Task GetUser(LoginUser login);
}
