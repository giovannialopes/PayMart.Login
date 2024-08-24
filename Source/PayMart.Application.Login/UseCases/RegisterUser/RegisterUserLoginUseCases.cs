using AutoMapper;
using PayMart.Domain.Login.Entities;
using PayMart.Domain.Login.Exception.ResourceExceptions;
using PayMart.Domain.Login.Interface.Repositories;
using PayMart.Domain.Login.Request.RegisterUser;
using PayMart.Domain.Login.Response.RegisterUser;
using PayMart.Domain.Login.Security.Token;
using System.Net;

namespace PayMart.Application.Login.UseCases.RegisterUser;

public class RegisterUserLoginUseCases : IRegisterUserLoginUseCases
{

    private readonly IMapper _mapper;
    private readonly ILoginRepository _loginRepository;
    private readonly IEmailRepository _emailRepository;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public RegisterUserLoginUseCases(IMapper mapper,
        ILoginRepository loginRepository,
        IEmailRepository emailRepository,
        IJwtTokenGenerator jwtTokenGenerator)
    {
        _mapper = mapper;
        _loginRepository = loginRepository;
        _emailRepository = emailRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<ResponseRegisterUserLogin> Execute(RequestRegisterUserLogin request)
    {
        if (request.Email.Contains("@") && !string.IsNullOrEmpty(request.Email))
        {
            var verifyEmail = await _emailRepository.VerifyEmail(request.Email);

            if (verifyEmail != true)
            {
                var response = _mapper.Map<LoginUser>(request);

                _loginRepository.RegisterUser(response);

                await _loginRepository.Commit();

                var userID = await _loginRepository.GetUser(response.Email, response.Password);
                var returns = _jwtTokenGenerator.Generator(userID!);

                return _mapper.Map<ResponseRegisterUserLogin>(returns);
            }
            return new ResponseRegisterUserLogin() { Exception = ResourceExceptions.ERRO_EMAIL_REGISTRADO };
        }
        return new ResponseRegisterUserLogin() { Exception = ResourceExceptions.ERRO_EMAIL_INVALIDO };
    }
}
