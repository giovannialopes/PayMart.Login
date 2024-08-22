using AutoMapper;
using PayMart.Domain.Login.Entities;
using PayMart.Domain.Login.Interface.DataBase;
using PayMart.Domain.Login.Interface.Login.GetUser;
using PayMart.Domain.Login.Interface.Login.RegisterUser;
using PayMart.Domain.Login.Request.RegisterUser;
using PayMart.Domain.Login.Response.RegisterUser;

namespace PayMart.Application.Login.UseCases.RegisterUser;

public class RegisterUserLoginUseCases : IRegisterUserLoginUseCases
{

    private readonly IMapper _mapper;
    private readonly IRegisterUser _getRegister;
    private readonly ICommit _commit;

    public RegisterUserLoginUseCases(IMapper mapper,
        IRegisterUser getUser,
        ICommit commit)
    {
        _mapper = mapper;
        _getRegister = getUser;
        _commit = commit;
    }

    public async Task<string> Execute(RequestRegisterUserLogin request)
    {
        var response = _mapper.Map<LoginUser>(request);

        await _getRegister.RegisterUser(response);

        await _commit.Commit();

        return "Login criado com sucesso";
    }
}
