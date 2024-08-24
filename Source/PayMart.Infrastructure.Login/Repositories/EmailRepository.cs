using Microsoft.EntityFrameworkCore;
using PayMart.Domain.Login.Interface.Repositories;
using PayMart.Infrastructure.Login.DataAcess;

namespace PayMart.Infrastructure.Login.Repositories;

public class EmailRepository: IEmailRepository

{
    private readonly DbLogin _dbLogin;
    public EmailRepository(DbLogin dbLogin) => _dbLogin = dbLogin;

    public async Task Commit() => await _dbLogin.SaveChangesAsync();

    public async Task<bool?> VerifyEmail(string email) => await _dbLogin.Tb_User.AsNoTracking()
        .AnyAsync(config => config.Email == email && config.Enabled == 1);

}
