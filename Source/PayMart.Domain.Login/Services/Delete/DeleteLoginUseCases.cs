﻿using PayMart.Domain.Login.Interface.Repositories;

namespace PayMart.Application.Login.UseCases.Delete;

public class DeleteLoginUseCases(ILoginRepository loginRepository) : IDeleteLoginUseCases
{

    public async Task<string?> Execute(int id)
    {
        var verifyUser = await loginRepository.VerifyUserEnabled(id);

        if (verifyUser != null)
        {
            verifyUser!.IsEnabled = false;
            loginRepository.DeleteUser(verifyUser!);

            await loginRepository.Commit();

            return "Delete";
        }

        return default;
    }
}
