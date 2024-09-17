using Microsoft.EntityFrameworkCore;
using PayMart.Domain.Login.Entities;
using PayMart.Domain.Login.Interface.Repositories;
using PayMart.Infrastructure.Login.DataAcess;

namespace PayMart.Infrastructure.Login.Repositories;

public class EmailRepository: IEmailRepository

{
    private readonly DbLogin _dbLogin;
    public EmailRepository(DbLogin dbLogin) => _dbLogin = dbLogin;

    /// <summary>
    /// Salva as alterações realizadas no contexto do banco de dados de forma assíncrona.
    /// Deve ser chamado após qualquer operação de escrita, como adição, atualização ou remoção de registros.
    /// </summary>
    /// <returns>
    /// Uma "Task" representando a operação assíncrona de salvar as alterações.
    /// </returns>
    public async Task Commit() => await _dbLogin.SaveChangesAsync();


    /// <summary>
    /// Verifica se possui um email no banco de dados com o mesmo email passado pelo parametro.
    /// </summary>
    /// <param name="email"></param>
    /// <returns></returns>
    public async Task<LoginUser?> VerifyEmail(string email) => await _dbLogin.Tb_User.AsNoTracking()
        .FirstOrDefaultAsync(config => config.Email == email && config.IsEnabled == true);

}
