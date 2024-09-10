using Microsoft.EntityFrameworkCore;
using PayMart.Domain.Login.Entities;

namespace PayMart.Infrastructure.Login.DataAcess;

public class DbLogin : DbContext
{
    public DbLogin(DbContextOptions options) : base(options) { }

    public DbSet<LoginUser> Tb_User { get; set; }

}
