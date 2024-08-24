using PayMart.Domain.Login.Interface.Repositories;

namespace PayMart.Application.Login.UseCases.Delete;

public class DeleteLoginUseCases : IDeleteLoginUseCases
{
    private readonly ILoginRepository _loginRepository;

    public DeleteLoginUseCases(ILoginRepository loginRepository)
    {
        _loginRepository = loginRepository;
    }

    public async Task<string?> Execute(int id)
    {
        var verifyUser = await _loginRepository.VerifyUserEnabled(id);

        if (verifyUser != null)
        {
            verifyUser!.Enabled = 0;
            _loginRepository.DeleteUser(verifyUser!);

            await _loginRepository.Commit();

            return "Delete";
        }

        return null;
    }
}
