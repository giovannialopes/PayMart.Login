using Microsoft.Extensions.DependencyInjection;
using PayMart.Application.Login.AutoMapper;
using PayMart.Application.Login.UseCases.Delete;
using PayMart.Application.Login.UseCases.GetUser;
using PayMart.Application.Login.UseCases.RegisterUser;

namespace PayMart.Application.Login.Injection;

public static class DependencyInjectionApp
{
    public static void AddApplication(this IServiceCollection services)
    {
        AddRepositories(services);
        AutoMapper(services);
    }

    private static void AutoMapper(IServiceCollection services)
    {
        services.AddAutoMapper(typeof(AutoMapping));
    }

    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IGetUserLoginUseCases, GetUserLoginUseCases>();
        services.AddScoped<IRegisterUserLoginUseCases, RegisterUserLoginUseCases>();
        services.AddScoped<IDeleteLoginUseCases, DeleteLoginUseCases>();
    }
}
