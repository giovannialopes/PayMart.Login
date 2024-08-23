using PayMart.Domain.Login.Entities;

namespace PayMart.Domain.Login.Security.Token;

public interface IJwtTokenGenerator
{
    string Generator(LoginUser user);
}
