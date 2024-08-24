using AutoMapper;
using PayMart.Domain.Login.Interface.Repositories;
using PayMart.Domain.Login.Request.GetUser;
using PayMart.Domain.Login.Response.GetUser;
using PayMart.Domain.Login.Security.Token;

namespace PayMart.Application.Login.UseCases.GetUser;

public class GetUserLoginUseCases : IGetUserLoginUseCases
{
    private readonly IMapper _mapper;
    private readonly ILoginRepository _loginRepository;
    private readonly IEmailRepository _emailRepository;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public GetUserLoginUseCases(IMapper mapper,
        ILoginRepository loginRepository,
        IEmailRepository emailRepository,
        IJwtTokenGenerator jwtTokenGenerator)
    {
        _mapper = mapper;
        _loginRepository = loginRepository;
        _emailRepository = emailRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<ResponseGetUserLogin?> Execute(RequestGetUserLogin request)
    {
        var verifyEmail = await _emailRepository.VerifyEmail(request.Email);

        if (verifyEmail != false)
        {
            var response = await _loginRepository.GetUser(request.Email, request.Password);
            var results = _jwtTokenGenerator.Generator(response!);

            return _mapper.Map<ResponseGetUserLogin>(results);
        }
        return null;

    }
}
