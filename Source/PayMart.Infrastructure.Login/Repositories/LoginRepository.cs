using PayMart.Infrastructure.Login.DataAcess;
using PayMart.Domain.Login.Interface.DataBase;

namespace PayMart.Infrastructure.Login.Repositories;

public class LoginRepository:
    ICommit
{
    private readonly DbLogin _dbLogin;

    public LoginRepository(DbLogin dbLogin)
    {
        _dbLogin = dbLogin;
    }

    public Task Commit() => _dbLogin.SaveChangesAsync();
}
