using PayMart.Domain.Login.Security.Cryptography;
using BC = BCrypt.Net.BCrypt;

namespace PayMart.Infrastructure.Login.Security.Cryptography;

public class BCryptography : IPasswordEncrypted
{
    public string Encrypt(string password)
    {
        string passwordHash = BC.HashPassword(password);

        return passwordHash;
    }

    public bool Verify(string password, string passwordHash)
    {
        return BC.Verify(password, passwordHash);
    }
}
