using AutoMapper;
using PayMart.Domain.Login.Entities;
using static PayMart.Domain.Login.ModelView.ModelLogin;

namespace PayMart.Domain.Login.AutoMapper;

public class AutoMapping : Profile
{

    public AutoMapping()
    {
        RequestToEntity();
        EntityToResponse();
        StringToResponse();
    }

    private void RequestToEntity()
    {
        CreateMap<RegisterLoginRequest, LoginUser>();
        CreateMap<LoginRequest, LoginUser>();
    }

    private void EntityToResponse()
    {
        CreateMap<LoginUser, LoginResponse>();

    }

    private void StringToResponse()
    {
        CreateMap<string, LoginResponse>()
            .ForMember(dest => dest.Token, opt => opt.MapFrom(src => src));
    }

}
