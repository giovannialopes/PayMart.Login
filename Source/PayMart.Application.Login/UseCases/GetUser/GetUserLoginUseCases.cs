using AutoMapper;
using PayMart.Domain.Login.Interface.Login.GetUser;
using PayMart.Domain.Login.Request.GetUser;
using PayMart.Domain.Login.Response.GetUser;
using PayMart.Domain.Login.Security.Token;

namespace PayMart.Application.Login.UseCases.GetUser;

public class GetUserLoginUseCases : IGetUserLoginUseCases
{
    private readonly IMapper _mapper;
    private readonly IGetUser _getUser;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;


    public GetUserLoginUseCases(IMapper mapper,
        IGetUser getUser,
        IJwtTokenGenerator jwtTokenGenerator)
    {
        _mapper = mapper;
        _getUser = getUser;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<ResponseGetUserLogin> Execute(RequestGetUserLogin request)
    {
        var response = await _getUser.GetUser(request.Email, request.Password);
        var results = _jwtTokenGenerator.Generator(response);

        return _mapper.Map<ResponseGetUserLogin>(results);
    }
}
