using AutoMapper;
using PayMart.Domain.Login.Interface.Login.GetUser;
using PayMart.Domain.Login.Request.GetUser;
using PayMart.Domain.Login.Response.GetUser;

namespace PayMart.Application.Login.UseCases.GetUser;

public class GetUserLoginUseCases : IGetUserLoginUseCases
{
    private readonly IMapper _mapper;
    private readonly IGetUser _getUser;


    public GetUserLoginUseCases(IMapper mapper,
        IGetUser getUser)
    {
        _mapper = mapper;
        _getUser = getUser;
    }

    public async Task<ResponseGetUserLogin> Execute(RequestGetUserLogin request)
    {
        var response = await _getUser.GetUser(request.Email, request.Password);

        return _mapper.Map<ResponseGetUserLogin>(response);
    }
}
