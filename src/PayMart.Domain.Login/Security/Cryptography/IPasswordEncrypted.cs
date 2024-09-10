namespace PayMart.Domain.Login.Security.Cryptography;

public interface IPasswordEncrypted
{
    string Encrypt(string password);
    bool Verify(string passwordRequest, string passwordDB);
}
