using PayMart.Domain.Login.Request.RegisterUser;
using PayMart.Domain.Login.Response.RegisterUser;

namespace PayMart.Application.Login.UseCases.RegisterUser;

public class RegisterUserLoginUseCases : IRegisterUserLoginUseCases
{
    public RegisterUserLoginUseCases()
    {
        
    }

    public Task<ResponseRegisterUserLogin> Execute(RequestRegisterUserLogin request)
    {
        throw new NotImplementedException();
    }
}
