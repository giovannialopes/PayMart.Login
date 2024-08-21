using PayMart.Domain.Login.Request.RegisterUser;
using PayMart.Domain.Login.Response.RegisterUser;

namespace PayMart.Application.Login.UseCases.RegisterUser;

public interface IRegisterUserLoginUseCases
{
    Task<ResponseRegisterUserLogin> Execute(RequestRegisterUserLogin request);
}
