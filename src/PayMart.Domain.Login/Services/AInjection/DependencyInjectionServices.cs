using Microsoft.Extensions.DependencyInjection;
using PayMart.Domain.Login.AutoMapper;

namespace PayMart.Domain.Login.Services.AInjection;

public static class DependencyInjectionServices
{
    public static void AddServices(this IServiceCollection services)
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
        services.AddScoped<ILoginServices, LoginServices>();
    }
}
