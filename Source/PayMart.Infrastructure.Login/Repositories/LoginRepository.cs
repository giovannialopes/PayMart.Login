using PayMart.Infrastructure.Login.DataAcess;
using PayMart.Domain.Login.Interface.DataBase;
using PayMart.Domain.Login.Interface.Login.GetUser;
using PayMart.Domain.Login.Interface.Login.RegisterUser;
using PayMart.Domain.Login.Entities;
using Microsoft.EntityFrameworkCore;

namespace PayMart.Infrastructure.Login.Repositories;

public class LoginRepository:
    ICommit,
    IGetUser,
    IRegisterUser
{
    private readonly DbLogin _dbLogin;

    public LoginRepository(DbLogin dbLogin)
    {
        _dbLogin = dbLogin;
    }

    public Task Commit() => _dbLogin.SaveChangesAsync();

    public async Task<LoginUser?> GetUser(string email, string password) => await _dbLogin.Tb_User.AsNoTracking().
        FirstOrDefaultAsync(config => config.Email == email && config.Password == password);


    public async Task RegisterUser(LoginUser login) => await _dbLogin.Tb_User.AddAsync(login);

}
