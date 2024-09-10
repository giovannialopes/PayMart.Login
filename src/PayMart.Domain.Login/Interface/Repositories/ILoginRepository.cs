using PayMart.Domain.Login.Entities;
using PayMart.Domain.Login.Interface.DataBase;

namespace PayMart.Domain.Login.Interface.Repositories;

public interface ILoginRepository : ICommit
{
    public Task<LoginUser?> GetUser(string email, string password);

    public void RegisterUser(LoginUser login);

    public Task<LoginUser?> VerifyUserEnabled(int id);

    public void DeleteUser(LoginUser user);
}
