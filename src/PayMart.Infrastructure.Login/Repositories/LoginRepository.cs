using Microsoft.EntityFrameworkCore;
using PayMart.Domain.Login.Entities;
using PayMart.Domain.Login.Interface.Repositories;
using PayMart.Infrastructure.Login.DataAcess;

namespace PayMart.Infrastructure.Login.Repositories;

public class LoginRepository : ILoginRepository
{
    private readonly DbLogin _dbLogin;
    public LoginRepository(DbLogin dbLogin) => _dbLogin = dbLogin;

    /// <summary>
    /// Salva as alterações realizadas no contexto do banco de dados de forma assíncrona.
    /// Deve ser chamado após qualquer operação de escrita, como adição, atualização ou remoção de registros.
    /// </summary>
    /// <returns>
    /// Uma "Task" representando a operação assíncrona de salvar as alterações.
    /// </returns>
    public Task Commit() => _dbLogin.SaveChangesAsync();

    /// <summary>
    /// Obtém um usuário do banco de dados com base no email e senha fornecidos.
    /// Realiza uma busca assíncrona no banco de dados sem rastrear as alterações (AsNoTracking).
    /// </summary>
    /// <param name="email">Email do usuário a ser buscado.</param>
    /// <param name="password">Hash da senha do usuário.</param>
    /// <returns>
    /// Retorna um objeto"LoginUser" se um usuário correspondente for encontrado,
    /// ou null se não houver correspondência.
    /// </returns>
    public Task<LoginUser?> GetUser(string email, string password) => _dbLogin.Tb_User.AsNoTracking().
        FirstOrDefaultAsync(config => config.Email == email && config.PasswordHash == password);

    /// <summary>
    /// Adiciona um novo usuário ao banco de dados de forma assíncrona.
    /// O registro é apenas inserido no contexto de banco de dados; é necessário chamar o método <see cref="Commit"/> para persistir a alteração.
    /// </summary>
    /// <param name="login">Objeto "LoginUser" contendo os dados do usuário a ser registrado.</param>
    public void RegisterUser(LoginUser login) => _dbLogin.Tb_User.AddAsync(login);

    /// <summary>
    /// Verifica se um usuário está habilitado no sistema, buscando-o pelo seu ID.
    /// Realiza uma busca assíncrona no banco de dados sem rastrear as alterações (AsNoTracking).
    /// </summary>
    /// <param name="id">Identificador único do usuário.</param>
    /// <returns>
    /// Retorna um objeto "LoginUser" se o usuário estiver habilitado (IsEnabled = true),
    /// ou null se o usuário não for encontrado ou não estiver habilitado.
    /// </returns>
    public Task<LoginUser?> VerifyUserEnabled(int id) => _dbLogin.Tb_User.AsNoTracking().
        FirstOrDefaultAsync(config => config.Id == id && config.IsEnabled == true);

    /// <summary>
    /// Desativa um usuário no banco de dados, atualizando seu status.
    /// A alteração é realizada no contexto do banco de dados e é necessário chamar o método "Commit" para persistir a mudança.
    /// </summary>
    /// <param name="user">Objeto "LoginUser" contendo os dados do usuário a ser desativado.</param>
    public void DeleteUser(LoginUser user) => _dbLogin.Tb_User.Update(user);

}
