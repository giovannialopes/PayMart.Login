using AutoMapper;
using PayMart.Domain.Login.Entities;
using PayMart.Domain.Login.Request.GetUser;
using PayMart.Domain.Login.Request.RegisterUser;
using PayMart.Domain.Login.Response.GetUser;
using PayMart.Domain.Login.Response.RegisterUser;

namespace PayMart.Application.Login.AutoMapper;

public class AutoMapping : Profile
{

    public AutoMapping()
    {
        RequestToEntity();
        EntityToResponse();
    }

    private void RequestToEntity()
    {
        CreateMap<RequestGetUserLogin, LoginUser>();
        CreateMap<RequestRegisterUserLogin, LoginUser>();
    }

    private void EntityToResponse()
    {
        CreateMap<LoginUser, ResponseGetUserLogin>();
        CreateMap<string, ResponseGetUserLogin>()
            .ForMember(dest => dest.Token, opt => opt.MapFrom(src => src));



        CreateMap<LoginUser, ResponseRegisterUserLogin>();
        CreateMap<string, ResponseRegisterUserLogin>()
            .ForMember(dest => dest.Token, opt => opt.MapFrom(src => src));
    }

}
