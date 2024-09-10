using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PayMart.Domain.Login.Interface.DataBase;
using PayMart.Domain.Login.Interface.Repositories;
using PayMart.Domain.Login.Security.Cryptography;
using PayMart.Domain.Login.Security.Token;
using PayMart.Infrastructure.Login.DataAcess;
using PayMart.Infrastructure.Login.Repositories;
using PayMart.Infrastructure.Login.Security.Cryptography;
using PayMart.Infrastructure.Login.Security.Token;

namespace PayMart.Infrastructure.Login.Injection;

public static class DepedencyInjectionInfra
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        AddDbContext(services, configuration);
        AddRepositories(services);
        AddToken(services, configuration);
    }

    private static void AddToken(IServiceCollection services, IConfiguration configuration)
    {
        var expirationToken = configuration.GetValue<uint>("Settings:Jwt:ExpiresMinute");
        var signingKey = configuration.GetValue<string>("Settings:Jwt:SigningKey");

        services.AddScoped<IJwtTokenGenerator>(config => new JwtAcessToken(expirationToken, signingKey!));
    }


    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<ILoginRepository, LoginRepository>();
        services.AddScoped<IEmailRepository, EmailRepository>();
        services.AddScoped<IPasswordEncrypted, BCryptography>();
    }

    private static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ICommit, LoginRepository>();

        var connectionString = configuration.GetConnectionString("Connection");
        services.AddDbContext<DbLogin>(config => config.UseSqlServer(connectionString));
    }
}
