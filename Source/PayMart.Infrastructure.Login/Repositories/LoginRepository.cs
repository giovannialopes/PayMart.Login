using Microsoft.EntityFrameworkCore;
using PayMart.Domain.Login.Entities;
using PayMart.Domain.Login.Interface.Repositories;
using PayMart.Infrastructure.Login.DataAcess;

namespace PayMart.Infrastructure.Login.Repositories;

public class LoginRepository : ILoginRepository
{
    private readonly DbLogin _dbLogin;
    public LoginRepository(DbLogin dbLogin) => _dbLogin = dbLogin;

    public Task Commit() => _dbLogin.SaveChangesAsync();

    public Task<LoginUser?> GetUser(string email, string password) => _dbLogin.Tb_User.AsNoTracking().
        FirstOrDefaultAsync(config => config.Email == email && config.Password == password);

    public void RegisterUser(LoginUser login) => _dbLogin.Tb_User.AddAsync(login);

    public Task<LoginUser?> VerifyUserEnabled(int id) => _dbLogin.Tb_User.AsNoTracking().
        FirstOrDefaultAsync(config => config.Id == id && config.Enabled == 1);

    public void DeleteUser(LoginUser user) => _dbLogin.Tb_User.Update(user);

}
