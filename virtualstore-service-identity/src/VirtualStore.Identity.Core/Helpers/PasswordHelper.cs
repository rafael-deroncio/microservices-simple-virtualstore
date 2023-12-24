using System.Security.Cryptography;
using System.Text;

namespace VirtualStore.Identity.Core.Helpers;

public static class PasswordHelper
{
    public static Task<string> GeneratePasswordHashSHA256(string senha)
    {
        using SHA256 sha256 = SHA256.Create();
        byte[] passwordBytes = Encoding.UTF8.GetBytes(senha);
        byte[] hashedBytes = sha256.ComputeHash(passwordBytes);

        StringBuilder sb = new();
        foreach (byte b in hashedBytes)
        {
            sb.Append(b.ToString("x2"));
        }

        return Task.FromResult(sb.ToString());
    }
}