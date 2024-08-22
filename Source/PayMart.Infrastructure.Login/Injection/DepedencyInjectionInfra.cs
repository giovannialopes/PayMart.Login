using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PayMart.Domain.Login.Interface.DataBase;
using PayMart.Domain.Login.Interface.Login.Delete;
using PayMart.Domain.Login.Interface.Login.GetUser;
using PayMart.Domain.Login.Interface.Login.RegisterUser;
using PayMart.Infrastructure.Login.DataAcess;
using PayMart.Infrastructure.Login.Repositories;

namespace PayMart.Infrastructure.Login.Injection;

public static class DepedencyInjectionInfra
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        AddDbContext(services, configuration);
        AddRepositories(services);
    }

    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IGetUser, LoginRepository>();
        services.AddScoped<IRegisterUser, LoginRepository>();
        services.AddScoped<IDelete, LoginRepository>();
    }

    private static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ICommit, LoginRepository>();

        var connectionString = configuration.GetConnectionString("Connection");
        services.AddDbContext<DbLogin>(config => config.UseSqlServer(connectionString));
    }

}
