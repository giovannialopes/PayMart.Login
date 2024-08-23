using AutoMapper;
using PayMart.Domain.Login.Entities;
using PayMart.Domain.Login.Interface.DataBase;
using PayMart.Domain.Login.Interface.Login.GetUser;
using PayMart.Domain.Login.Interface.Login.RegisterUser;
using PayMart.Domain.Login.Request.RegisterUser;
using PayMart.Domain.Login.Response.RegisterUser;
using PayMart.Domain.Login.Security.Token;

namespace PayMart.Application.Login.UseCases.RegisterUser;

public class RegisterUserLoginUseCases : IRegisterUserLoginUseCases
{

    private readonly IMapper _mapper;
    private readonly IRegisterUser _getRegister;
    private readonly IGetUser _getUser;
    private readonly ICommit _commit;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public RegisterUserLoginUseCases(IMapper mapper,
        IRegisterUser getRegister,
        IGetUser getUser,
        ICommit commit,
        IJwtTokenGenerator jwtTokenGenerator)
    {
        _mapper = mapper;
        _getRegister = getRegister;
        _getUser = getUser;
        _commit = commit;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<ResponseRegisterUserLogin> Execute(RequestRegisterUserLogin request)
    {
        var response = _mapper.Map<LoginUser>(request);

        await _getRegister.RegisterUser(response);

        await _commit.Commit();

        var userID = await _getUser.GetUser(response.Email, response.Password);
        var returns = _jwtTokenGenerator.Generator(userID);

        return _mapper.Map<ResponseRegisterUserLogin>(returns);
    }
}
