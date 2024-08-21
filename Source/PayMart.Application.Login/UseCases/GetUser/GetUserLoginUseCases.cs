using PayMart.Domain.Login.Request.GetUser;
using PayMart.Domain.Login.Response.GetUser;

namespace PayMart.Application.Login.UseCases.GetUser;

public class GetUserLoginUseCases : IGetUserLoginUseCases
{

    public GetUserLoginUseCases()
    {
        
    }

    public Task<ResponseGetUserLogin> Execute(RequestGetUserLogin request)
    {
        throw new NotImplementedException();
    }
}
