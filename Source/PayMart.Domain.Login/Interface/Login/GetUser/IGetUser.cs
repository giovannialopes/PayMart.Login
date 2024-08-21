using PayMart.Domain.Login.Entities;

namespace PayMart.Domain.Login.Interface.Login.GetUser;

public interface IGetUser
{
    Task<LoginUser> GetUser();
}
