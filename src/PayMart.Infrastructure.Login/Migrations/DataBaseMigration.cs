using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PayMart.Infrastructure.Login.DataAcess;

namespace PayMart.Infrastructure.Login.Migrations;

public class DataBaseMigration
{
    public async static Task MigrateDataBase(IServiceProvider service)
    {
        var db = service.GetRequiredService<DbLogin>();
        await db.Database.MigrateAsync();
    }
}
